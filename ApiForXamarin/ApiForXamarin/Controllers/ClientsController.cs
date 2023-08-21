using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForXamarin.Data;
using ApiForXamarin.Data.Models;
using Microsoft.AspNetCore.Authorization;
using ApiForXamarin.Data.Dto;

namespace ApiForXamarin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApiForXamarinContext _context;
        private readonly Random random;

        public ClientsController(ApiForXamarinContext context)
        {
            _context = context;
            random = new Random();
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailDto>> GetClient(long id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            var clientDetail = CreateClientDetails(client);

            return clientDetail;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'ApiForXamarinContext.Client'  is null.");
          }
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(long id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private ClientDetailDto CreateClientDetails(Client client)
        {
            var clientDetail = new ClientDetailDto
            {
                Id = client.Id,
                Name = client.Name,
                Dna = client.Dna,
                Latitude = client.Latitude,
                Longitude = client.Longitude,
                Age = random.Next(15, 65),
                Weight = random.Next(40, 120),
                Height = random.Next(150, 210)
            };
            clientDetail.LifeExpectancy = CalculateLifeExpectancy(clientDetail.Age, clientDetail.Weight, clientDetail.Height);
            return clientDetail;
        }

        private double CalculateLifeExpectancy(int age, int weight, int height)
        {
            var BaseLifeExpectancy = 80.0; // Example base life expectancy in years
            var AgeFactor = 0.02; // Example factor for age
            var WeightFactor = 0.01; // Example factor for weight
            var HeightFactor = 0.005; // Example factor for height

            // Calculate the adjustments based on age, weight, and height
            double ageAdjustment = (age - 30) * AgeFactor;
            double weightAdjustment = (weight - 70) * WeightFactor;
            double heightAdjustment = (height - 170) * HeightFactor;

            // Calculate the final life expectancy based on adjustments
            double adjustedLifeExpectancy = BaseLifeExpectancy + ageAdjustment - weightAdjustment - heightAdjustment;

            // Calculate the percentage of life expectancy
            double percentage = (age / adjustedLifeExpectancy) * 100;

            return Math.Round(percentage);
        }

    }
}
