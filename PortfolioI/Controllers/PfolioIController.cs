using Microsoft.AspNetCore.Mvc;


namespace PortfolioI.Controllers
{
    public class PfolioIController : Controller
    {
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index";
        }

        [HttpGet("projects")]
        public string Projects()
        {
            return "These are my projects";
        }

        [HttpGet("contact")]
        public string Contact()
        {
            return "These is my Contact";
        }
    }
}