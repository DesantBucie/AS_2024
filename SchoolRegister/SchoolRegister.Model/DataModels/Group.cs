﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public virtual IList<Student>? Students { get; set; }
		public virtual IList<Subject>? SubjectGroup { get; set; }
	}
}
