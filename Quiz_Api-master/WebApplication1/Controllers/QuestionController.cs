using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.DTO.Question;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public QuestionController(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult Update(int id, QuestionPutDto questionDto)
        {
            var entity = _context.Questions.FirstOrDefault(x => x.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(questionDto, entity);

            _context.Update(entity);
            _context.SaveChanges();

            return Ok();
        }
    }
}
