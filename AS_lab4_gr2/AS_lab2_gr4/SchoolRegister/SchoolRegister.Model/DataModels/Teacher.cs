﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public string Title {  get; set; } = string.Empty;

        // 1 *
        public virtual IList<Subject>? Subjects { get; set; }
    }
}
