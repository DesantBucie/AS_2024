using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class SubjectGroup
	{
		// * 1
		public virtual Subject? Subject { get; set; }
		public int SubjectId { get; set; }
		// * 1
		public virtual Group? Group { get; set; }
		public int GroupId {  get; set; } 
	}
}
