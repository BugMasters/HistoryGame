using Assets.Scripts.Enum;
using System;
using UnityEngine;

public class ColetaveisScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites; // Com recurso, sem recurso.

    [SerializeField]
    private TipoRecurso TipoRecurso; // Representa o recurso do objeto que receber esse script

    [SerializeField]
    private int[] Quantidade; // Reprensenta o quanto de itens esse recurso pode droppar.

    [SerializeField]
    private Inventario RecursosControlador;

    [SerializeField]
    private SpriteRenderer Renderer;

    private bool Coletavel = true;

    private bool PlayerPerto = false;

    private void Update()
    {
        Coletar();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPerto = false;
        }
    }

    private void Coletar()
    {
        if (PlayerPerto && Coletavel && Input.GetKeyDown(KeyCode.E))
        {
            Renderer.sprite = Sprites[1];
            Coletavel = false;
            RecursosControlador.Adicionar(TipoRecurso, QuantidadeColetada());
        }
    }

    private int QuantidadeColetada()
    {
        return UnityEngine.Random.Range(Quantidade[0], Quantidade[1]);
    }
}
