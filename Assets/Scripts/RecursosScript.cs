using UnityEngine;

public class RecursosScript : MonoBehaviour
{
    // Conforme o jogo for crescendo, basta adicionar um novo recurso aqui
    [SerializeField]
    private int Frutas = 0;

    [SerializeField] 
    private int Madeira = 0;

    [SerializeField]
    private int Ferro = 0;

    [SerializeField]
    private RecursosHUD Hud;

    void Start()
    {
        Atualizar();
    }

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

        Atualizar();
    }

    private void Atualizar()
    {
        Hud.Atualizar(Madeira, Frutas);
    }
}
