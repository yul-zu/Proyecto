using Microsoft.AspNetCore.Mvc;
using ProyectoP3.Models;
using MongoDB.Driver;

namespace ProyectoP3.Controllers.Api;
[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController : ControllerBase
{
    [HttpGet("integrantes")]
    public ActionResult<MiProyecto> Integrantes()
    {
        var proyecto = new MiProyecto
        {
            NombreIntegrante1 = "Yuliana Karime Zuñiga Manzano",
            NombreIntegrante2 = "Danna Azereth Cruz Betancourt"
        };
        return Ok(proyecto);
    }
    [HttpGet("presentacion")]
    public IActionResult Presentacion()
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Escuela_Yuliana_Danna");
        var collecion = db.GetCollection<Equipo>("Equipo");
         var item = collecion.Find(FilterDefinition<Equipo>.Empty).FirstOrDefault();
         return Ok(item);
     
    }
}