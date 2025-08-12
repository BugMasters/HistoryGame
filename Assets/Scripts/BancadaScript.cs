using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BancadaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Painel;

    [SerializeField]
    private RecursosScript Recursos;

    [SerializeField]
    private JogadorScript Player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Painel.SetActive(!Painel.activeSelf);
        }
    }

    public void FabricarMachado()
    {
        if(Recursos.Madeira >= 2)
        {
            Recursos.RecursosUtilizado(2, 2);

            Player.Inventario.Append(new GameObject("Machado"));
        }
    }
}
