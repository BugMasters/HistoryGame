using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    void LateUpdate() // Executa após o Update
    {
        SeguirPlayer();
    }

    void SeguirPlayer()
    {
         transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
