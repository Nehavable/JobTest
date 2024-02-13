using JobOpeningTest.Data;
using JobOpeningTest.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobOpeningTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobOpeningsController : Controller
    {
        private readonly JobOpeningContext dbcontext;
        public JobOpeningsController(JobOpeningContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetLists()
        {
            return Ok(dbcontext.jobOpenings.ToListAsync());
        }
        [HttpGet]
        [Route("{id: guid}")]
        public async Task<IActionResult> GetList([FromRoute] Guid id)
        {
            var data = dbcontext.jobOpenings.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Addvacancies(AddVacancyRequest addVacancyRequest)
        {
            var jobopening = new JobOpening()
            {
                Title = addVacancyRequest.Title,
                DepartmentId = addVacancyRequest.DepartmentId,
                Description = addVacancyRequest.Description,
                LocationId = addVacancyRequest.LocationId,
                ClosingDate = addVacancyRequest.ClosingDate,
            };
            await dbcontext.jobOpenings.AddAsync(jobopening);
            await dbcontext.SaveChangesAsync();
            return Ok(jobopening);
        }
        //[HttpPut]
        //[Route("{id: guid}")]
        //public async Task<IActionResult> Updatevacancy([FromRoute] Guid id, UpdateVacancyRequest updateVacancyRequest)
        //{
        //    var data = dbcontext.jobOpenings.FindAsync(id);
        //    if (data != null)
        //    {
        //        data.Result.Description = updateVacancyRequest.Description;
        //        data.Result.DepartmentId = updateVacancyRequest.DepartmentId;
        //        data.Result.ClosingDate = updateVacancyRequest.ClosingDate;
        //        data.Result.LocationId = updateVacancyRequest.LocationId;
        //        await dbcontext.SaveChangesAsync();
        //        return Ok(data);
        //    }
        //    return NotFound();
        //}

        [HttpDelete]
        [Route("{id: guid}")]
        public async Task<IActionResult> Deletevacancy([FromRoute] Guid id, UpdateVacancyRequest updateVacancyRequest)
        {
            var data = dbcontext.jobOpenings.FindAsync(id);
            if (data != null)
            {
                dbcontext.Remove(data);
                await dbcontext.SaveChangesAsync();
                return Ok(data);
            }
            return NotFound();
        }
    }
}
