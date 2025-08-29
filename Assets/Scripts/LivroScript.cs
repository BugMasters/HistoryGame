using Assets.Scripts.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivroScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject Livro;

    [SerializeField]
    private GameObject Pagina;

    [SerializeField]
    private Image Icone;

    [SerializeField]
    private TextMeshProUGUI Titulo;

    [SerializeField]
    private TextMeshProUGUI Descricao;

    [SerializeField]
    private TextMeshProUGUI Fato1;

    [SerializeField]
    private TextMeshProUGUI Fato2;

    [SerializeField]
    private TextMeshProUGUI Fato3;

    [SerializeField]
    private ListaPaginas Paginas;

    private int PaginaAtual = 0;

    void OnEnable()
    {
        AlterarPagina();
    }

    void Update()
    {
        TrocarPagina();
    }

    private void PlayAnimationOnce()
    {
        animator.SetTrigger("PlayOnce");
    }

    private void TrocarPagina()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(PaginaAtual < Paginas.ListPaginas.Count - 1)
            {
                PaginaAtual++;
                AlterarPagina();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(PaginaAtual > 0)
            {
                PaginaAtual--;
                AlterarPagina();
            }
        }
    }

    private void AtualizarDadosPagina()
    {
        Icone.sprite = Paginas.ListPaginas[PaginaAtual].Icone;
        Titulo.text = Paginas.ListPaginas[PaginaAtual].Nome;
        Descricao.text = Paginas.ListPaginas[PaginaAtual].Descricao;
        Fato1.text = Paginas.ListPaginas[PaginaAtual].Fato1;
        Fato2.text = Paginas.ListPaginas[PaginaAtual].Fato2;
        Fato3.text = Paginas.ListPaginas[PaginaAtual].Fato3;
    }

    private void AlterarPagina()
    {
        Pagina.SetActive(false);
        AtualizarDadosPagina();
        PlayAnimationOnce();
    }

    private void TerminouAnimacao()
    {
        Pagina.SetActive(true);
    }
}
