using TMPro;
using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [SerializeField] private ObjectStatistics _statistics;
    [SerializeField] private TextMeshProUGUI _spawnedText;
    [SerializeField] private TextMeshProUGUI _createdText;
    [SerializeField] private TextMeshProUGUI _activeText;

    private void Start()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        _statistics.OnStatsUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        _statistics.OnStatsUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        _spawnedText.text = $"Spawned: {_statistics.SpawnedCount}";
        _createdText.text = $"Created: {_statistics.CreatedCount}";
        _activeText.text = $"Active: {_statistics.ActiveCount}";
    }
}
