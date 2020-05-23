using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public sealed class HeroesGetAll
    {
        private readonly IHeroRepository _heroRepository;

        public HeroesGetAll(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [FunctionName("HeroesGetAll")]
        public async Task<IActionResult> GetAll
        (
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "heroes")]
            HttpRequest request,
            ILogger logger
        )
        {
            try
            {
                IEnumerable<Hero> heroes = await _heroRepository.GetAllAsync();
                return new OkObjectResult(heroes);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}