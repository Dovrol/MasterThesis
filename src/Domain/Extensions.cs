using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class Extensions
    {        
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}