using Executor.Models.DbModels;
using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.DataAccess.AppContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Executor.Services.CRUD.Implementations
{
    public class ProblemService : IProblemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProblemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<ProblemDto>> GetAllProblemsAsync()
        {
            var problems = await _context.Problems.ToListAsync();
            return _mapper.Map<IEnumerable<ProblemDto>>(problems);
        }

        
        public async Task<ProblemDto> GetProblemAsync(Guid id)
        {
            var problem = await _context.Problems
                .FirstOrDefaultAsync(p => p.Id == id);

            if (problem == null)
            {
                return null; 
            }

            return _mapper.Map<ProblemDto>(problem);
        }

        
        public async Task<ProblemDto> CreateProblemAsync(CreateProblemDto createProblemDto)
        {
            var problem = _mapper.Map<Problem>(createProblemDto); 
            _context.Problems.Add(problem);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProblemDto>(problem); 
        }

        
        public async Task<ProblemDto> UpdateProblemAsync(ProblemDto problemDto)
        {
            var existingProblem = await _context.Problems
                .FirstOrDefaultAsync(p => p.Id == problemDto.Id);

            if (existingProblem == null)
            {
                return null; 
            }

            
            _mapper.Map(problemDto, existingProblem);

            _context.Problems.Update(existingProblem);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProblemDto>(existingProblem); 
        }

      
        public async Task<bool> DeleteProblemAsync(Guid id)
        {
            var problem = await _context.Problems
                .FirstOrDefaultAsync(p => p.Id == id);

            if (problem == null)
            {
                return false; 
            }

            _context.Problems.Remove(problem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
