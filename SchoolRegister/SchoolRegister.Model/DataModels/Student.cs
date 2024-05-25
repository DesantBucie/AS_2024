using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Student : User
	{
		public virtual Group? Group { get; set; }
		public int? GroupId { get; set; }

		public virtual IList<Grade>? Grades { get; set; }

		public virtual Parent? Parent { get; set; }
		public int? ParentId { get; set; }

		public double AverageGrade { 
			get
			{
				double sum = 0;
				double q = 0;
				foreach(var g in Grades!)
				{
					sum += double.Parse(g.GradeValue.ToString());
					q++;
				}
				return sum / q;
			}
		}
		public IDictionary<string, double> AverageGradePerSubject { 
	
			get
			{
				var dict = new Dictionary<string, double>();
				var d = GradesPerSubject;

				foreach(var g in d)
				{
					var l = new List<double>();
					foreach(var g2 in g.Value)
					{
						l.Add(double.Parse(g2.ToString()));
					}

					dict.Add(g.Key, l.Average());
				}
				return dict;
			}
		}
		public IDictionary<string, List<GradeScale>> GradesPerSubject { 
			get
			{
				var dict = new Dictionary<string, List<GradeScale>>();
				foreach(var g in Grades!)
				{
					if (dict.ContainsKey(g.Subject!.Name))
					{
						dict[g.Subject!.Name].Add(g.GradeValue);
					}
					else
					{
						dict.Add(g.Subject.Name, new List<GradeScale>() {g.GradeValue});
					}
				}
				return dict;
			}
				
		}

	}
}
