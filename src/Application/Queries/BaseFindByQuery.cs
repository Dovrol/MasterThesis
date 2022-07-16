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
    }
}