using System;
using UnityEngine;

public class ObjectStatistics : MonoBehaviour
{
    public int SpawnedCount { get; private set; }
    public int CreatedCount { get; private set; }
    public int ActiveCount { get; private set; }

    public event Action OnStatsUpdated;

    public void AddSpawned()
    {
        SpawnedCount++;
        OnStatsUpdated?.Invoke();
    }

    public void AddCreated()
    {
        CreatedCount++;
        OnStatsUpdated?.Invoke();
    }

    public void UpdateActiveCount(int count)
    {
        ActiveCount = count;
        OnStatsUpdated?.Invoke();
    }

    public void ResetStats()
    {
        SpawnedCount = 0;
        CreatedCount = 0;
        ActiveCount = 0;
        OnStatsUpdated?.Invoke();
    }
}
