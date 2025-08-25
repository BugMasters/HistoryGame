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

    private bool InHud = false;

    #endregion :: Atributos ::

    void Update()
    {
        if (Move)
        {
            Movimentacao();
        }

        Hud();
    }

    void FixedUpdate()
    {
        Vector3 MovePosition = (Velocidade * Time.fixedDeltaTime * Position.normalized) + Rigid.position;
        Rigid.MovePosition(MovePosition);
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
        if (collision.CompareTag("Bancada"))
        {
            InHud = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bancada"))
        {
            InHud = false;
        }
    }

    private void Hud()
    {
        if (InHud && UnityEngine.Input.GetKey(KeyCode.E))
        {
            Move = false;
        }
        else if (InHud && UnityEngine.Input.GetKey(KeyCode.Escape))
        {
            Move = true;
        }
    }
}
