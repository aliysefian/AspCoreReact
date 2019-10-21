using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{


    [EnableCors("AllowAll")]

    [Route("api/[controller]")]
    [ApiController]
    

    public class ValuesController : ControllerBase
    {
        private readonly Persistance.DataContext _context;
        public ValuesController(Persistance.DataContext context)
        {
            this._context=context;
        }

        // GET api/values
        
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Value>>> Get()
        {
            var val=await _context.Activities.ToListAsync();
            return Ok(val);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Value>> Get(int id)
        {
            var val=await _context.Values.SingleOrDefaultAsync(m=>m.Id==id);
            return Ok(val);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
