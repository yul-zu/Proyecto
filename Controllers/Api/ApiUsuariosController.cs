using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class ApiUsuariosController : ControllerBase
{
    // Métodos para hacer las operaciones CRUD
    // C = Create
    // R = Read
    // U = Update
    // D = Delete

    private readonly IMongoCollection<Usuario> collection;

public ApiUsuariosController()
{
    var client = new MongoClient(CadenasConexion.MONGO_DB);
    var database = client.GetDatabase("Escuela_Yuliana_Danna");
    this.collection = database.GetCollection<Usuario>("Usuarios");
}

[HttpGet]
public IActionResult ListarUsuarios()
{
    var filter = FilterDefinition<Usuario>.Empty;
    var list = this.collection.Find(filter).ToList();
    return Ok(list);
}

    
}