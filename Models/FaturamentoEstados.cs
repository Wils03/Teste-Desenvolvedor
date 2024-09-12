using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor.Models
{
    public class FaturamentoEstados
    {
        public string Estado { get; set; }
        public decimal Valor { get; set; }

        public FaturamentoEstados(string estado, decimal valor)
        {
            Estado = estado;
            Valor = valor;
        }
    }
}