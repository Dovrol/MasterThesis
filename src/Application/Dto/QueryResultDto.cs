using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dto
{
    public class QueryResultDto
    {
        public int RowsReturned { get; set; }
        public PerformanceResult Performance { get; set; }
    }
}