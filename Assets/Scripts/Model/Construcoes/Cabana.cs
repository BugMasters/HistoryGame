using Assets.Scripts.Enum;
using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model.Construcoes
{
    [Serializable]
    public class Cabana : ScriptableObject, IConstrucoes
    {
        [SerializeField] private GameObject prefab;

        public string Nome { get; }

        public string Descricao { get; }

        public GameObject Prefab => prefab;

        public Dictionary<TipoRecurso, int> Receita { get; }


        public Cabana()
        {
            Nome = "Cabana";
            Descricao = "Cabana simples utilizada pelos homens primitivos";
            Receita = new Dictionary<TipoRecurso, int>
            {
                { TipoRecurso.Madeira, 5 }
            };
        }
    }
}
