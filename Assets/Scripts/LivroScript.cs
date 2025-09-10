using Assets.Scripts.Enum;
using Assets.Scripts.Model;
using Assets.Scripts.Model.Livro;
using System.Collections.Generic;
using System.Linq;
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
    private GameObject Prefacio;

    [SerializeField]
    private ListaPaginas Paginas;

    [SerializeField]
    private Sprite Desconhecido;

    [SerializeField]
    private TextMeshProUGUI TextoPaginaAtual;

    #region :: Dados da Página ::

    [Header("Infos da Página")]
    [SerializeField] private Image Icone;
    [SerializeField] private TextMeshProUGUI Titulo;
    [SerializeField] private TextMeshProUGUI Descricao;
    [SerializeField] private TextMeshProUGUI Fato1;
    [SerializeField] private TextMeshProUGUI Fato2;
    [SerializeField] private TextMeshProUGUI Fato3;

    #endregion

    #region :: Prefácio ::

    [SerializeField] private Image[] Icones;
    [SerializeField] private TextMeshProUGUI[] Titulos;
    [SerializeField] private GameObject[] Molduras;

    private List<Pagina> ListaAuxiliar;

    private int AuxIndice = 0;

    private TipoInformacao TipoAtual;

    #endregion

    #region :: Setas ::

    [SerializeField] private GameObject[] Setas;

    #endregion

    private bool EhPagina = false;

    private int PaginaAtual = 0;

    void OnEnable()
    {
        Pagina.SetActive(false);
        Setas[0].SetActive(false);
        Setas[1].SetActive(false);
        AlterarPrefacio(TipoInformacao.Construcao);
    }

    void Update()
    {
        TrocarPagina();
    }

    private void PlayAnimationOnce()
    {
        animator.SetTrigger("PlayOnce");
    }

    #region :: Manipulação de Páginas ::

    private void AtualizarDadosPagina()
    {
        Icone.sprite = ListaAuxiliar[PaginaAtual].Icone;
        Titulo.text = ListaAuxiliar[PaginaAtual].Nome;
        Descricao.text = ListaAuxiliar[PaginaAtual].Descricao;
        Fato1.text = ListaAuxiliar[PaginaAtual].Fato1;
        Fato2.text = ListaAuxiliar[PaginaAtual].Fato2;
        Fato3.text = ListaAuxiliar[PaginaAtual].Fato3;
    }

    private void AlterarPagina()
    {
        EhPagina = true;
        Pagina.SetActive(false);
        Setas[0].SetActive(false);
        Setas[1].SetActive(false);
        AtualizarDadosPagina();
        PlayAnimationOnce();
        Setas[0].SetActive(true);
        Setas[1].SetActive(true);
    }

    #endregion

    #region :: Manipulação de Prefácio ::

    private void AtualizarDadosPrefacio()
    {
        for (int i = 0; i < Icones.Length; i++)
        {
            if (ListaAuxiliar.Count >= i + 1)
            {
                if (ListaAuxiliar[i].Liberado)
                {
                    Icones[i].sprite = ListaAuxiliar[i].Icone;
                    Titulos[i].text = ListaAuxiliar[i].Nome;
                }
                else
                {
                    Icones[i].sprite = Desconhecido;
                    Titulos[i].text = "???";
                }
            }
            else
            {
                Molduras[i].SetActive(false);
            }
        }
    }

    private void AtualizarListaAuxiliar(TipoInformacao Tipo)
    {
        ListaAuxiliar = Paginas.ListPaginas.Where(p => p.Tipo == Tipo).ToList(); // Filtra pelo tipo

        if (ListaAuxiliar.Count > PaginaAtual) // Verifica se ele possui itens, baseado na página de navegação do player
        {
            ListaAuxiliar = ListaAuxiliar.Skip(PaginaAtual).ToList();
        }

        if (ListaAuxiliar.Count >= 8) // Verifica se possui 8 ou mais itens
        {
            ListaAuxiliar = ListaAuxiliar.Take(8).ToList();
        }
    }

    public void AlterarPrefacio(TipoInformacao Tipo)
    {
        EhPagina = false;
        TipoAtual = Tipo;
        Prefacio.SetActive(false);
        Pagina.SetActive(false);
        AtualizarListaAuxiliar(Tipo);
        AtualizarDadosPrefacio();
        AlterarTituloPrefacio(Tipo);
        PlayAnimationOnce();
    }

    #endregion

    private void TrocarPagina()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(PaginaAtual < Paginas.ListPaginas.Count - 1)
            {
                PaginaAtual++;
                AlterarPaginaAtivada();
            }

            if(PaginaAtual + 1 == Paginas.ListPaginas.Count)
            {
                EstadoSetas(0, true);
            }
            else
            {
                EstadoSetas(0, false);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(PaginaAtual > 0)
            {
                PaginaAtual--;
                AlterarPaginaAtivada();
            }

            if (PaginaAtual - 1 == 0)
            {
                EstadoSetas(1, true);
            }
            else
            {
                EstadoSetas(1, false);
            }
        }
    }

    private void AlterarPaginaAtivada()
    {
        if (EhPagina)
        {
            AlterarPagina();
        }
        else
        {
            AlterarPrefacio(TipoAtual);
        }
    }

    private void EstadoSetas(int Seta, bool Estado)
    {
        Setas[Seta].SetActive(Estado);
    }


    public void AlterarDePrefacioParaPagina(int pNumPagina)
    {
        PaginaAtual = pNumPagina + AuxIndice;
        Prefacio.SetActive(false);
        AlterarPagina();
    }

    private void AlterarTituloPrefacio(TipoInformacao Tipo)
    {
        switch (Tipo)
        {
            case TipoInformacao.Construcao:
                TextoPaginaAtual.text = "Construções";
                break;
            case TipoInformacao.Ferramenta:
                TextoPaginaAtual.text = "Ferramentas";
                break;
            case TipoInformacao.Recurso:
                TextoPaginaAtual.text = "Recursos";
                break;
        }
    }

    private void TerminouAnimacao()
    {
        if (EhPagina)
        {
            Pagina.SetActive(true);
        }
        else
        {
            Prefacio.SetActive(true);
        }
    }
}
