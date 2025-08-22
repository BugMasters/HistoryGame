using UnityEngine;

public class ConstrucaoScript : MonoBehaviour
{
    private bool canMove = true;


    void Update()
    {
        if (!canMove)
        {
            return;
        }

        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        if (Input.GetMouseButtonDown(0))
        {
            canMove = false;
        }
    }
}

