using Assets.Scripts.Enum;
using System.Collections.Generic;
using UnityEngine;

public interface IConstrucoes
{
    string Nome { get; }
    string Descricao { get; }
    GameObject Prefab { get; }
    Dictionary<TipoRecurso, int> Receita { get; }
}
