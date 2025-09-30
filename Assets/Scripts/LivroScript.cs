using Assets.Scripts.Model;
using TMPro;
using UnityEngine;

public class LivroScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject Pagina;

    [SerializeField]
    public ListaPaginas Paginas;

    [Header("Infos da Página")]
    [SerializeField] private TextMeshProUGUI Titulo;
    [SerializeField] private TextMeshProUGUI[] Descricao;

    private int PaginaAtual;

    void OnEnable()
    {
        PaginaAtual = 0;
        AlterarPagina();
    }

    void Update()
    {
        TrocarPagina();
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

    private void PlayAnimationOnce()
    {
        animator.SetTrigger("PlayOnce");
    }

    private void AtualizarDadosPagina()
    {
        Titulo.text = Paginas.ListPaginas[PaginaAtual].Nome;
        Descricao[0].text = Paginas.ListPaginas[PaginaAtual].Descricao[0];
        Descricao[1].text = Paginas.ListPaginas[PaginaAtual].Descricao[1];
    }

    private void AlterarPagina()
    {
        Pagina.SetActive(false);
        AtualizarDadosPagina();

        PlayAnimationOnce();
    }

    private bool VerificarTrocaPagina(bool Avancando)
    {
        if (Avancando && PaginaAtual + 1 < Paginas.ListPaginas.Count)
        {
            PaginaAtual++;
            return true;
        }
        else if (!Avancando && PaginaAtual != 0)
        {
            PaginaAtual--;
            return true;
        }

        return false;
    }

    public void TerminouAnimacao()
    {
        Pagina.SetActive(true);
    }
}
