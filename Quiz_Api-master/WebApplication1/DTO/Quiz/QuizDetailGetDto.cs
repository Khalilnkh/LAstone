using WebApplication1.DTO.Question;
using WebApplication1.Entities;

namespace WebApplication1.DTO.Quiz
{
    public class QuizDetailGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public List<QuestionGetDto>? Questions { get; set; }
    }
}
