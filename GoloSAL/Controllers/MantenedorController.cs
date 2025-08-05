using Microsoft.AspNetCore.Mvc;

using GoloSAL.Datos;
using GoloSAL.Models;

namespace GoloSAL.Controllers
{
    public class MantenedorController : Controller
    {

        ClienteDatos _ClieneteDatos = new ClienteDatos();

        public IActionResult Listar()
        {
            /*Muestra la lista de los clientes*/
            var oLista = _ClieneteDatos.Listar();
            
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            /*Devuelve la vista del formulario guardar*/
            return View();
        }
        /**/
        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliete)
        {
            /*Este metodo recive los datos y los guarda en la BD */
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClieneteDatos.Guardar(oCliete);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();                
        }


    }
}
