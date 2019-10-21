using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Domain.Activity>>
        {

        }
        public class Handler : IRequestHandler<Query, List<Domain.Activity>>
        {
            private readonly Persistance.DataContext _context ;
            public Handler(Persistance.DataContext context)
            {
                _context = context;

            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
              var activities=await _context.Activities.ToListAsync(cancellationToken);
            //   Console.WriteLine("aliiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
              return activities;

            }
        }
    }
}