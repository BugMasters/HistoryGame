using Unity.VisualScripting;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Molduras;

    [SerializeField]
    private GameObject[] Quadros;

    [SerializeField]
    private GameObject Estante;

    private bool Conseguiu = false;

    private Vector3 Final;

    void Awake()
    {
        Final = new Vector3(Estante.transform.position.x - 2, Estante.transform.position.y, 0f);
    }

    void Update()
    {
        if (!Conseguiu)
        {
            AbrirCaminho();
        }
    }

    void AbrirCaminho()
    {
        if (ValidaPuzzle())
        {
            Estante.transform.position =  Vector3.MoveTowards(Estante.transform.position, Final, 2f * Time.deltaTime);

            if (Estante.transform.position == Final)
            {
                Conseguiu = true;
            }
        }
    }

    private bool ValidaPuzzle()
    {
        if (!Conseguiu)
        {
            if (Molduras[0].transform.position != Quadros[2].transform.position)
            {
                return false;
            }

            if (Molduras[1].transform.position != Quadros[0].transform.position)
            {
                return false;
            }

            if (Molduras[2].transform.position != Quadros[1].transform.position)
            {
                return false;
            }
        }

        return true;
    }
}
