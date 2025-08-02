using TMPro;
using UnityEngine;

public class RecursosHUD : MonoBehaviour
{
    [Header("Recursos")]
    [SerializeField]
    private TextMeshProUGUI Frutas;

    [SerializeField]
    private TextMeshProUGUI Madeira;

    public void Atualizar(int pMadeira, int pFrutas)
    {
        Frutas.text = $"x{pFrutas}";
        Madeira.text = $"x{pMadeira}";
    }
}
