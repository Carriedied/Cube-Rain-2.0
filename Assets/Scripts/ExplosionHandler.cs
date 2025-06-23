using UnityEngine;
using UnityEngine.Pool;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private BombSpawner _bombSpawner;

    private void OnEnable()
    {
        CommonPool<Cube>.OnItemReleased += HandleCubeReleased;
    }

    private void OnDisable()
    {
        CommonPool<Cube>.OnItemReleased -= HandleCubeReleased;
    }

    private void HandleCubeReleased(Cube cube)
    {
        _bombSpawner.SpawnBomb(cube.transform.position);
    }
} 
