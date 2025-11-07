using UnityEngine;

public class JogadorScript : MonoBehaviour
{
    #region :: Atributos ::
    [Header("Configurações de Movimento")]
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Animator animator;
    [SerializeField] private RectTransform AreaAtaque;
    [SerializeField] private BoxCollider2D AreaAtaqueCollider;

    private SpriteRenderer sprite;
    private Vector2 direcao;

    private Vector2 posicaoAtaqueA;
    private Vector2 posicaoAtaqueB;

    [Header("Outros")]
    public GameObject[] inventario;

    private bool podeMover = true;
    private bool colidindo = false;
    private bool atacando = false;
    #endregion

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        posicaoAtaqueA = new Vector2(1, AreaAtaque.anchoredPosition.y);
        posicaoAtaqueB = new Vector2(-1, AreaAtaque.anchoredPosition.y);

        AreaAtaqueCollider.enabled = false;
    }

    private void Update()
    {
        if (podeMover && !atacando)
            LerMovimento();

        if (!atacando)
            DetectarAtaque();

        AbrirHud();
    }

    private void FixedUpdate()
    {
        if (podeMover && !atacando)
            Mover();
    }

    #region :: Movimento ::
    private void LerMovimento()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direcao = new Vector2(moveX, moveY);

        // Inverter sprite apenas quando se move horizontalmente
        if (moveX != 0)
        {
            bool inverter = moveX < 0;
            sprite.flipX = inverter;

            if (inverter)
            {
                AreaAtaque.anchoredPosition = posicaoAtaqueB;
            }
            else
            {
                AreaAtaque.anchoredPosition = posicaoAtaqueA;
            }
        }
    }

    private void Mover()
    {
        Vector2 novaPosicao = rigid.position + direcao * velocidade * Time.fixedDeltaTime;
        rigid.MovePosition(novaPosicao);
    }

    #endregion

    #region :: HUD ::
    private void AbrirHud()
    {
        if (!colidindo) return;

        if (Input.GetKeyDown(KeyCode.E))
            podeMover = false;

        if (Input.GetKeyDown(KeyCode.Escape))
            podeMover = true;
    }
    #endregion

    #region :: Ataque ::
    private void DetectarAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(ExecutarAtaque());
        }
    }

    private System.Collections.IEnumerator ExecutarAtaque()
    {
        atacando = true;
        podeMover = false;
        AreaAtaqueCollider.enabled = true;

        animator.SetTrigger("Atacou");

        // Espera o tempo da animação (ajuste conforme a duração)
        yield return new WaitForSeconds(0.3f);

        AreaAtaqueCollider.enabled = false;
        atacando = false;
        podeMover = true;
    }
    #endregion

    public void Morrer()
    {
        podeMover = false;
        animator.SetTrigger("Morreu");
    }

    #region :: Colisões ::
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporte"))
            podeMover = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporte"))
            podeMover = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Colidivel"))
            colidindo = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Colidivel"))
            colidindo = false;
    }
    #endregion
}
