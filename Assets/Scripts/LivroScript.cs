using UnityEngine;

public class LivroScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject Livro;

    private bool InHud = false;

    void Update()
    {
        AbrirLivro();
    }

    private void PlayAnimationOnce()
    {
        animator.SetTrigger("PlayOnce");
    }

    private void AbrirLivro()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InHud)
            {
                Livro.SetActive(false);
                InHud = false;
            }
            else
            {
                Livro.SetActive(true);
                PlayAnimationOnce();
                InHud = true;
            }
        }

        if(InHud && Input.GetKeyDown(KeyCode.Escape))
        {
            Livro.SetActive(false);
        }
    }
}
