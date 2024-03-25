using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.DTO.Option;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public OptionController(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult Update(int id, OptionPutDto optionDto)
        {
            var option = _context.Options.FirstOrDefault(x => x.Id == id);

            if (option is null) return NotFound();

            _mapper.Map(optionDto, option);
            _context.Update(option);
            _context.SaveChanges();

            return Ok();
        }
    }
}
