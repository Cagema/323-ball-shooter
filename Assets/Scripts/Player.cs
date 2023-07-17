using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Bullet _bullet;
    Vector2 _mousePos;
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButton(0))
            {
                _mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                _mousePos = new Vector2(Mathf.Clamp(_mousePos.x, -GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1), _mousePos.y);
                transform.position = new Vector3(_mousePos.x, transform.position.y, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_bullet)
                Shot();
            }
        }
        
    }

    private void Shot()
    {
        _bullet.StartMove();
        _bullet.transform.parent = null;
        _bullet = null;
        Invoke(nameof(SetNewBullet), 0.35f);
    }

    void SetNewBullet()
    {
        _bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, transform).GetComponent<Bullet>();
    }
}
