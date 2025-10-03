using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    private bool Seguir = true;

    void LateUpdate()
    {
        if (Seguir)
        {
            SeguirPlayer();
        }
    }

    void SeguirPlayer()
    {
         transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }

    public void Movimento()
    {
        Seguir = !Seguir;
    }
}
