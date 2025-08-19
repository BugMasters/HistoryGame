using Assets.Scripts.Enum;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private Dictionary<TipoRecurso, int> recursos = new Dictionary<TipoRecurso, int>()
    {
        { TipoRecurso.Fruta, 0 },
        { TipoRecurso.Madeira, 0 },
        { TipoRecurso.Ferro, 0 },
        { TipoRecurso.Pedra, 0 }
    };

    [SerializeField] 
    private RecursosHUD hud;

    void Start()
    {
        AtualizarHUD();
    }

    public void Adicionar(TipoRecurso tipo, int quantidade)
    {
        recursos[tipo] += quantidade;
        AtualizarHUD();
    }

    public void Remover(TipoRecurso tipo, int quantidade)
    {
        recursos[tipo] = Mathf.Max(0, recursos[tipo] - quantidade);
        AtualizarHUD();
    }

    public bool Possui(TipoRecurso tipo, int quantidade)
    {
        return recursos.ContainsKey(tipo) && recursos[tipo] >= quantidade;
    }
    
    public bool PossuiTudo(Dictionary<TipoRecurso, int> receita)
    {
        foreach (var par in receita)
        {
            if (!Possui(par.Key, par.Value)) return false;
        }
        return true;
    }

    public void Consumir(Dictionary<TipoRecurso, int> receita)
    {
        foreach (var par in receita)
        {
            Remover(par.Key, par.Value);
        }
    }

    private void AtualizarHUD()
    {
        // Exemplo: passa os recursos pro HUD
        hud.Atualizar(recursos);
    }
}
