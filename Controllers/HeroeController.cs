using ApiRestHeroesDeMalvinas.Models;
using ApiRestHeroesDeMalvinas.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSApiHeroesDeMalvinas.Models;

namespace ApiRestHeroesDeMalvinas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await using (DbHeroesdemalvinasContext db = new DbHeroesdemalvinasContext())
            {
                Respuesta oRespuesta = new Respuesta();
                var lst = new List<Heroe>();



                try
                {
                    lst = db.Heroes.ToList();
                    if (lst != null)
                    {
                        oRespuesta.codigo = 200;
                        oRespuesta.mensaje = "Heroe encontrado con éxito.";
                        oRespuesta.Data = lst;
                    }
                    else
                    {
                        oRespuesta.codigo = 400;
                        oRespuesta.mensaje = "Heroe no encontrado.";
                    }



                }
                catch (Exception ex)
                {
                    oRespuesta.mensaje = ex.Message;
                    return StatusCode(400, oRespuesta);
                }

                return Ok(oRespuesta);
            }
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            await using (DbHeroesdemalvinasContext db = new DbHeroesdemalvinasContext())
            {
                Respuesta oRespuesta = new Respuesta();
                Heroe oHeroe = new Heroe();



                try
                {
                    string nuevoId = id.ToString();
                    oHeroe = db.Heroes.Where(e => e.Documento == nuevoId).FirstOrDefault();
                    if (oHeroe != null)
                    {
                        oRespuesta.codigo = 200;
                        oRespuesta.mensaje = "Heroe encontrado con éxito.";
                        oRespuesta.Data = oHeroe;
                    }
                    else
                    {
                        oRespuesta.codigo = 400;
                        oRespuesta.mensaje = "Heroe no encontrado.";
                    }



                }
                catch (Exception ex)
                {
                    oRespuesta.mensaje = ex.Message;
                    return StatusCode(400, oRespuesta);
                }

                return Ok(oRespuesta);
            }
        }



        [HttpPost]
        public async Task<IActionResult> AgregarHeroe(Heroe heroe)
        {
            Respuesta orespuesta = new Respuesta();

            try
            {
                using (DbHeroesdemalvinasContext db = new DbHeroesdemalvinasContext())
                {
                    await db.AddAsync(heroe);
                    db.SaveChanges();
                    orespuesta.mensaje = $"el heroe {heroe.NombreCompleto} se agregó correctamente";
                    orespuesta.codigo = 200;
                    return Ok(orespuesta);
                }
            }
            catch (Exception ex)
            {
                orespuesta.mensaje = ex.Message;
                return StatusCode(400, orespuesta);
            }
        }
    }
}