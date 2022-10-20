using WebApresentacao.Application.IServices;
using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApresentacao.Infra.Repositories;
using WebApresentacao.Infra.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApresentacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Construindo os Serviços que serão nescessarios para controller
        private readonly IClienteService clienteService;
        private readonly ICidadeService cidadeService;
        public ClienteController(IClienteService service, ICidadeService _cidadeService)
        {
            clienteService = service;
            cidadeService = _cidadeService;
        }

        //metodo para listar todos os clientes pelo nome
        [HttpGet]
        [Route("ObterClientePeloNome")]      
        public IActionResult ObterClientePeloNome(string cliente)
        {
            try //bloco para proteçao
            {
                List<Cliente> clienteList = new List<Cliente>();
                
                    if (String.IsNullOrWhiteSpace(cliente))
                        clienteList = clienteService.Get().ToList();
                    else
                        clienteList = clienteService.Get(x => x.NomeCliente.ToLower().Contains(cliente)).ToList();
                    foreach(var clientels in clienteList)
                    {
                        clientels.Cidade = cidadeService.FindById(clientels.IdCidade); 
                    }               
               
                List<RetornaListarClientes> model = clienteList.Select(r => new RetornaListarClientes
                {
                    NomeCliente = r.NomeCliente,
                    Id = r.Id,
                    Sexo = r.Sexo,
                    DataNascimento = r.DataNascimento,
                    Idade = r.Idade,
                    IdCidade = r.IdCidade,
                    Cidade = r.Cidade.Nome,
                    Estado = r.Cidade.Estado,
                    Logadouro = r.Logadouro
                    
                }).ToList();
                return Ok(model);
            }
            catch 
            {
                return BadRequest("Não existe cliente com o nome informado");
            }
        }

        [HttpGet]
        [Route("ObterClientePorId")]
       
        public IActionResult ObterClientePorId(int id)
        {
            try //bloco para proteçao
            {
                Cliente cliente = new Cliente();               
                    if (id != 0)
                        cliente = clienteService.FindById(id);
                    else
                        throw new Exception();
                    if(cliente!=null)
                        cliente.Cidade = cidadeService.FindById(cliente.IdCidade);
                    else
                        throw new Exception();               
                

                RetornaListarClientes model = new RetornaListarClientes()
                {
                    NomeCliente = cliente.NomeCliente,
                    Id = cliente.Id,
                    Sexo = cliente.Sexo,
                    DataNascimento = cliente.DataNascimento,
                    Idade = cliente.Idade,
                    IdCidade = cliente.IdCidade,
                    Cidade = cliente.Cidade.Nome,
                    Estado = cliente.Cidade.Estado,
                    Logadouro = cliente.Logadouro

                };
                return Ok(model);
            }
            catch
            {
                return BadRequest("Não existe cliente com Id Informado");
            }
        }

        [HttpDelete]
        [Route("DeletarClientePorId")]
        [AllowAnonymous]
        public IActionResult DeletarClientePorId(int id)
        {
            try //bloco para proteçao
            {
                Cliente cliente = new Cliente();               
                    if (id != 0)
                        cliente = clienteService.FindById(id);
                    else
                        throw new Exception();
                    if (cliente != null)
                        clienteService.Delete(cliente);
                    else
                        throw new Exception();              

                return Ok("Cliente deletado com sucesso");
            }
            catch
            {
                return BadRequest("Não existe cliente com Id Informado");
            }
        }

        [HttpPost]
        [Route("CadastrarCliente")]
        public IActionResult CadastrarNovoCliente([FromBody] RecebeCadastrarCliente model)
        {
            try
            {
                //Verificaçoes feitas para o possivel cadastro
                if (model !=null && !String.IsNullOrEmpty(model.NomeCliente) && !string.IsNullOrEmpty(model.Sexo.ToString())
                    && model.IdCidade > 0 && !string.IsNullOrEmpty(model.Logadouro))
                {
                    clienteService.SalvarNovoCliente(model);
                    return Ok(" Cliente Cadastrado com Sucesso");  //retorna 200 confirmando que ação pode ser concluida
                }
                else
                {                   
                    return Ok("DTO vazio ou invalido");
                }

            }
            catch (Exception ex)
            {
                // retorna 400 de requisição nao pode ser executada
                return BadRequest(ex.Message);
            }
        }

       



        [HttpPut]
        [Route("AlterarNomeCliente")]
        public IActionResult AlterarNomeCliente([FromBody] RecebeClienteAlterarNome model)
        {            
            try
            {
                //verificaçoes para a possivel alteração de nome 
                if (model !=null && model.Id > 0 && !String.IsNullOrEmpty(model.NomeCliente))
                {
                    clienteService.AlterarNomeCliente(model);
                    return Ok("Nome de cliente alterado com sucesso");
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }       

    }
}
