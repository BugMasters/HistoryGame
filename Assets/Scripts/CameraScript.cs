using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    void LateUpdate()
    {
        SeguirPlayer();
    }

    void SeguirPlayer()
    {
         transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
