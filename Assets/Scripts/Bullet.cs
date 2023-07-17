using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;

    bool _move;

    Collider2D _collider;
    BallMotion _ballMotion;
    private void Start()
    {
        _ballMotion = GetComponent<BallMotion>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_move)
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.up);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _move = false;

        if (collision.CompareTag(tag))
        {
            Destroy(collision.gameObject);
            GameManager.Single.Score++;
            Destroy(gameObject);
        }
        else
        {
            _collider.isTrigger = false;
            _ballMotion.enabled = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void StartMove()
    {
        _move = true;
        _collider.enabled = true;
    }
}
