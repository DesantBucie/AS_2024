using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {

		// * 1
        public virtual Group? Group { get; set; }
        public int GroupId { get; set; }
		// 1 *
        public virtual IList<Grade>? Grades { get; set; }
        // 1..* 1
        public virtual Parent? Parent { get; set; }
        public int ParentId {  get; set; }

		public double AverageGrade
		{
			get
			{
				double avg = 0;
				int it = 0;
				foreach (var grade in Grades)
				{
					avg += double.Parse(grade.GradeValue.ToString());
					it++;
				}
				return avg / it;
			}
		}

		public IDictionary<string, double> AverageGradePerSubject { get {
                if(Grades != null) {
                    
                    List<string> subjects = [];
                    foreach(var grade in Grades) {
                        if(grade.Subject != null) {
                            if(!subjects.Contains(grade.Subject.Name)) {
                                subjects.Add(grade.Subject.Name);
                            }
                        }
                    }

                    IDictionary<string, double> pairs = new Dictionary<string, double>();
                    double avg = 0.0;
                    foreach(var subject in subjects) {
                        foreach(var grade in Grades) {
                            avg += double.Parse(grade.GradeValue.ToString());
                        }
                        pairs.Add(subject, avg / Grades.Select(g => g.Subject.Name == subject).Count());
                        avg = 0.0;
                    }
                    
                    return pairs;
                }
                return new Dictionary<string, double>(); 
            } }
        public IDictionary<string, List<GradeScale>> GradesPerSubject { get {
                if(Grades != null) {

                    List<string> subjects = [];
                    foreach(var grade in Grades) {
                        if(grade.Subject != null) {
                            if(!subjects.Contains(grade.Subject.Name)) {
                                subjects.Add(grade.Subject.Name);
                            }
                        }
                    }

                    IDictionary<string, List<GradeScale>> pairs = new Dictionary<string, List<GradeScale>>();
                    foreach(var subject in subjects) {
                        List<GradeScale> values = [];
                        foreach(var grade in Grades) {
                            if(grade.Subject != null) { 
                                if(grade.Subject.Name == subject) {
                                    values.Add(grade.GradeValue);
                                }
                            }
                        }
                        pairs.Add(subject, values);
                    }
                    return pairs;
                }
                return new Dictionary<string, List<GradeScale>>();
            }
        }

	}
}
