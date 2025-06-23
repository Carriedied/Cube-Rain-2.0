using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Color InitialColor;

    private Renderer _renderer;

    private float _fullAlpha = 1f; 

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        InitialColor = _renderer.material.color;
    }

    public void BackToInitialColor()
    {
        _renderer.material.color = InitialColor;
    }

    public void ChangeColor()
    {
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    public Coroutine StartFadeOut(Action fadeComplete, float duration)
    {
        return StartCoroutine(FadeOutCoroutine(fadeComplete, duration));
    }

    private IEnumerator FadeOutCoroutine(Action onFadeComplete, float duration)
    {
        Color startColor = _renderer.material.color;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float time = elapsed / duration;

            Color newColor = new Color(startColor.r, startColor.g, startColor.b, _fullAlpha - time);
            
            _renderer.material.color = newColor;
            
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        onFadeComplete?.Invoke();
    }
}