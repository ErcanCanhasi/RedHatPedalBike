using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedHatPedalBike.Models;

namespace RedHatPedalBike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly BikedbContext _bike;

        public BikeController(BikedbContext bike)
        {
            _bike = bike;

        }
        // GET: api/<BikeController>
        [HttpGet]
        public IActionResult Get()
        {
            var bike = _bike.Bike;
            return Ok(bike);
        }


        public Bike GetById(int id)
        {
            var bike = _bike.Bike.Find(id);
            if (bike == null) { throw new KeyNotFoundException("Bike Not Found"); }
            return bike;
        }


        // GET api/<BikeController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _bike.Bike.Find(id);
            return Ok(emp);
        }

        // POST api/<BikeController>
        [HttpPost]
        public IActionResult Post([FromBody] Bike model)
        {

            var bikeExist = _bike.Bike.Any(e => e.Name == model.Name);
            if (bikeExist == true)
            {
                return Ok(new { Message = "Bike Already Created" });

            }

            _bike.Add(model);
            _bike.SaveChanges();

            return Ok(new { Message = "Bike Created" });
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Bike model)
        {

            _bike.Bike.Attach(model);
            _bike.Entry(model).State = EntityState.Modified;


            // _bike.Bike.Update(model);
            _bike.SaveChanges();

            return Ok(new { Message = "Bike Updated" });
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bike = GetById(id);

            _bike.Bike.Remove(bike);
            _bike.SaveChanges();

            return Ok(new { Message = "Bike Deleted" });

        }
    }
}
