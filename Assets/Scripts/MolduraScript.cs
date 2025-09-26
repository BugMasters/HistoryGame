using UnityEngine;
using UnityEngine.UIElements;

public class MolduraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    private Vector3 Local;

    private bool InWall = true;

    private bool InCollision = false;

    void Update()
    {
        SeguirPlayer();
        Trocar();
    }

    void SeguirPlayer()
    {
        if (!InWall)
        {
            transform.position = transform.position = new Vector3(Player.position.x, Player.position.y + 0.7f, transform.position.z);
        }
    }

    void Trocar()
    {
        if (InCollision)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player clicou E!!");

                if (!InWall)
                {
                    InWall = true;

                    transform.position = Local;
                }
                else if (InWall)
                {
                    InWall = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Quadro"))
        {
            Local = collision.transform.position;
        }

        if (InWall && collision.CompareTag("Player"))
        {
            Debug.Log("Player encostou!!");

            InCollision = true;
        }
        else if(!InWall && collision.CompareTag("Quadro"))
        {
            InCollision = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (InWall && collision.CompareTag("Player"))
        {
            InCollision = false;
        }
        else if (!InWall && collision.CompareTag("Quadro"))
        {
            InCollision = false;
        }
    }
}
