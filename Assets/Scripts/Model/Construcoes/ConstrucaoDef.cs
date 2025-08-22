using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Enum;
using Assets.Scripts.Interface;

[CreateAssetMenu(fileName = "ConstrucaoDef", menuName = "Construcoes/NovaConstrucao")]
public class ConstrucaoDef : ScriptableObject, IConstrucoes
{
    [SerializeField] private string nome;
    [SerializeField] private string descricao;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<TipoRecursoQuantidade> receitaLista;

    public string Nome => nome;
    public string Descricao => descricao;
    public GameObject Prefab => prefab;

    public Dictionary<TipoRecurso, int> Receita
    {
        get
        {
            var dict = new Dictionary<TipoRecurso, int>();
            foreach (var item in receitaLista)
                dict[item.tipo] = item.quantidade;
            return dict;
        }
    }
}

[System.Serializable]
public struct TipoRecursoQuantidade
{
    public TipoRecurso tipo;
    public int quantidade;
}
