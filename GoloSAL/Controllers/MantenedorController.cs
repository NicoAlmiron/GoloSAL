using Microsoft.AspNetCore.Mvc;

using GoloSAL.Datos;
using GoloSAL.Models;

namespace GoloSAL.Controllers
{
    public class MantenedorController : Controller
    {

        ClienteDatos _ClienteDatos = new ClienteDatos();

        public IActionResult Listar()
        {
            /*Muestra la lista de los clientes*/
            var oLista = _ClienteDatos.Listar();
            
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            /*Devuelve la vista del formulario guardar*/
            return View();
        }
        /**/
        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            /*Este metodo recive los datos y los guarda en la BD */
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClienteDatos.Guardar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();                
        }

        public IActionResult Editar(int clienteID)
        {
            /*Devuelve la vista del formulario Editar*/
            var ocliente =  _ClienteDatos.obtener(clienteID);
            return View(ocliente);
        }
        /**/
        [HttpPost]
        public IActionResult Editar(ClienteModel oCliente)
        {
            /*Este metodo recive los datos y los guarda en la BD */
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClienteDatos.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int clienteID)
        {
            /*Devuelve la vista del formulario Eliminar*/
            var ocliente = _ClienteDatos.obtener(clienteID);
            return View(ocliente);
        }
        /**/
        [HttpPost]
        public IActionResult Eliminar(ClienteModel oCliente)
        {
            
            var respuesta = _ClienteDatos.Eliminar(oCliente.ClienteID);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
