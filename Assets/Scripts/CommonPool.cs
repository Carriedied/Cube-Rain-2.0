using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Pool;

public class CommonPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _initialSize = 10;
    [SerializeField] private int _poolMaxSize = 20;
    [SerializeField] private ObjectStatistics _statistics;

    public static event Action<T> OnItemReleased;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
        (
            createFunc: CreateObject,
            actionOnGet: ActivateObject,
            actionOnRelease: DeactivateObject,
            actionOnDestroy: DestroyObject,
            collectionCheck: true,
            defaultCapacity: _initialSize,
            maxSize: _poolMaxSize
        );
    }

    public void ReleaseObject(T item)
    {
        item.Release -= ReleaseObject;

        _pool.Release(item);

        _statistics.SetActive(_pool.CountActive);
    }

    public T GetObject()
    {
        return _pool.Get();
    }

    private T CreateObject()
    {
        _statistics.AddCreated();

        return Instantiate(_prefab);
    }

    private void ActivateObject(T item)
    {
        item.Release += ReleaseObject;

        item.gameObject.SetActive(true);

        _statistics.SetActive(_pool.CountActive);
        _statistics.AddSpawned();
    }

    private void DeactivateObject(T item)
    {
        item.gameObject.SetActive(false);

        _statistics.SetActive(_pool.CountActive);

        OnItemReleased?.Invoke(item);
    }

    private void DestroyObject(T item)
    {
        Destroy(item);

        _statistics.SetActive(_pool.CountActive);
    }
}