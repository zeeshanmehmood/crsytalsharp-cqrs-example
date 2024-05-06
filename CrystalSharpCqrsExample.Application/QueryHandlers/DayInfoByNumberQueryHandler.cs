using System;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharpCqrsExample.Application.Queries;
using CrystalSharpCqrsExample.Application.ReadModels;

namespace CrystalSharpCqrsExample.Application.QueryHandlers
{
    public class DayInfoByNumberQueryHandler : QueryHandler<DayInfoByNumberQuery, DayInfoReadModel>
    {
        public override async Task<QueryExecutionResult<DayInfoReadModel>> Handle(DayInfoByNumberQuery request, CancellationToken cancellationToken = default)
        {
            if (request.DayNumber < 1 || request.DayNumber > 7) return await Fail("Day number must be between 1 to 7.");

            int dayNumber = --request.DayNumber;
            DayInfoReadModel readModel = new() { Message = $"It's {(DayOfWeek)dayNumber}." };

            return await Ok(readModel);
        }
    }
}
