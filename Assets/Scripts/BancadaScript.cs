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
    private JogadorScript player;

    [SerializeField]
    private ListaFerramentas listaFerramentas;

    [SerializeField]
    private ListaConstrucoes listaConstrucoes;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                painel.SetActive(!painel.activeSelf);
                player.CanMove();
            }

            if (painel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                painel.SetActive(false);
                player.CanMove();
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

    public void FabricarConstrucao(int IdConstrucao)
    {
        IConstrucoes construcao = listaConstrucoes.GetConstrucaoPrefab(IdConstrucao);

        if (inventario.PossuiTudo(construcao.Receita))
        {
            inventario.Consumir(construcao.Receita);

            painel.SetActive(false);
            player.CanMove();

            // Instancia a construção
            GameObject go = Instantiate(construcao.Prefab, player.transform.position, Quaternion.identity);
            go.GetComponent<ConstrucaoScript>().AtivarModoColocacao();
        }
    }

}
