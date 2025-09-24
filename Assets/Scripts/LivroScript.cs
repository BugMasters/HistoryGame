using Assets.Scripts.Enum;
using Assets.Scripts.Model;
using System.Linq;
using TMPro;
using UnityEngine;

public class LivroScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject Livro;

    [SerializeField]
    private GameObject Pagina;

    [SerializeField]
    private GameObject Prefacio;

    [SerializeField]
    private ListaPaginas Paginas;

    [SerializeField]
    private TextMeshProUGUI TextoPaginaAtual;

    #region :: Dados da Página ::

    [Header("Infos da Página")]
    [SerializeField] private TextMeshProUGUI Titulo;
    [SerializeField] private TextMeshProUGUI Descricao;

    #endregion

    private int PaginaAtual = 0;

    void Update()
    {
        TrocarPagina();
    }

    private void PlayAnimationOnce()
    {
        animator.SetTrigger("PlayOnce");
    }

    private void AtualizarDadosPagina()
    {
        Titulo.text = Paginas.ListPaginas[PaginaAtual].Nome;
        Descricao.text = Paginas.ListPaginas[PaginaAtual].Descricao;
    }

    private void AlterarPagina()
    {
        Pagina.SetActive(false);
        AtualizarDadosPagina();
        PlayAnimationOnce();
    }

    private bool VerificarTrocaPagina(bool Avancando)
    {
        if (PaginaAtual < Paginas.ListPaginas.Count - 1)
        {
            if (Avancando)
            {
                PaginaAtual++;
            }
            else if (PaginaAtual != 0)
            {
                PaginaAtual--;
            }

            return true;
        }

        return false;
    }

    private void TrocarPagina()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (VerificarTrocaPagina(true))
            {
                AlterarPagina();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (VerificarTrocaPagina(false))
            {
                AlterarPagina();
            }
        }
    }

    private void TerminouAnimacao()
    {
        Pagina.SetActive(true);
    }
}
