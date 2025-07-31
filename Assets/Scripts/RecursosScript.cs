using UnityEngine;

public class RecursosScript : MonoBehaviour
{
    // Conforme o jogo for crescendo, basta adicionar um novo recurso aqui
    [SerializeField]
    private int Frutas;

    [SerializeField] 
    private int Madeira;

    [SerializeField]
    private int Ferro;

    public void RecursoColetado(string pNomeRecurso, int pQuantidade)
    {
        switch (pNomeRecurso)
        {
            case "Frutas":
                Frutas += pQuantidade;
                break;
            case "Madeira":
                Madeira += pQuantidade;
                break;
            case "Ferro":
                Ferro += pQuantidade;
                break;
        }
    }
}
