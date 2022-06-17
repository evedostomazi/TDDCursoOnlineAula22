using CursoOnline.Dominio.Cursos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;


namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            var curso = new List<CursoParaListagemDto>();
            return View("Index", PaginatedList<CursoParaListagemDto>.Create(curso, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDto());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDto model)
        {
            return Ok();
        }
    }
}
