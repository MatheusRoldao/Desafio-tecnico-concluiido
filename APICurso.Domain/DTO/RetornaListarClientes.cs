using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApresentacao.Domain.DTO
{
    public class RetornaListarClientes
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public int IdCidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logadouro { get; set; }
        
    }
}
