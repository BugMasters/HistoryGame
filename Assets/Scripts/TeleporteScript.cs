using UnityEngine;

public class TeleporteScript : MonoBehaviour
{
    [SerializeField] 
    private Transform Para;

    private Transform Player;

    [SerializeField]
    private float Y;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.position = new Vector2(Para.position.x, Para.position.y + Y);
        }
    }
}
