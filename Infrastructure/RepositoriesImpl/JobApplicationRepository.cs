using Application.Interfaces.Repositories.JobApplications;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesImpl
{
	public class JobApplicationRepository : Repository<MentorJobApplication>, IJobApplicationRepository
	{
		public JobApplicationRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
