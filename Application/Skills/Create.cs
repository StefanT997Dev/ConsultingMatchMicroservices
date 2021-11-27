using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Skills
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid CategoryId { get; set; }
            public SkillDto Skill { get; set; }
        }

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
                RuleFor(x => x.CategoryId).NotEmpty();
                RuleFor(x => x.Skill.Id).NotEmpty();
                RuleFor(x => x.Skill.Name).NotEmpty();
            }
		}
		public class Hadler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
           
            public Hadler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.CategoryId);

                if (category == null)
                {
                    return Result<Unit>.Failure("Prosleđeni id za kategoriju ne postoji u našem sistemu");
                }

                var skill = new Skill
                {
                    Id=request.Skill.Id,
                    Name=request.Skill.Name
                };

                if (!Convert.ToBoolean(await _context.Skills.FindAsync(skill.Id)))
                {
                    _context.Skills.Add(skill);
                }

                _context.CategorySkills.Add(new CategorySkill{CategoryId=category.Id,SkillId=skill.Id});

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}