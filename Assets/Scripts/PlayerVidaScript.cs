using UnityEngine;
using UnityEngine.UI;

public class PlayerVidaScript : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public int vidaMaxima = 3;
    public int vidaAtual;

    [Header("HUD de Corações")]
    public Image[] coracoes;
    public Sprite coracaoCheio;
    public Sprite coracaoVazio;

    [Header("Player")]
    public JogadorScript Player;

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarHUD();
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        AtualizarHUD();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void AtualizarHUD()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i < vidaAtual)
                coracoes[i].sprite = coracaoCheio;
            else
                coracoes[i].sprite = coracaoVazio;
        }
    }

    void Morrer()
    {
        Player.Morrer();
    }
}
