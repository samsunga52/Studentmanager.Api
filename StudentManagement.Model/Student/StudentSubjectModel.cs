using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Model.Student
{
    public class StudentSubjectModel
    {
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentIDNumber { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEmailAddress { get; set; }
        public int StudentAge { get; set; }
        public int StudentNumber { get; set; }
        public int? UserID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
    }
}
