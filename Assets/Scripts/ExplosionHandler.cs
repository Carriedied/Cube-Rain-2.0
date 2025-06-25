using UnityEngine;
using UnityEngine.Pool;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private CommonPool<Cube> _cubePool;

    private void OnEnable()
    {
        if (_cubePool != null)
            _cubePool.OnItemReleased += HandleCubeReleased;
    }

    private void OnDisable()
    {
        if (_cubePool != null)
            _cubePool.OnItemReleased -= HandleCubeReleased;
    }

    private void HandleCubeReleased(Cube cube)
    {
        _bombSpawner.SpawnBomb(cube.transform.position);
    }
} 
