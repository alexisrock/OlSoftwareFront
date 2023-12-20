using Microsoft.AspNetCore.Mvc;
using OlSoftwareFront.DataAccess;

namespace OlSoftwareFront.Controllers
{
    public class AspiranteController : Controller
    {


        private readonly AspiranteService aspiranteService ;

        public AspiranteController()
        {
            this.aspiranteService = new AspiranteService();
        }
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("token");
			var list = await this.aspiranteService.GetAspirantes(token);
            return View(list);
        }
    }
}
