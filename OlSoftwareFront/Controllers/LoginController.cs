using Microsoft.AspNetCore.Mvc;
using OlSoftwareFront.DataAccess;
using OlSoftwareFront.Model;

namespace OlSoftwareFront.Controllers
{
    public class LoginController : Controller
    {


        private readonly AutenticationService autenticationService;

        public LoginController()
        {
            this.autenticationService =  new AutenticationService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Autentication autentication)
        {
			


			var result = await this.autenticationService.Autentication(autentication);
            if (result is not null)
            {            
				HttpContext.Session.SetString("token", result.token); 			 				 
                return Redirect("Dashboard");
            }  
            else
                return View("Index");

           
        }
    }
}
