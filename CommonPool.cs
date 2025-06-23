using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Assembly_CSharp
{
    public class CommonPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
    {
        [SerializeField] private T _prefabObject;
        [SerializeField] private int _poolCapacity = 10;
        [SerializeField] private int _poolMaxSize = 20;

        private ObjectPool<T> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: CreateItem,
                actionOnGet: ActivateItem,
                actionOnRelease: DeactivateItem,
                actionOnDestroy: DestroyItem,
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
            );
        }

        public void ReleaseItem(T item)
        {
            item.OnRelease -= ReleaseItem;
            _pool.Release(item);
        }

        public T GetItem()
        {
            return _pool.Get();
        }

        private T CreateItem()
        {
            return Instantiate(_prefabObject);
        }

        private void ActivateItem(T item)
        {
            item.OnRelease += ReleaseItem;
            item.gameObject.SetActive(true);
        }

        private void DeactivateItem(T item)
        {
            item.gameObject.SetActive(false);
        }

        private void DestroyItem(T item)
        {
            Destroy(item.gameObject);
        }
    }
}
