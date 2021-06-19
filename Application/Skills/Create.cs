using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Skills
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid CategoryId { get; set; }
            public Skill Skill { get; set; }
        }
        public class Hadler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Hadler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.CategoryId);

                _context.Skills.Add(request.Skill);

                category.Skills.Add(_mapper.Map<CategorySkill>(request.Skill));

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}