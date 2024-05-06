using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrystalSharp.Application;
using CrystalSharp.Application.Execution;
using CrystalSharpCqrsExample.Application.Queries;
using CrystalSharpCqrsExample.Application.ReadModels;

namespace CrystalSharpCqrsExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public DayController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<DayInfoReadModel>>> Get()
        {
            DayInfoQuery query = new();

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{dayNumber}")]
        public async Task<ActionResult<QueryExecutionResult<DayInfoReadModel>>> GetDayByNumber(int dayNumber)
        {
            DayInfoByNumberQuery query = new() { DayNumber = dayNumber };

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
