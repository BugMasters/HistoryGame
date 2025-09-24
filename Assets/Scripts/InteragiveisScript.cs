using Assets.Scripts.Enum;
using System;
using UnityEngine;

public class InteragiveisScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites;

    private SpriteRenderer Renderer;

    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Renderer.sprite = Sprites[1];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Renderer.sprite = Sprites[0];
        }
    }
}
