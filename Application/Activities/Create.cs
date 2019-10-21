using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Activities
{
    public class Create
    {
        public class Command:IRequest{
            public int Id { get; set; } 
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }

            public DateTime  Date { get; set; }
            public string  City { get; set; }

            public string Value { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly Persistance.DataContext _context;
            public Handler(Persistance.DataContext context)
            {
                _context=context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity=new Domain.Activity{
                    Id=request.Id,
                    Title=request.Title,
                    Description=request.Description,
                    Category=request.Category,
                    City=request.City,
                    Date=request.Date,
                    Value=request.Value
                };
                _context.Add(activity);
                var res= await _context.SaveChangesAsync()>0;
                if (res) return Unit.Value;
                throw new Exception("Problem to save");

            }
        }
    }
}