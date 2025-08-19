using Assets.Scripts.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class ListaFerramentas : MonoBehaviour
    {
        [SerializeField]
        private MachadoPedra MachadoPedra;

        private Dictionary<int, IFerramenta> Ferramentas = new()
        {
            {1, new MachadoPedra()}
        };

        public IFerramenta GetFerramenta(int id)
        {
            return Ferramentas[id];
        }
    }
}
