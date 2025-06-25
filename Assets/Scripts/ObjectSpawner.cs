using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

public abstract class ObjectSpawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
{
    [SerializeField] private CommonPool<T> _pool;

    private Func<Vector3> _spawnPositionProvider;
    private Coroutine _autoSpawnCoroutine;
    private WaitForSeconds _spawnTime = new WaitForSeconds(1f);

    public void SetSpawnPositionProvider(Func<Vector3> provider)
    {
        _spawnPositionProvider = provider;

        StartAutoSpawn();
    }

    public void SpawnAtPosition(Vector3 position)
    {
        T obj = _pool.GetObject();

        if (obj != null)
            obj.transform.position = position;
    }

    public void StartAutoSpawn()
    {
        if (_autoSpawnCoroutine != null)
            StopCoroutine(_autoSpawnCoroutine);

        _autoSpawnCoroutine = StartCoroutine(AutoSpawnRoutine());
    }

    private IEnumerator AutoSpawnRoutine()
    {
        while (true)
        {
            if (_spawnPositionProvider != null)
                SpawnAtPosition(_spawnPositionProvider());

            yield return _spawnTime;
        }
    }
}
