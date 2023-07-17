using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAndTags : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    private void Start()
    {
        int randomIndex = Random.Range(0, _sprites.Length);
        if (randomIndex < GameManager.Single.Tags.Length)
        {
            GetComponent<SpriteRenderer>().sprite = _sprites[randomIndex];
            tag = GameManager.Single.Tags[randomIndex];
        }
    }
}
