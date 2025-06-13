using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]

public class ApiUsuariosController : ControllerBase
{





  private readonly IMongoCollection<Usuario> collection;
  public ApiUsuariosController()
  {
    var client = new MongoClient(CadenasConexion.MONGO_DB);
    var database = client.GetDatabase("Escuela_Yuliana_Danna");
    this.collection = database.GetCollection<Usuario>("Usuarios");

  }

  [HttpGet]
  public IActionResult ListarUsuarios(string? texto)
  {
    var filter = FilterDefinition<Usuario>.Empty;
    if (!string.IsNullOrWhiteSpace(texto))
    {
      var filterNombre = Builders<Usuario>.Filter.Regex(u => u.Nombre, new BsonRegularExpression(texto, "i"));
      var filterCorreo = Builders<Usuario>.Filter.Regex(u => u.Correo, new BsonRegularExpression(texto, "i"));
      filter = Builders<Usuario>.Filter.Or(filterNombre, filterCorreo);
    }
    var list = this.collection.Find(filter).ToList();
    return Ok(list);
  }

[HttpDelete("{id}")]
  public IActionResult Delete(string id)
  {
    var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
    var item = this.collection.Find(filter).FirstOrDefault();
    if (item != null)
    {
      this.collection.DeleteOne(filter);
    }
    return NoContent();
  }
}