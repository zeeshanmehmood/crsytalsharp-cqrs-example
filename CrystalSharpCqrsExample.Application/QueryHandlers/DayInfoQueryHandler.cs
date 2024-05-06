using System;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharpCqrsExample.Application.Queries;
using CrystalSharpCqrsExample.Application.ReadModels;

namespace CrystalSharpCqrsExample.Application.QueryHandlers
{
    public class DayInfoQueryHandler : QueryHandler<DayInfoQuery, DayInfoReadModel>
    {
        public override async Task<QueryExecutionResult<DayInfoReadModel>> Handle(DayInfoQuery request, CancellationToken cancellationToken = default)
        {
            DayInfoReadModel readModel = new() { Message = $"It's {DateTime.Now.DayOfWeek}." };

            return await Ok(readModel);
        }
    }
}
