using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercearia_Produtos_API
{
    public class Resposta
    {
        public int CodigoStatus { get; set; }

        public string Mensagem { get; set; }

        public Resposta (int codigoStatus, string mensagem)
        {
            this.CodigoStatus = codigoStatus;
            this.Mensagem = mensagem;
        }
    }
}
