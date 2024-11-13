using AutoMapper;
using Executor.DataAccess.AppContext;
using Executor.Models.DbModels;
using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.CRUD.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Executor.Services.CRUD.Implementations
{
    public class ProblemDetailService : IProblemDetailService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProblemDetailService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProblemDetailDto>> GetAllProblemDetailsAsync()
        {
            var problemDetails = await _context.ProblemDetails.ToListAsync();
            return _mapper.Map<IEnumerable<ProblemDetailDto>>(problemDetails);
        }

        public async Task<ProblemDetailDto> GetProblemDetailAsync(Guid id)
        {
            var problemDetail = await _context.ProblemDetails
                .FirstOrDefaultAsync(pd => pd.Id == id);

            if (problemDetail == null)
            {
                return null; 
            }

            return _mapper.Map<ProblemDetailDto>(problemDetail);
        }

        
        public async Task<IEnumerable<ProblemDetailDto>> GetProblemDetailsByProblemIdAsync(Guid problemId)
        {
            var problemDetails = await _context.ProblemDetails
                .Where(pd => pd.ProblemId == problemId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProblemDetailDto>>(problemDetails);
        }

       
        public async Task<ProblemDetailDto> CreateProblemDetailAsync(CreateProblemDetailDto createProblemDetailDto)
        {
            var problemDetail = _mapper.Map<ProblemDetail>(createProblemDetailDto);
            _context.ProblemDetails.Add(problemDetail);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProblemDetailDto>(problemDetail);
        }

        
        public async Task<ProblemDetailDto> UpdateProblemDetailAsync(ProblemDetailDto problemDetailDto)
        {
            var existingProblemDetail = await _context.ProblemDetails
                .FirstOrDefaultAsync(pd => pd.Id == problemDetailDto.Id);

            if (existingProblemDetail == null)
            {
                return null; 
            }

            _mapper.Map(problemDetailDto, existingProblemDetail);

            _context.ProblemDetails.Update(existingProblemDetail);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProblemDetailDto>(existingProblemDetail);
        }

        
        public async Task<bool> DeleteProblemDetailAsync(Guid id)
        {
            var problemDetail = await _context.ProblemDetails
                .FirstOrDefaultAsync(pd => pd.Id == id);

            if (problemDetail == null)
            {
                return false; 
            }

            _context.ProblemDetails.Remove(problemDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
