using Assets.Scripts.Model;
using System.Collections.Generic;
using UnityEngine;

public class PaginasScript : MonoBehaviour
{
    [SerializeField]
    private ListaPaginas ListaPaginas;

    [SerializeField]
    private LivroScript Livro;

    [SerializeField]
    private GameObject LivroHud;

    private bool PlayerPerto;

    void Update()
    {
        AtribuirPaginas();
    }

    void AtribuirPaginas()
    {
        if (PlayerPerto)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Livro.Paginas = ListaPaginas;
                LivroHud.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerPerto = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerPerto = false;
        }
    }

}
