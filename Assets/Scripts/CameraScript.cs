using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Vector3 RelacaoPlayer; // Distância

    [SerializeField]
    private float Velocidade = 0.125f;

    [SerializeField]
    private bool Seguir;



    void Start()
    {
        Seguir = true;
    }

    void LateUpdate() // Executa após o Update
    {
        SeguirPlayer();
    }

    void SeguirPlayer()
    {
        if (Seguir && Player != null)
        {
            Vector3 PosicaoJogador = Player.position + RelacaoPlayer;

            // Suaviza a movimentação da câmera.
            Vector3 Suavizacao = Vector3.Lerp(transform.position, PosicaoJogador, Velocidade);
            transform.position = new Vector3(Suavizacao.x, Suavizacao.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ParedeInvisivel"))
        {
            Seguir = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ParedeInvisivel"))
        {
            Seguir = true;
        }
    }
}
