using UnityEngine;

namespace Assets.Scripts
{
    public class LivroController: MonoBehaviour
    {
        [SerializeField]
        private GameObject Livro;

        [SerializeField]
        private GameObject Etiqueta;

        private bool InHud = false;

        void Update()
        {
            AbrirLivro();
        }

        private void AbrirLivro()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (InHud)
                {
                    Livro.SetActive(false);
                    Etiqueta.SetActive(false);
                    InHud = false;
                }
                else
                {
                    Livro.SetActive(true);
                    Etiqueta.SetActive(true);
                    InHud = true;
                }
            }

            if (InHud && Input.GetKeyDown(KeyCode.Escape))
            {
                Livro.SetActive(false);
                Etiqueta.SetActive(false);
            }
        }
    }
}
