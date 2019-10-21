using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [EnableCors("AllowAll")]

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivityController(IMediator mediator )
        {
            _mediator=mediator;
        }
        // private readonly Persistance.DataContext _db;

        // public ActivityController(Persistance.DataContext db )
        // {
        //     _db=db;
        // }
        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> List(){
                    return await _mediator.Send(new List.Query());
        //    var sss=await _db.Activities.ToListAsync();
        //    return Ok(sss);
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command){
           return await _mediator.Send(command) ;
        }
    }
}