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
        AlterarEtiquetaPrefacio(TipoInformacao.Construcao);
    }

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
        Icone.sprite = ListaAuxiliar[PaginaAtual].Icone;
        Titulo.text = ListaAuxiliar[PaginaAtual].Nome;
        Descricao.text = ListaAuxiliar[PaginaAtual].Descricao;
        Fato1.text = ListaAuxiliar[PaginaAtual].Fato1;
        Fato2.text = ListaAuxiliar[PaginaAtual].Fato2;
        Fato3.text = ListaAuxiliar[PaginaAtual].Fato3;
    }

    private void AtualizarDadosPrefacio()
    {
        for (int i = 0; i < Icones.Length; i++)
        {
            if (ListaAuxiliar.Count >= i + 1)
            {
                Molduras[i].SetActive(true);

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

    private void AlterarPagina()
    {
        EhPagina = true;
        Pagina.SetActive(false);
        AtualizarDadosPagina();
        PlayAnimationOnce();
    }

    public void AlterarEtiquetaPrefacio(TipoInformacao Tipo)
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

    public void AlterarDePrefacioParaPagina(int pNumPagina)
    {
        PaginaAtual = pNumPagina + AuxIndice;
        Prefacio.SetActive(false);
        AlterarPagina();
        VerificaSetasAtivadas();
    }

    private bool VerificarTrocaPagina(bool Avancando)
    {
        if (EhPagina)
        {
            if(PaginaAtual < ListaAuxiliar.Count - 1)
            {
                if (Avancando)
                {
                    PaginaAtual++;
                }
                else
                {
                    PaginaAtual--;
                }

                return true;
            }
        }
        else
        {
            if(Paginas.ListPaginas.Where(p => p.Tipo == TipoAtual).Count() > 8)
            {
                if (Avancando)
                {
                    PaginaAtual += 8;
                }
                else
                {
                    PaginaAtual -= 8;
                }

                return true;
            }
        }

        return false;
    }

    private void AtualizarListaAuxiliar(TipoInformacao Tipo)
    {
        ListaAuxiliar = Paginas.ListPaginas.Where(p => p.Tipo == Tipo).ToList(); // Filtra pelo tipo

        if (ListaAuxiliar.Count >= 8) // Verifica se ele possui itens, baseado na página de navegação do player
        {
            ListaAuxiliar = ListaAuxiliar.Skip(PaginaAtual).ToList(); 
        }

        if (ListaAuxiliar.Count >= 8) // Verifica se possui 8 ou mais itens
        {
            ListaAuxiliar = ListaAuxiliar.Take(8).ToList();
        }
    }

    private void TrocarPagina()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(VerificarTrocaPagina(true))
            {
                AlterarPaginaAtivada();
            }

            VerificaSetasAtivadas();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (VerificarTrocaPagina(true))
            {
                AlterarPaginaAtivada();
            }

            VerificaSetasAtivadas();
        }
    }

    void VerificaSetasAtivadas()
    {
        if (ListaAuxiliar.Count > 1)
        {
            if(PaginaAtual > 0)
            {
                EstadoSetas(1, true);
            }
            else
            {
                EstadoSetas(1, false);
            }


            if (PaginaAtual != ListaAuxiliar.Count - 1)
            {
                EstadoSetas(0, true);
            }
            else
            {
                EstadoSetas(0, false);
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
            AlterarEtiquetaPrefacio(TipoAtual);
        }
    }

    private void EstadoSetas(int Seta, bool Estado)
    {
        Setas[Seta].SetActive(Estado);
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
