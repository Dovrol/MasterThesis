using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using MediatR;

namespace Application.Queries
{
    public class BaseFindByQuery :  IRequest<QueryResultDto>
    {
        public Guid? Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ItemsCount { get; set; }        
    }
}