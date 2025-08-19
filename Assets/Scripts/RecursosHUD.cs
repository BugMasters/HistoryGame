using Assets.Scripts.Enum;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecursosHUD : MonoBehaviour
{
    [Header("Recursos")]
    [SerializeField] private TextMeshProUGUI Frutas;
    [SerializeField] private TextMeshProUGUI Madeira;
    //[SerializeField] private TextMeshProUGUI Ferro;
    //[SerializeField] private TextMeshProUGUI Pedra;

    public void Atualizar(Dictionary<TipoRecurso, int> Recursos)
    {
        Frutas.text = $"x{Recursos[TipoRecurso.Fruta]}";
        Madeira.text = $"x{Recursos[TipoRecurso.Madeira]}";
        //Ferro.text = $"x{Recursos[TipoRecurso.Ferro]}";
        //Pedra.text = $"x{Recursos[TipoRecurso.Pedra]}";
    }
}
