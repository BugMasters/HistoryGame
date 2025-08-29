using Assets.Scripts.Interface;
using Assets.Scripts.Model;
using UnityEngine;

public class BancadaScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject painel;

    [SerializeField] 
    private Inventario inventario;

    [SerializeField]
    private ListaFerramentas listaFerramentas;

    [SerializeField]
    private ListaConstrucoes listaConstrucoes;

    [SerializeField]
    private Sprite[] Sprites;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private JogadorScript Player;

    private bool PlayerPerto = false;

    void Update()
    {
        UsarBancada();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = Sprites[1];

        if (collision.CompareTag("Player"))
        {
            PlayerPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = Sprites[0];

        if (collision.CompareTag("Player"))
        {
            PlayerPerto = false;
        }
    }

    void UsarBancada()
    {
        if (PlayerPerto)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                painel.SetActive(!painel.activeSelf);
            }

            if (painel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                painel.SetActive(false);
            }
        }
    }

    public void FabricarFerramenta(int IdFerramenta)
    {
        IFerramenta ferramenta = listaFerramentas.GetFerramenta(IdFerramenta);

        if (inventario.PossuiTudo(ferramenta.Receita))
        {
            inventario.Consumir(ferramenta.Receita);
        }
    }

    public void FabricarConstrucao(int idConstrucao)
    {
        IConstrucoes def = listaConstrucoes.GetConstrucao(idConstrucao);

        if (inventario.PossuiTudo(def.Receita))
        {
            inventario.Consumir(def.Receita);

            painel.SetActive(false);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            GameObject go = Instantiate(def.Prefab, mousePos, Quaternion.identity);
        }
    }
}
