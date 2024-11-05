using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoData _empleadoData;
        public EmpleadoController(EmpleadoData empleadoData)
        {
            _empleadoData = empleadoData;
        }

        [HttpPost]
        [Route("GetCompra")]
        public async Task<IActionResult> Lista([FromBody] string filtro)
        {
            List<Compra> Lista = await _empleadoData.GetCompra(filtro);
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPost]
        [Route("AddCompra")]
        public async Task<IActionResult> AddCompra([FromBody] Compra objeto)
        {

            var respuesta = await _empleadoData.AddCompra(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("UpdateCompra")]
        public async Task<IActionResult> UpdateCompra([FromBody] Compra objeto)
        {

            var respuesta = await _empleadoData.UpdateCompra(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("DeleteCompra")]
        public async Task<IActionResult> DeleteCompra([FromBody] int Id)
        {

            var respuesta = await _empleadoData.DeleteCompra(Id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }


    }
}
