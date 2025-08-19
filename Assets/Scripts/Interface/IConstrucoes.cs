using Assets.Scripts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IConstrucoes : IFabricaveis
    {
        string Nome { get; }
        string Descricao { get; }
        GameObject Prefab { get; }
        Dictionary<TipoRecurso, int> Receita { get; }
    }
}
