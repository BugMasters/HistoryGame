using UnityEngine;
using UnityEngine.EventSystems;

public class HudMovelScript : MonoBehaviour, IDragHandler
{
    private RectTransform rt;

    private bool Mover = true;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mover)
        {
            rt.anchoredPosition += eventData.delta;
        }
    }

    public void Parar()
    {
        Mover = false;
    }
}
