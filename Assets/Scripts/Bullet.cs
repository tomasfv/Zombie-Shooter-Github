using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 || screenPosition.y > _camera.pixelHeight)
        {
            gameObject.SetActive(false);
        }
    }
}
