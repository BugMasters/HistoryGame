using UnityEngine;
using UnityEngine.EventSystems;

public class PanoScript : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localPos
        );

        (transform as RectTransform).anchoredPosition = localPos;
    }
}
