using TMPro;
using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [SerializeField] private ObjectStatistics _cubeStats;
    [SerializeField] private ObjectStatistics _bombStats;

    [SerializeField] private TextMeshProUGUI _cubeSpawnedText;
    [SerializeField] private TextMeshProUGUI _cubeCreatedText;
    [SerializeField] private TextMeshProUGUI _cubeActiveText;

    [SerializeField] private TextMeshProUGUI _bombSpawnedText;
    [SerializeField] private TextMeshProUGUI _bombCreatedText;
    [SerializeField] private TextMeshProUGUI _bombActiveText;

    private void OnEnable()
    {
        _cubeStats.OnStatsUpdated += UpdateCubeUI;
        _bombStats.OnStatsUpdated += UpdateBombUI;
    }

    private void OnDisable()
    {
        _cubeStats.OnStatsUpdated -= UpdateCubeUI;
        _bombStats.OnStatsUpdated -= UpdateBombUI;
    }

    private void Start()
    {
        UpdateCubeUI();
        UpdateBombUI();
    }

    private void UpdateCubeUI()
    {
        _cubeSpawnedText.text = $"Spawned: {_cubeStats.SpawnedCount}";
        _cubeCreatedText.text = $"Created: {_cubeStats.CreatedCount}";
        _cubeActiveText.text = $"Active: {_cubeStats.ActiveCount}";
    }

    private void UpdateBombUI()
    {
        _bombSpawnedText.text = $"Spawned: {_bombStats.SpawnedCount}";
        _bombCreatedText.text = $"Created: {_bombStats.CreatedCount}";
        _bombActiveText.text = $"Active: {_bombStats.ActiveCount}";
    }
}
