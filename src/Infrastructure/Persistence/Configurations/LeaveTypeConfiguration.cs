﻿using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			builder.HasData(
				new LeaveType
				{
					Id = 1,
					Name = "Vacation",
					DefaultDay = 10,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now

				});
			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
		}
	}
}
