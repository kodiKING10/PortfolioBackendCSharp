using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackendCSharp.Models;

namespace PortfolioBackendCSharp.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public List<AuthorInformation> Get()
        {
            List<AuthorInformation> authorInformation = new List<AuthorInformation> {
                new AuthorInformation { Author = "Henrique Cavalcante Veiga", ProjectName = "Portfolio Website", APIDocumentation = "Not yet." }
            };

            return authorInformation;
        }
    }
}