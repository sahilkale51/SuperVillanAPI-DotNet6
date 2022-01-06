using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace SuperVillanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperVillanController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperVillanController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
       public async Task<ActionResult<List<SuperVillan>>> Get()
        {
            return Ok(await _context.SuperVillans.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperVillan>> Get(int id)
        {
            var villan = _context.SuperVillans.FindAsync(id);
            if(villan == null)
            {
                return BadRequest("Sorry the villan is not powerfull enough");
            }
            return Ok(villan);
        }


        [HttpPut]
        public async Task<ActionResult<List<SuperVillan>>> updateVillan(SuperVillan request)
        {
            var dbvillan = await _context.SuperVillans.FindAsync(request.Id);
            if(dbvillan == null)
            {
                return BadRequest("Villan Not found");
            }
            dbvillan.Name = request.Name;
            dbvillan.FirstName = request.FirstName;
            dbvillan.LastName = request.LastName;
            dbvillan.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperVillans.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperVillan>> deleteVillan(int id)
        {
            var dbvillan = await _context.SuperVillans.FindAsync(id);
            if(dbvillan == null)
            {
                return BadRequest("Villan Not Found");
            }

            _context.SuperVillans.Remove(dbvillan);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperVillans.ToListAsync());
            
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperVillan>>> AddVillan(SuperVillan villan)
        {
            _context.SuperVillans.Add(villan);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperVillans.ToListAsync());
        }
    }
}
