using UnityEngine;
using UnityEngine.UIElements;

public class JogadorScript : MonoBehaviour
{
    #region :: Atributos ::
    [SerializeField]
    private float Velocidade;

    [SerializeField]
    private Rigidbody2D Rigid;

    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private GameObject HUD;

    private bool Move = true;

    private Vector2 Position;

    public GameObject[] Inventario;

    #endregion :: Atributos ::

    void Update()
    {
        Movimentacao();
    }

    void FixedUpdate()
    {
        Vector3 MovePosition = (Velocidade * Time.fixedDeltaTime * Position.normalized) + Rigid.position;
        Rigid.MovePosition(MovePosition);
    }

    void Movimentacao()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

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

    public void CanMove()
    {
        Move = !Move;
    }
}
