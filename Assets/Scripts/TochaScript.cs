using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TochaScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject Pano;

    [SerializeField]
    private RectTransform[] Ingredientes;

    [SerializeField]
    private Sprite[] Fases;

    [SerializeField]
    private Sprite[] FasesSelecao;

    private RectTransform rt;

    [SerializeField]
    private GameObject Perdeneira;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private HudMovelScript Hud;

    private Image Sprite;

    private int Fase;

    private Vector3 destino = new Vector3(-15, -178, 0);
    private Vector3 rotacaoFinal = new Vector3(0, 0, 35);

    private float velocidade = 500f;
    private float velocidadeRotacao = 180f;

    void Awake()
    {
        Sprite = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(Fase < 3)
        {
            TrocarFase();
        }

        Acender();
    } 

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Fase < 2)
        {
            Sprite.sprite = FasesSelecao[Fase];
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Fase < 2)
        {
            Sprite.sprite = Fases[Fase];
        }
    }

    public void TrocarFase()
    {
        if(Fase == 0 && EstaColidindo(Ingredientes[0]))
        {
            Sprite.sprite = Fases[1];
            Destroy(Pano);
            Fase = 1;
        }

        if(Fase == 1 && EstaColidindo(Ingredientes[1]))
        {
            Sprite.sprite = Fases[2];
            Fase = 2;
        }
    }

    private bool EstaColidindo(RectTransform alvo)
    { 
        return RectTransformUtility.RectangleContainsScreenPoint(alvo, transform.position, null); 
    }

    private void Acender()
    {
        if(Fase == 2)
        {
            StartCoroutine(MoverCoroutine());
            AbrirHudPerdeneira();
            Hud.Parar();
            Fase = 3;
        }
    }

    private IEnumerator MoverCoroutine()
    {
        while (Vector3.Distance(rt.anchoredPosition, destino) > 0.1f ||
               Vector3.Distance(rt.localEulerAngles, rotacaoFinal) > 0.1f)
        {
            rt.anchoredPosition = Vector3.MoveTowards(
                rt.anchoredPosition,
                destino,
                velocidade * Time.deltaTime
            );

            rt.localRotation = Quaternion.RotateTowards(
                rt.localRotation,
                Quaternion.Euler(rotacaoFinal),
                velocidadeRotacao * Time.deltaTime
            );

            yield return null;
        }

        rt.anchoredPosition = destino;
        rt.localEulerAngles = rotacaoFinal;
    }

    private void AbrirHudPerdeneira()
    {
        Perdeneira.SetActive(true);
    }
}
