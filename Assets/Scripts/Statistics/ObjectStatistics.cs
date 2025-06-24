using UnityEngine;

[CreateAssetMenu(fileName = "ObjectStatistics", menuName = "Scriptable Objects/Statistic")]
public class ObjectStatistics : ScriptableObject
{
    [SerializeField] private int _spawnedCount = 0;
    [SerializeField] private int _createdCount = 0;
    [SerializeField] private int _activeCount = 0;

    public int SpawnedCount => _spawnedCount;
    public int CreatedCount => _createdCount;
    public int ActiveCount => _activeCount;

    public event System.Action OnStatsUpdated;

    public void AddSpawned()
    {
        _spawnedCount++;
        OnStatsUpdated?.Invoke();
    }

    public void AddCreated()
    {
        _createdCount++;
        OnStatsUpdated?.Invoke();
    }

    public void SetActive(int count)
    {
        _activeCount = count;
        OnStatsUpdated?.Invoke();
    }

    public void ResetStats()
    {
        _spawnedCount = 0;
        _createdCount = 0;
        _activeCount = 0;

        OnStatsUpdated?.Invoke();
    }
}
