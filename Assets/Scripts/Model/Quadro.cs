using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(fileName = "Quadro", menuName = "Quadro/NovoQuadro")]
    public class Quadro: ScriptableObject
    {
        [Header("Infos do quadro")]
        [SerializeField] private Sprite pintura;
        [TextArea][SerializeField] private int identificador;

        public Sprite Pintura => pintura;
        public int Identificador => identificador;
    }
}
