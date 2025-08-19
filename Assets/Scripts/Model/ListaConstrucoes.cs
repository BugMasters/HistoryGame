using System.Collections.Generic;
using UnityEngine;

public class ListaConstrucoes : MonoBehaviour
{
    [SerializeField]
    private GameObject cabanaPrefab;

    private Dictionary<int, GameObject> construcoes;

    void Awake()
    {
        construcoes = new Dictionary<int, GameObject>()
        {
            { 1, cabanaPrefab }
        };
    }

    public GameObject GetConstrucaoPrefab(int id)
    {
        return construcoes[id];
    }
}
