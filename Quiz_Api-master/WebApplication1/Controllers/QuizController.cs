using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.DAL;
using WebApplication1.DTO.Option;
using WebApplication1.DTO.Question;
using WebApplication1.DTO.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public QuizController(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var quizzes = _context.Quizzes
                .Select(qz => _mapper.Map<Quiz, QuizGetDto>(qz))
                .ToList();

            if (quizzes is null) return NotFound();

            return Ok(quizzes);
        }

        [HttpPost("Create")]
        public IActionResult Create(QuizPostDto quizDto)
        {

            var newQuiz = _mapper.Map<Quiz>(quizDto);
            _context.Quizzes.Add(newQuiz);
            _context.SaveChanges();

            return Ok(newQuiz);
        }

        [HttpGet("{quizId}")]
        public IActionResult GetById(int quizId)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefault(x => x.Id == quizId);

            if (quiz == null) return NotFound();

            var quizDto = _mapper.Map<QuizDetailGetDto>(quiz);

            return Ok(quizDto);
        }

        [HttpPut("Update /{quizId}")]
        public IActionResult Update(int id, QuizPutDto quizDto)
        {
            var entity = _context.Quizzes.FirstOrDefault(q => q.Id == id);

            if (entity is null) return NotFound();

            _mapper.Map(quizDto, entity);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("Delete/{quizId}")]
        public IActionResult Delete(int id)
        {
            var deleted = _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).FirstOrDefault(q => q.Id == id);

            if (deleted is null) return NotFound();

            _context.Quizzes.Remove(deleted);
            _context.SaveChanges();
            return Ok();
        }

    }
}
