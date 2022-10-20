using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApresentacao.Domain.Entities
{
    [Table(name: "Cidade")]
    public class Cidade
    {
        [Column(name: "Id")]
        public int Id { get; set; }
        [Column(name: "Nome_Cidade")]
        public string Nome { get; set; }
        [Column(name:"UF")]
        public string Estado { get; set; }
        
        public Cidade()
        {

        }
        public void CadastrarNovaCidade(int id, string nomeCidade, string estado)
        {
            this.Id = id;
            this.Nome = nomeCidade;
            this.Estado = estado;
        }
    }
    

   
}
