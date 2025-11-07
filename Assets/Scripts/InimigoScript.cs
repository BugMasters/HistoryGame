using UnityEngine;
using UnityEngine.Rendering;

public class InimigoScript : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private Color corArea;

    [SerializeField]
    private Color corDirecao;

    [SerializeField]
    private float raioVisao;

    [SerializeField]
    private LayerMask layerArea;

    [SerializeField]
    PlayerVidaScript vida;

    private BoxCollider2D boxCollider;

    public int dano = 1;

    private int vidaInimigo = 2;

    private Rigidbody2D rigidbody;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private Transform alvo;

    private bool Vivo = true;

    private bool podeMover = true;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        vidaInimigo = 2;
        Vivo = true;
    }

    void Update()
    {
        if (!Vivo || !podeMover)
        {
            return;
        }

        ProcurarJogador();
        if(alvo != null)
        {
            Mover();
        }
        else
        {
            PararMovimentacao();
        }
    }

    private void Morreu()
    {
        if(vidaInimigo == 0)
        {
            Vivo = false;
            animator.SetTrigger("Morreu");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = corArea;
        Gizmos.DrawWireSphere(transform.position, raioVisao);

        if(alvo != null)
        {
            Gizmos.color = corDirecao;
            Gizmos.DrawLine(transform.position, alvo.position);
        }
    }

    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(transform.position, raioVisao, layerArea);

        if(colisor != null)
        {
            Vector2 posicaoAtual = transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;

            direcao = direcao.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao, raioVisao, layerArea);

            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    alvo = hit.transform;
                }
                else
                {
                    alvo = null;
                }
            }
            else
            {
                alvo = null;
            }
        }
    }

    private void Mover()
    {
        Vector2 posicaoAlvo = alvo.position;
        Vector2 posicaoAtual = transform.position;

        float Distancia = Vector2.Distance(posicaoAlvo, posicaoAtual);

        if(Distancia <= distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            rigidbody.MovePosition(posicaoAtual + direcao * velocidade * Time.deltaTime);

            spriteRenderer.flipX = direcao.x < 0;

            animator.SetBool("Movendo", true);
        }
        else
        {
            PararMovimentacao();
        }
    }

    private void PararMovimentacao()
    {
        rigidbody.linearVelocity = Vector2.zero;
        animator.SetBool("Movendo", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (vida != null)
            {
                vida.LevarDano(dano);
            }
        }

        if (other.CompareTag("Arma"))
        {
            StartCoroutine(Dano());
        }
    }

    private System.Collections.IEnumerator Dano()
    {
        podeMover = false;
        boxCollider.enabled = false;

        vidaInimigo--;

        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.3f);

        boxCollider.enabled = true;
        podeMover = true;
    }
}
