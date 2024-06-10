using Microsoft.AspNetCore.Mvc;
using StudentPointsApi.Repository.Interfaces;

namespace StudentPointsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        protected readonly IJsonService JsonService;

        public BaseController(IJsonService jsonService)
        {
            JsonService = jsonService;
        }
    }
}
