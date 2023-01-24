using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sat.Recruitment.Api.Controllers
{
    public class InfoController : Controller
    {
        [AllowAnonymous]
        [Produces("application/json")]
        public IActionResult Index()
        { 
            return Content("<html><head><link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css' integrity='sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb' crossorigin='anonymous'><link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.3.1/css/all.css' integrity='sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU' crossorigin='anonymous'></head><body>" +

                "<div class='jumbotron'>" +
                "<h1><i class='fab fa-centercode' fa-2x></i>Sat Recruitment Api</h1>" +
                "<h4>v1.0</h4>" +
                 "Solution to the FoshTech's test by <b>Sergio Spagnolo</b><br>" +
                 "<br>" +
                 "<a class='btn btn-outline-primary' role='button' href='/swagger'><b>Swagger API specification</b></a>" +
                "</div>" +

                "<div class='row'>" +
                "</body></html>"
               , "text/html");
        }
    }
}
