using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Text_Jmeter.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
   
    public class Sistema_CRUD : ControllerBase
    {
        public static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast {ID = 0, PrimerNombre ="Cristopher", Apellido = "Lopez"},
            new WeatherForecast {ID = 1, PrimerNombre ="Maria", Apellido = "Aza"},
            new WeatherForecast { ID = 3, PrimerNombre = "Ana", Apellido = "Martinez" },
            new WeatherForecast { ID = 4, PrimerNombre = "Luis", Apellido = "Rodriguez" },
            new WeatherForecast { ID = 5, PrimerNombre = "Carla", Apellido = "Gomez" },
            new WeatherForecast { ID = 6, PrimerNombre = "Pedro", Apellido = "Ramirez" },
            new WeatherForecast { ID = 7, PrimerNombre = "Sofia", Apellido = "Hernandez" },
            new WeatherForecast { ID = 8, PrimerNombre = "Daniel", Apellido = "Castillo" },
            new WeatherForecast { ID = 9, PrimerNombre = "Laura", Apellido = "Morales" }
        };
        
        [HttpGet("{id}")]
       
        public IActionResult GetUser(int id) 
        { 
            var usuario = weatherForecasts.SingleOrDefault(usuario=> usuario.ID == id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(WeatherForecast user)
        {
            if (user == null)
                return BadRequest();

            weatherForecasts.Add(user);
            return Ok(user);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(weatherForecasts);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, WeatherForecast user)
        {
            if (id < 0)
                return BadRequest("El id no puede ser negativo");

            if (user == null)
                return BadRequest("Datos inválidos");

            var usuarioExistente = weatherForecasts.SingleOrDefault(u => u.ID == id);

            if (usuarioExistente == null)
                return NotFound("Usuario no encontrado");

            
            usuarioExistente.PrimerNombre = user.PrimerNombre;
            usuarioExistente.Apellido = user.Apellido;

            return Ok(usuarioExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id < 0)
                return BadRequest("El id no puede ser negativo");

            var usuario = weatherForecasts.SingleOrDefault(u => u.ID == id);

            if (usuario == null)
                return NotFound("Usuario no encontrado");

            weatherForecasts.Remove(usuario);

            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }
    }
}
