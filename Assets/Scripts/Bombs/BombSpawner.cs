using UnityEngine;

public class BombSpawner : ObjectSpawner<Bomb>
{
    [SerializeField] private ObjectSpawner<Bomb> _spawner;

    public void SpawnBomb(Vector3 position)
    {
        _spawner.SpawnAtPosition(position);
    }
}
