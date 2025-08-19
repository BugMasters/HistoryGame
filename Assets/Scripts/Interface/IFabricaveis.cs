using Assets.Scripts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    public interface IFabricaveis
    {
        Dictionary<TipoRecurso, int> Receita { get; }
    }
}
