using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
