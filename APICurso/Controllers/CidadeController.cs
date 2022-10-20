using WebApresentacao.Application.IServices;
using WebApresentacao.Domain.DTO;
using WebApresentacao.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApresentacao.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        //Construindo os Serviços que serão nescessarios para controller
        private readonly ICidadeService cidadeService;        
        public CidadeController(ICidadeService service)
        {
            cidadeService = service;            
        }

        [HttpPost]
        [Route("CadastrarCidade")]
        public IActionResult CadastrarNovaCidade([FromBody] RecebeCadastrarCidade model)
        {
            try
            {
                //Verificaçoes feitas para salvar a cidade
                if (model != null && !String.IsNullOrEmpty(model.Nome) && !String.IsNullOrEmpty(model.Estado))
                {
                    cidadeService.SalvarNovaCidade(model);
                    return Ok("Cidade Cadastrada com Sucesso"); //retorna 200 confirmando que ação pode ser concluida
                }
                else
                {
                    //retorna uma mensagem caso não seja possivel cadastrar a cidade
                    return Ok("Não foi possivel cadastrar a sua cidade");
                }

            }
            catch (Exception ex)
            {
                // retorna 400 de requisição nao pode ser executada
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ObterCidadePorId")]
  
        public IActionResult ObterCidadePorId(int id )
        {
            try //bloco para proteçao
            {
                Cidade cidade = new Cidade();                
                if (id != 0) 
                {
                    cidade = cidadeService.FindById(id);
                }

                else
                {
                    return BadRequest("Insira um Id válido");
                }

                if (cidade == null) return Ok("Não existe cidade com  esse Id!!!");

                RetornaListarCidade model = new RetornaListarCidade()
                {
                    Nome = cidade.Nome,
                    Id = cidade.Id,
                    Estado = cidade.Estado

                };
                return Ok(model);
            }
            catch
            {
                return BadRequest("Não existe cidade com Id Informado");
            }
        }
        [HttpGet]
        [Route("ObterCidadePeloNome")]
    
        public IActionResult ObterCidadePeloNome(string cidade)
        {
            try //bloco para proteçao
            {
                List<Cidade> cidadeList = new List<Cidade>();                
                    if (String.IsNullOrWhiteSpace(cidade))
                        cidadeList = cidadeService.Get().ToList();
                    else
                        cidadeList = cidadeService.Get(x => x.Nome.ToLower().Contains(cidade)).ToList();                        
                
                List<RetornaListarCidade> model = cidadeList.Select(r => new RetornaListarCidade
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Estado = r.Estado

                }).ToList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterCidadePeloEstado")]     
        public IActionResult ObterCidadePeloEstado(string estado)
        {
            try //bloco para proteçao
            {
                List<Cidade> cidadeList = new List<Cidade>();
                
                if (String.IsNullOrWhiteSpace(estado))
                    cidadeList = cidadeService.Get().ToList();
                else                      
                    cidadeList = cidadeService.Get(x => x.Estado.ToLower().Contains(estado)).ToList();                            
                if(cidadeList !=null && cidadeList.Count > 0)
                {
                    List<RetornaListarCidade> model = cidadeList.Select(r => new RetornaListarCidade
                    {

                        Id = r.Id,
                        Nome = r.Nome,
                        Estado = r.Estado


                    }).ToList();
                    return Ok(model);
                }
                else
                {
                    return Ok("Não existe cidade cadastrada para o estado informado");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
