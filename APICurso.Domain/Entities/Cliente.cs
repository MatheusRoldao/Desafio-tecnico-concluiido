using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace WebApresentacao.Domain.Entities
{
    [Table(name: "Cliente")]
    public class Cliente
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome_Cliente")]
        public string NomeCliente { get; set; }
        [Column("Sexo")]
        public char Sexo { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Column("Idade")]
        public int Idade { get; set; }
        [Column("Id_Cidade")]
        public int IdCidade { get; set; }
        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }
        [Column("Logadouro")]
        public string Logadouro { get; set; }

        public Cliente()
        {

        }

     
        //metodo para cadastrar novo cliente
        public void CadastrarNovoCliente(int id, string nomeCliente, char sexo, DateTime dataNascimento, int idade, int idCidade, string logadouro)
        {
            this.Id = id;
            this.NomeCliente = nomeCliente;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.Idade = idade;
            this.Logadouro = logadouro;
            this.IdCidade = idCidade;
           
        }

        //metodo para alterar o nome do cliente
        public void AlterarNomeCliente(string nomeCliente)
        {
            this.NomeCliente = nomeCliente;
        }

        

    }
}
