using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{

    private void Update()
    {
        transform.position = transform.position + GameManager.Single.Speed * Time.deltaTime * Vector3.down;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -GameManager.Single.RightUpperCorner.y)
        {
            Destroy(gameObject);
            GameManager.Single.Lives--;
        }
    }
}
