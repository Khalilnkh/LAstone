using AutoMapper;
using WebApplication1.DTO.Option;
using WebApplication1.DTO.Question;
using WebApplication1.DTO.Quiz;
using WebApplication1.Entities;

namespace QUIZZZ.AutoMappers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Quiz, QuizGetDto>();
            CreateMap<Quiz, QuizDetailGetDto>();
            CreateMap<QuizPostDto, Quiz>();
            CreateMap<QuizPutDto, Quiz>();

            CreateMap<Question, QuestionGetDto>();
            CreateMap<QuestionPostDto, Question>();
            CreateMap<QuestionPutDto, Question>();

            CreateMap<Option, OptionGetDto>();
            CreateMap<OptionPostDto, Option>();
            CreateMap<OptionPutDto, Option>();
        }
    }
}
