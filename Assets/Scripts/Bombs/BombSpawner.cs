using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private BombPool _pool;

    public Bomb SpawnBomb(Vector3 position)
    {
        Bomb bomb = _pool.GetObject();

        bomb.transform.position = position;

        bomb.Reset();
        bomb.StartFading();

        return bomb;
    }
}
