using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ListaConstrucoes : MonoBehaviour
{
    [SerializeField] 
    private List<ConstrucaoDef> construcoes;

    private Dictionary<int, ConstrucaoDef> mapa;

    void Awake()
    {
        mapa = new Dictionary<int, ConstrucaoDef>();
        for (int i = 0; i < construcoes.Count; i++)
        {
            mapa[i + 1] = construcoes[i];
        }
    }

    public IConstrucoes GetConstrucao(int id) => mapa[id];
}
