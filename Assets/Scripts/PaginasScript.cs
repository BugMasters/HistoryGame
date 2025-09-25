using Assets.Scripts.Model;
using System.Collections.Generic;
using UnityEngine;

public class PaginasScript : MonoBehaviour
{
    [SerializeField]
    private ListaPaginas[] ListaPaginas;

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
                ListaPaginas[1].ListPaginas = new List<Assets.Scripts.Model.Livro.Pagina>(ListaPaginas[0].ListPaginas);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPerto = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPerto = false;
    }

}
