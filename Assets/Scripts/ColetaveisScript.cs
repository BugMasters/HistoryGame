using System;
using UnityEngine;

public class ColetaveisScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites; // Com recurso, sem recurso.

    [SerializeField]
    private int Recurso; // Representa o recurso do objeto que receber esse script

    [SerializeField]
    private int[] Quantidade; // Reprensenta o quanto de itens esse recurso pode droppar.

    [SerializeField]
    private RecursosScript RecursosControlador;

    private SpriteRenderer Renderer;

    private bool Coletavel;
 
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Coletavel = true;
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (Coletavel && Input.GetKeyDown(KeyCode.E))
            {
                Renderer.sprite = Sprites[1];
                Coletavel = false;
                RecursosControlador.RecursoColetado(Recurso, QuantidadeColetada());
            }
        }
    }

    private int QuantidadeColetada()
    {
        return UnityEngine.Random.Range(Quantidade[0], Quantidade[1]);
    }
}
