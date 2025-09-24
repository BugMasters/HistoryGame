using Assets.Scripts.Enum;
using UnityEngine;


namespace Assets.Scripts.Model.Livro
{

    [CreateAssetMenu(fileName = "Livro", menuName = "Livro/NovaPagina")]
    public class Pagina : ScriptableObject
    {
        [Header("Infos da Página")]
        [SerializeField] private string nome;
        [TextArea][SerializeField] private string descricao;

        public string Nome => nome;
        public string Descricao => descricao;
    }
}
