
using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private List<ParallaxLayer> _layers;
    private Vector2 _meshOffset;

    private void Start()
    {
        foreach (var layer in _layers)
        {
            _meshOffset = layer.MeshRenderer.sharedMaterial.mainTextureOffset;
        }
    }
    private void OnDisable()
    {
        foreach (var layer in _layers)
        {
            layer.MeshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
        }
    }
    private void Update()
    {
        foreach (var layer in _layers)
        {
            var x = Mathf.Repeat(Time.time * layer.Speed, 1);
            var offset = new Vector2(x, _meshOffset.y);
            layer.MeshRenderer.sharedMaterial.mainTextureOffset = offset;
        }

    }
    [Serializable]
    private class ParallaxLayer
    {
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}
