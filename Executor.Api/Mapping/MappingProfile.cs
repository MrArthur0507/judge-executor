
using AutoMapper;
using Executor.Models.DbModels;
using Executor.Models.Dtos;
using Executor.Models.Dtos.Creational;

namespace Executor.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Problem, ProblemDto>().ReverseMap();

            CreateMap<ProblemDetail, ProblemDetailDto>().ReverseMap();

            CreateMap<CreateProblemDto, Problem>();

            CreateMap<CreateProblemDetailDto, ProblemDetail>();

            CreateMap<TestCase, TestCaseDto>().ReverseMap();

            CreateMap<Submission, SubmissionDto>().ReverseMap();
        }
}
}
