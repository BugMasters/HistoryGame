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

    private List<Pagina> ListaAuxiliar;

    private int AuxIndice = 0;

    #endregion

    private bool EhPagina = false;

    private int PaginaAtual = 0;

    void OnEnable()
    {
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

    private void AtualizarDadosPrefacio()
    {
        for (int i = 0; i < Icones.Count(); i++)
        {
            if(ListaAuxiliar.Count >= i)
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
                Icones[i].sprite = Desconhecido;
                Titulos[i].text = "???";
            }
        }
    }

    private void AtualizarListaAuxiliar(TipoInformacao Tipo)
    {
        ListaAuxiliar = Paginas.ListPaginas.Where(p => p.Tipo == Tipo).ToList(); // Filtra pelo tipo

        if(ListaAuxiliar.Count > PaginaAtual) // Verifica se ele possui itens, baseado na página de navegação do player
        {
            ListaAuxiliar = ListaAuxiliar.Skip(PaginaAtual).ToList();
        }
        
        if(ListaAuxiliar.Count >= 8) // Verifica se possui 8 ou mais itens
        {
            ListaAuxiliar = ListaAuxiliar.Take(8).ToList();
        }
    }

    private void AlterarPagina()
    {
        EhPagina = true;
        Pagina.SetActive(false);
        AtualizarDadosPagina();
        PlayAnimationOnce();
    }

    public void AlterarPrefacio(TipoInformacao Tipo)
    {
        EhPagina = false;
        Prefacio.SetActive(false);
        AtualizarListaAuxiliar(Tipo);
        AtualizarDadosPrefacio();
        PlayAnimationOnce();
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
