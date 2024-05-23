using la_mia_pizzeria_crud_mvc.Data;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
