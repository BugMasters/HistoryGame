using UnityEngine;

public class JogadorScript : MonoBehaviour
{
    #region :: Atributos ::
    [SerializeField]
    private float Velocidade;

    private Rigidbody2D Rigid;

    private Animator AnimacaoMovimento;

    private string AnimacaoAuxiliar;

    #endregion :: Atributos ::

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        AnimacaoMovimento = GetComponent<Animator>();
    }

    void Update()
    {
        Movimentacao();
    }

    #region :: Eventos ::

    #endregion :: Eventos ::

    #region :: Métodos ::

    void Movimentacao()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(MoveX, MoveY).normalized;
        Rigid.MovePosition(Rigid.position + moveDir * Velocidade * Time.deltaTime);

        AnimacaoMovimento.SetBool("LadoWalk", false);
        AnimacaoMovimento.SetBool("CimaWalk", false);
        AnimacaoMovimento.SetBool("BaixoWalk", false);

        if (MoveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f);
            AnimacaoMovimento.SetBool("LadoWalk", true);
        }
        else if (MoveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f);
            AnimacaoMovimento.SetBool("LadoWalk", true);
        }
        else if (MoveY > 0)
        {
            AnimacaoMovimento.SetBool("CimaWalk", true);
        }
        else if (MoveY < 0)
        {
            AnimacaoMovimento.SetBool("BaixoWalk", true);
        }
    }



    #endregion :: Métodos ::
}
