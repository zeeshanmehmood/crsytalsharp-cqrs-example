using CrystalSharp.Application;
using CrystalSharpCqrsExample.Application.ReadModels;

namespace CrystalSharpCqrsExample.Application.Queries
{
    public class DayInfoByNumberQuery : IQuery<QueryExecutionResult<DayInfoReadModel>>
    {
        public int DayNumber { get; set; }
    }
}
