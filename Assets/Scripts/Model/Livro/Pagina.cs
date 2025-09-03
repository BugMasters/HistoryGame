using Assets.Scripts.Enum;
using UnityEngine;


namespace Assets.Scripts.Model.Livro
{

    [CreateAssetMenu(fileName = "Livro", menuName = "Livro/NovaPagina")]
    public class Pagina : ScriptableObject
    {
        [SerializeField] private int numPagina;
        [SerializeField] private bool liberado;
        [SerializeField] private Sprite icone;
        [SerializeField] private TipoInformacao tipo;

        [Header("Infos da Página")]
        [SerializeField] private string nome;
        [TextArea][SerializeField] private string descricao;

        [Header("Fatos")]
        [TextArea][SerializeField] private string fato1;
        [TextArea][SerializeField] private string fato2;
        [TextArea][SerializeField] private string fato3;

        public int NumPagina => numPagina;
        public bool Liberado => liberado;
        public Sprite Icone => icone;
        public string Nome => nome;
        public string Descricao => descricao;
        public string Fato1 => fato1;
        public string Fato2 => fato2;
        public string Fato3 => fato3;
        public TipoInformacao Tipo => tipo;
    }
}
