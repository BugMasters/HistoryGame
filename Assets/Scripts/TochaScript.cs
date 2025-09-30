using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TochaScript : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject Pano;

    [SerializeField]
    private RectTransform[] Ingredientes;

    [SerializeField]
    private Sprite[] Fases;

    [SerializeField]
    private Sprite[] FasesSelecao;

    [SerializeField]
    public RectTransform objetoUI;

    [SerializeField]
    private GameObject Perdeneira;

    [SerializeField]
    private Canvas canvas;

    private Image Sprite;

    private int Fase;

    private Vector3 destino = new Vector3(152, 135, 0);
    private Vector3 rotacaoFinal = new Vector3(0, 0, 35);

    private float velocidade = 500f;
    private float velocidadeRotacao = 180f;

    void Awake()
    {
        Sprite = GetComponent<Image>();
    }

    void Update()
    {
        TrocarFase();
        Acender();
    } 

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Fase != 2)
        {
            Sprite.sprite = FasesSelecao[Fase];
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Sprite.sprite = Fases[Fase];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Fase < 2)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPos
            );

            (transform as RectTransform).anchoredPosition = localPos;
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
        return RectTransformUtility.RectangleContainsScreenPoint(
            alvo, transform.position, null);
    }

    private void Acender()
    {
        if(Fase == 2)
        {
            StartCoroutine(MoverCoroutine());
            AbrirHudPerdeneira();
            Fase = 3;
        }
    }

    private IEnumerator MoverCoroutine()
    {
        while (Vector3.Distance(objetoUI.anchoredPosition, destino) > 0.1f ||
               Vector3.Distance(objetoUI.localEulerAngles, rotacaoFinal) > 0.1f)
        {
            objetoUI.anchoredPosition = Vector3.MoveTowards(
                objetoUI.anchoredPosition,
                destino,
                velocidade * Time.deltaTime
            );

            objetoUI.localEulerAngles = Vector3.MoveTowards(
                objetoUI.localEulerAngles,
                rotacaoFinal,
                velocidadeRotacao * Time.deltaTime
            );

            yield return null;
        }

        objetoUI.anchoredPosition = destino;
        objetoUI.localEulerAngles = rotacaoFinal;
    }

    private void AbrirHudPerdeneira()
    {
        Perdeneira.SetActive(true);
    }
}
