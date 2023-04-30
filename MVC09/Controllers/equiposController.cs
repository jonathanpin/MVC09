using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC09.Models;

namespace MVC09.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposContext _equiposContext;
        public equiposController(equiposContext equiposContext)
        {
            _equiposContext = equiposContext;
        }

        public IActionResult Index()
        {
            var listaMarcas =  (from m in _equiposContext.marcas select m).ToList();
            ViewData["listaMarcas"] = new SelectList(listaMarcas, "id_marcas", "nombre_marca");

            var listaTipos = (from t in _equiposContext.tipo_equipo select t).ToList();
            ViewData["listaTipos"] = new SelectList(listaTipos, "id_tipo_equipo", "descripcion");

            var listaEquipos = (from e in _equiposContext.equipos 
                             join m in _equiposContext.marcas on e.marca_id equals m.id_marcas
                             join t in _equiposContext.tipo_equipo on e.tipo_equipo_id equals t.id_tipo_equipo
                             select new
                             {
                                 nombre = e.nombre,
                                 descripcion = e.descripcion,
                                 marca = m.nombre_marca,
                                 tipo = t.descripcion
                             }).ToList();
            ViewData["listaEquipos"] = listaEquipos;
            return View();
        }
        public IActionResult crearEquipo(equipos nuevoEquipo)
        {
            _equiposContext.Add(nuevoEquipo);
            _equiposContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
