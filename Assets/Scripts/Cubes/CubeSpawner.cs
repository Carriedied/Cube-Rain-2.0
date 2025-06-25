using UnityEngine;

public class CubeSpawner : ObjectSpawner<Cube>
{
    [SerializeField] private Transform _platform;

    private float _maxY = 15f;

    private void Start()
    {
        SetSpawnPositionProvider(DetermineSpawnPoint);
    }

    private Vector3 DetermineSpawnPoint()
    {
        float valueBisection = 2f;

        float minX = _platform.position.x - (_platform.localScale.x / valueBisection);
        float maxX = _platform.position.x + (_platform.localScale.x / valueBisection);
        float minZ = _platform.position.z - (_platform.localScale.z / valueBisection);
        float maxZ = _platform.position.z + (_platform.localScale.z / valueBisection);

        return new Vector3(Random.Range(minX, maxX), _maxY, Random.Range(minZ, maxZ));
    }
}