using UnityEngine;

namespace Assets.Scripts
{
    public class ConstrucaoTeste : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            }
        }
    }
}
