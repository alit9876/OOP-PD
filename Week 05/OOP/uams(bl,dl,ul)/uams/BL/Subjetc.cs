﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.DL;
using uams.UI;
namespace uams.BL
{
    class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;
        public Subject(string code, string type, int creditHours, int subjectFees)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFees = subjectFees;

        }
        public string getCode()
        {
            return code;
        }
        public string getType()
        {
            return type;
        }
        public int getCreditHours()
        {
            return creditHours;
        }
        public int getSubjectFees()
        {
            return subjectFees;
        }
    
}
}
