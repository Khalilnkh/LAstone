using WebApplication1.DTO.Question;

namespace WebApplication1.DTO.Quiz
{
    public class QuizPostDto
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public List<QuestionPostDto> Questions { get; set; }
    }
}
