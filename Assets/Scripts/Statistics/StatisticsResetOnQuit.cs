using UnityEngine;

public class StatisticsResetOnQuit : MonoBehaviour
{
    [SerializeField] private ObjectStatistics _cubeStats;
    [SerializeField] private ObjectStatistics _bombStats;

    private void OnApplicationQuit()
    {
        _cubeStats.ResetStats();
        _bombStats.ResetStats();
    }
}
