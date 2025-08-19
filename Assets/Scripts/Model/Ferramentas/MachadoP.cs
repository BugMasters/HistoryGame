using Assets.Scripts.Enum;
using Assets.Scripts.Interface;
using System.Collections.Generic;
using UnityEngine;

public class MachadoPedra : MonoBehaviour, IFerramenta
{
    public string Nome { get; }
    public float DurabilidadeAtual { get; set; }
    public float DurabilidadeMaxima { get; }
    public float Dano { get; }

    public Dictionary<TipoRecurso, int> Receita { get; }

    public MachadoPedra()
    {
        Nome = "Machado de Pedra";
        DurabilidadeAtual = 50;
        DurabilidadeMaxima = 50;
        Dano = 2;

        Receita = new Dictionary<TipoRecurso, int>
        {
            { TipoRecurso.Madeira, 2 },
            { TipoRecurso.Pedra, 3 }
        };
    }
}
