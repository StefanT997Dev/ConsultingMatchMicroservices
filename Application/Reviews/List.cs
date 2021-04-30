using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
    public class List
    {
        public class Query : IRequest<Result<List<Review>>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Review>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Review>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Review>>.Success(await _context.Reviews.Where(r => r.Consultant.Id==request.Id).ToListAsync());
            }
        }
    }
}