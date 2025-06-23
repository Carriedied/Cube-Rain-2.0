using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IPoolable<T> where T : MonoBehaviour
    {
        event Action<T> Release;
    }
}
