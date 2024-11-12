
using AutoMapper;
using Executor.Models.DbModels;
using Executor.Models.Dtos;

namespace Executor.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Problem, ProblemDto>().ReverseMap();

            CreateMap<ProblemDetail, ProblemDetailDto>().ReverseMap();

            CreateMap<TestCase, TestCaseDto>().ReverseMap();

            CreateMap<Submission, SubmissionDto>().ReverseMap();
        }
}
}
