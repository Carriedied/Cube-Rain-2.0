using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour, IPoolable<Bomb>
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _explosionLayerMask;

    public event Action<Bomb> Release;

    private Coroutine _fadeCoroutine;
    private ColorChanger _colorChanger;
    private Renderer _renderer;

    private float _minTimeExplode = 2;
    private float _maxTimeExplode = 5;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Reset();
        StartFading();
    }

    public void Reset()
    {
        _renderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _renderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        _renderer.material.SetInt("_ZWrite", 0);
        _renderer.material.DisableKeyword("_ALPHATEST_ON");
        _renderer.material.EnableKeyword("_ALPHABLEND_ON");
        _renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        _renderer.material.renderQueue = 3000;

        _renderer.material.color = Color.black;
    }

    public void StartFading()
    {
        if (_fadeCoroutine != null) return;

        float duration = UnityEngine.Random.Range(_minTimeExplode, _maxTimeExplode);

        _fadeCoroutine = _colorChanger.StartFadeOut(Explode, duration);
    }

    private void Explode()
    {
        _fadeCoroutine = null;

        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, _explosionRadius, _explosionLayerMask);

        foreach (Collider item in nearbyObjects)
        {
            if (item.TryGetComponent<Rigidbody>(out Rigidbody physicalProperty))
            {
                physicalProperty.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        Release?.Invoke(this);
    }
}
