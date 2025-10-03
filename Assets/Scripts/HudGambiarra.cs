using UnityEngine;

public class HudTeste : MonoBehaviour
{
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        rt.position = rt.position;
    }
}
