using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapperTranslation.MapperConfig;
using AutoMapperTranslation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslationPOC.Models;

namespace AutoMapperTranslation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpanishController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Brand> Get()
        {
            var source = new Brand {

                Id = 1,
                Name = "Kamal",
                Description = "Hello"
            };

            var mapper = typeof(Brand).GetTypeMapper<Brand>("Spanish");

            var target = mapper.Map<Brand>(source);

           

            return Ok(target);
        }
    }
}