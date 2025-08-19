using Assets.Scripts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    public interface IFerramenta : IFabricaveis
    {
        string Nome { get; }
        float DurabilidadeAtual { get; set; }
        float DurabilidadeMaxima { get; }
        float Dano { get; }

        Dictionary<TipoRecurso, int> Receita { get; }
    }
}
