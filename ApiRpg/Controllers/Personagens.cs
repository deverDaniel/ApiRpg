using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRpg.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiRpg.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class Personagens : ControllerBase
    {
        private static List<Personagem> listaP = new List<Personagem>
        {
            new Personagem
            {
                Id = 1,
                Nome = "Peter",
                Sobrenome = "Parker",
                Fantasia = "Homen-Aranha",
                Local = "NY City"

            },
            new Personagem
            {
                Id = 2,
                Nome = "Bruce",
                Sobrenome = "Wayne",
                Fantasia = "Batman",
                Local = "Gothan"

            },
            new Personagem
            {
                Id = 3,
                Nome = "Killua",
                Sobrenome = "Zoldyck",
                Fantasia = "nenhuma",
                Local = "Montanha Zoldyck"

            },
            new Personagem
            {
                Id = 4,
                Nome = "Sherlock",
                Sobrenome = "Holmes",
                Fantasia = "Detetive",
                Local = "Londres"

            },new Personagem
            {
                Id = 5,
                Nome = "Gon",
                Sobrenome = "Freecss",
                Fantasia = "Nenhuma",
                Local = "Ilha da baleia"

            },
            new Personagem
            {
                Id = 6,
                Nome = "Itachi",
                Sobrenome = "Uchiha",
                Fantasia = "Akatsuke",
                Local = "Aldeia da folha"

            },
            new Personagem
            {
                Id = 7,
                Nome = "Sasuke",
                Sobrenome = "Uchiha",
                Fantasia = "Akatsuke",
                Local = "Aldeia da folha"

            },
            

        };

        [HttpGet]
        public async Task<ActionResult<List<Personagem>>> TodosPersonagens()
        {
            return Ok(listaP);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Personagem>>> UnicoPersonagem(int id)
        {
            var personagem = listaP.Find(x=> x.Id == id);
            

            if(personagem is null)
            {
                return NotFound("Personagem não encontrado");
            }
            return Ok(personagem);
            
        }

        [HttpGet("cidade/{local}")]
        public async Task<ActionResult<List<Personagem>>> PersonagemLocal (string local)
        {
            var personagem = listaP.FindAll(x => x.Local == local);
            if (personagem is null)
                return NotFound("Personagem não encontrado");
            return Ok(personagem);
        }

        [HttpPost]
        public async Task<ActionResult<List<Personagem>>> AddPersonagem(Personagem novo)
        {
            int idfinal = listaP[listaP.Count - 1].Id;
            novo.Id = idfinal + 1;
            listaP.Add(novo);
            return Ok(listaP);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Personagem>>> RemovePersonagem(int id)
        {
            var deleta = listaP.Find(x => x.Id == id);
            if (deleta is null)
                return NotFound("Personagem não encontrado");
            listaP.Remove(deleta);
            return Ok(listaP);
        
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Personagem>>> EditPersonagem(int id, Personagem editado)
        {
            var pesquisa = listaP.Find(x => x.Id == id);
            if (pesquisa is null)
            {
                return NotFound("Personagem nâo foi encontrado");
            }
            pesquisa.Nome = editado.Nome is null ? pesquisa.Nome : editado.Nome;
            pesquisa.Sobrenome = editado.Sobrenome is null ? pesquisa.Sobrenome : editado.Sobrenome;
            pesquisa.Fantasia = editado.Fantasia is null ? pesquisa.Fantasia : editado.Fantasia;
            pesquisa.Local = editado.Local is null ? pesquisa.Local : editado.Local;

            return Ok (pesquisa);
        }



    }

    
}
