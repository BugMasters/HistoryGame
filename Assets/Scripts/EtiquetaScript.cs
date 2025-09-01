using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EtiquetaScript : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] Sprites;

        [SerializeField]
        private LivroScript Livro;

        [SerializeField]
        private Image Icone;

        [SerializeField]
        private EtiquetaScript[] Etiquetas;

        private Vector2 PosicaoInicial;

        void Awake()
        {
            PosicaoInicial = transform.position;
        }

        void OnMouseEnter()
        {
            Icone.sprite = Sprites[1];
        }

        void OnMouseExit()
        {
            Icone.sprite = Sprites[0];   
        }

        void OnMouseDown()
        {
            Selecionado();
            VoltarEtiquetas();
        }

        private void Selecionado()
        {
            transform.position = Vector2.MoveTowards(PosicaoInicial, new Vector2(52, PosicaoInicial.y), 3f);
        }

        public void Voltar()
        {
            transform.position = Vector2.MoveTowards(transform.position, PosicaoInicial, 3f);
        }

        private void VoltarEtiquetas()
        {
            Etiquetas[0].Voltar();
            Etiquetas[1].Voltar();
        }
    }
}
