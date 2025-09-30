using UnityEngine;

public class InteragiveisScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites;

    [SerializeField]
    private GameObject HUD;

    private SpriteRenderer Renderer;

    private bool PlayerPerto;

    [SerializeField]
    private bool AtivarHud;

    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {
        if (AtivarHud)
        {
            AbrirHud();
        }

        TrocarSprite();
    }

    void AbrirHud()
    {
        if (PlayerPerto && HUD != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HUD.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HUD.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerPerto = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerPerto = false;
        }
    }

    private void TrocarSprite()
    {
        if (PlayerPerto)
        {
            Renderer.sprite = Sprites[1];
        }
        else
        {
            Renderer.sprite = Sprites[0];
        }
    }
}
