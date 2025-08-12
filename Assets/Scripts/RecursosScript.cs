using UnityEngine;

public class RecursosScript : MonoBehaviour
{
    // Conforme o jogo for crescendo, basta adicionar um novo recurso aqui
    [SerializeField]
    public int Frutas = 0;

    [SerializeField] 
    public int Madeira = 0;

    [SerializeField]
    public int Ferro = 0;

    [SerializeField]
    public RecursosHUD Hud;

    void Start()
    {
        Atualizar();
    }

    public void RecursoColetado(int pIdRecurso, int pQuantidade)
    {
        switch (pIdRecurso)
        {
            case 1:
                Frutas += pQuantidade;
                break;
            case 2:
                Madeira += pQuantidade;
                break;
            case 3:
                Ferro += pQuantidade;
                break;
        }

        Atualizar();
    }

    public void RecursosUtilizado(int pIdRecurso, int pQuantidade)
    {
        switch (pIdRecurso)
        {
            case 1:
                Frutas -= pQuantidade;
                break;
            case 2:
                Madeira -= pQuantidade;
                break;
            case 3:
                Ferro -= pQuantidade;
                break;
        }

        Atualizar();
    }

    private void Atualizar()
    {
        Hud.Atualizar(Madeira, Frutas);
    }
}
