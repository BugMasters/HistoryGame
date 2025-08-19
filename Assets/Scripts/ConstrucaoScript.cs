using UnityEngine;

public class ConstrucaoScript : MonoBehaviour
{
    private bool canMove = false;

    void Update()
    {
        if (canMove)
        {
            Mover();
            if (Input.GetMouseButtonDown(0))
            {
                canMove = false;
            }
        }
    }

    public void AtivarModoColocacao()
    {
        canMove = true;
    }

    void Mover()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
