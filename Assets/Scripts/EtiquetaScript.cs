using Assets.Scripts.Enum;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EtiquetaScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private Sprite[] Sprites;

        [SerializeField]
        private LivroScript Livro;

        [SerializeField]
        private Image Icone;

        [SerializeField]
        private EtiquetaScript[] Etiquetas;

        [SerializeField]
        private TipoInformacao Tipo;

        private RectTransform rect;

        private Vector2 PosicaoInicial;

        private Vector2 PosicaoAtivado;

        private Vector2 PosicaoAMover;

        private bool Ativado = false;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            PosicaoInicial = rect.anchoredPosition;
            PosicaoAtivado = new Vector2(rect.anchoredPosition.x + 5f, rect.anchoredPosition.y);

            if(Tipo == TipoInformacao.Construcao)
            {
                Selecionado();
            }
        }

        void Mover()
        {
            rect.anchoredPosition = PosicaoAMover;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Icone.sprite = Sprites[1];
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Icone.sprite = Sprites[0];
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!Ativado)
            {
                Selecionado();
                VoltarEtiquetas();
                Livro.AlterarEtiquetaPrefacio(Tipo);
            }
        }

        private void Selecionado()
        {
            PosicaoAMover = PosicaoAtivado;
            Ativado = true;
            Mover();
        }

        public void Voltar()
        {
            if (Ativado)
            {
                PosicaoAMover = PosicaoInicial;
                Ativado = false;
                Mover();
            }
        }

        private void VoltarEtiquetas()
        {
            Etiquetas[0].Voltar();
            Etiquetas[1].Voltar();
        }
    }
}
