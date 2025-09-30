using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class JogadorScript : MonoBehaviour
{
    #region :: Atributos ::
    [SerializeField]
    private float Velocidade;

    [SerializeField]
    private Rigidbody2D Rigid;

    [SerializeField]
    private Animator Animator;

    private Vector2 Position;

    public GameObject[] Inventario;

    private bool Move = true;

    private bool Colidindo = false;

    #endregion :: Atributos ::

    void Update()
    {
        if (Move)
        {
            Movimentacao();
        }

        AbrirHud();
    }

    void FixedUpdate()
    {
        if (Move)
        {
            Vector3 MovePosition = (Velocidade * Time.fixedDeltaTime * Position.normalized) + Rigid.position;
            Rigid.MovePosition(MovePosition);
        }
    }

    void Movimentacao()
    {
        float MoveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float MoveY = UnityEngine.Input.GetAxisRaw("Vertical");

        Position = new Vector2(MoveX, MoveY);

        if(Position != Vector2.zero)
        {
            Animator.SetFloat("Horizontal", MoveX);
            Animator.SetFloat("Vertical", MoveY);

            Animator.SetBool("Walk", true);
        }
        else
        {
            Animator.SetBool("Walk", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporte"))
        {
            Move = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporte"))
        {
            Move = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Colidivel"))
        {
            Colidindo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Colidivel"))
        {
            Colidindo = false;
        }
    }

    private void AbrirHud()
    {
        if (Colidindo)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                Move = false;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                Move = true;
            }
        }
    }
}
