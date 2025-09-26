using UnityEngine;

public class InteragiveisScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites;

    [SerializeField]
    private GameObject HUD;

    private SpriteRenderer Renderer;

    private bool PlayerPerto;

    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {
        AbrirHud();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Renderer.sprite = Sprites[1];
            PlayerPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Renderer.sprite = Sprites[0];
            PlayerPerto = false;
        }
    }
}
