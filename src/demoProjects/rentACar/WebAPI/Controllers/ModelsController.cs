using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetlistModelQuery getlistModelQuery = new GetlistModelQuery { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getlistModelQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, 
            [FromBody] Dynamic dynamic)
        {
            GetlistModelByDynamicQuery getlistModelByDynamicQuery = new GetlistModelByDynamicQuery
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };
            ModelListModel result = await Mediator.Send(getlistModelByDynamicQuery);
            return Ok(result);
        }
    }
}
