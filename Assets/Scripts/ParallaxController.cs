using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    [SerializeField] private float _animationSpeed = 0.05f;
    private MeshRenderer _meshRenderer;


    private void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
    }


}
