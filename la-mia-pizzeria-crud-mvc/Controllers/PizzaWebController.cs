using la_mia_pizzeria_crud_mvc.Data;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaWebController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPizza(string? name)
        {
            if (name == null)
            {
                return Ok(PizzaManager.CountAllPizzas());
            }
            else
            {
                return Ok(PizzaManager.CountAllPizzas());
            }
        }

        [HttpGet]
        public IActionResult GetPizzaById(int id) // QUERY PARAM https://.../api/Pizzawebapi/getPostbyid?id=1
        {
            var Pizza = PizzaManager.GetPizza(id);
            if (Pizza == null)
            {
                return NotFound("ERRORE");
            }
            else
            {
                return Ok(Pizza);
            }


        }

        [HttpGet("{name}")]
        public IActionResult GetPizzaByTitle(string name) // PATH PARAM https://.../api/Postwebapi/getPostbyTitle/post1
        {
            var Pizza = PizzaManager.GetPizzaByTitle(name);
            if (Pizza == null)
                return NotFound("ERRORE");
            return Ok(Pizza);
        }

        [HttpPost]
        // Post deve essere incluso nella richiesta POST
        // (come documento JSON che il framework deserializzerà automaticamente in oggetto di tipo Post)
        public IActionResult CreatePizza([FromBody] Pizza Pizza)
        {
            PizzaManager.InsertPizza(Pizza, null);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdatePizza(int id, [FromBody] Pizza Pizza)
        //{
        //    var oldPizza = PizzaManager.GetPizza(id);
        //    if (oldPizza == null)
        //        return NotFound("ERRORE");
        //    PizzaManager.UpdatePizza(id, Pizza.Name, Pizza.Description, Pizza.CategoryId, null);
        //    return Ok();
        //}


    }
}
