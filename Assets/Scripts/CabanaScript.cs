using UnityEngine;

public class CabanaScript : MonoBehaviour
{
    private Light Light;

    private bool IsDia = true;

    void Awake()
    {
        Light = GetComponent<Light>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsDia = !IsDia;
                Light.color = IsDia ? Color.gray : Color.white;
            }
        }
    }
}
