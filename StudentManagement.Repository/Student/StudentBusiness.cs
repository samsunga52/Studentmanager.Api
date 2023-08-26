using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Interface.IStudent;
using StudentManagement.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Student
{
    public class StudentBusiness: IStudents
    {
        private readonly Context _context;
        public StudentBusiness(Context context)
        {
            _context = context;
        }

        public void Delete(StudentManagement.Model.Student.Student e)
        {
            _context.Entry(e).State = EntityState.Deleted;
        }

        public async Task<List<StudentManagement.Model.Student.Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentManagement.Model.Student.Student> GetStudentById(int Id)
        {

            return await _context.Students.FindAsync(Id);
        }

        public async Task<StudentManagement.Model.Student.Student> GetStudentByIdNumber(string Id)
        {

            return await _context.Students.FirstOrDefaultAsync(s => s.StudentIDNumber == Id);

        }

        public bool Post(StudentManagement.Model.Student.Student e)
        {
            _context.Students.Add(e);
            return true;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Put(StudentSubjectModel e)
        {
            try
            {
                StudentManagement.Model.Student.Student s = new StudentManagement.Model.Student.Student();
                StudentManagement.Model.Subjects.Subjects subject = new StudentManagement.Model.Subjects.Subjects();
                s.StudentID = e.StudentID;
                s.StudentFirstName = e.StudentFirstName;
                s.StudentLastName = e.StudentLastName;
                s.StudentIDNumber = e.StudentIDNumber;
                s.StudentAddress = e.StudentAddress;
                s.StudentMobile = e.StudentMobile;
                s.StudentEmailAddress = e.StudentEmailAddress;
                s.StudentAge = e.StudentAge;
                s.StudentNumber = e.StudentNumber;
                s.UserID = e.UserID;
                _context.Entry(s).State = EntityState.Modified;

                subject.SubjectID = e.SubjectID;
                subject.SubjectName = e.SubjectName;
                subject.SubjectDescription = e.SubjectDescription;
                subject.StudentID = e.StudentID;
                subject.UserID = e.UserID;
                _context.Entry(subject).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception d)
            {

                throw;
            }

     
        }

        public async Task<List<StudentSubjectModel>> GetStudentSubjects(int UserId)
        {

            try
            {
                var studentSubjects = await (from student in _context.Students
                                             where student.UserID == UserId
                                             join subject in _context.Subjects on student.StudentID equals subject.SubjectID                                          
                                             select new StudentSubjectModel()
                                             {
                                                 StudentID = student.StudentID,
                                                 StudentFirstName = student.StudentFirstName,
                                                 StudentLastName = student.StudentLastName,
                                                 StudentIDNumber = student.StudentIDNumber,
                                                 StudentAddress = student.StudentAddress,
                                                 StudentMobile = student.StudentMobile,
                                                 StudentEmailAddress = student.StudentEmailAddress,
                                                 StudentAge = student.StudentAge,
                                                 StudentNumber = student.StudentNumber,
                                                 UserID = subject.UserID,
                                                 SubjectID = subject.SubjectID,
                                                 SubjectName = subject.SubjectName,
                                                 SubjectDescription = subject.SubjectDescription

                                             }).Distinct().ToListAsync();

                return studentSubjects;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<StudentSubjectModel> GetStudentSubjectsById(int StudentID)
        {
            var studentSubjects = await (from student in _context.Students
                                         join subject in _context.Subjects on student.StudentID equals subject.StudentID
                                         where student.StudentID == StudentID
                                         select new StudentSubjectModel()
                                         {
                                             StudentID = student.StudentID,
                                             StudentFirstName = student.StudentFirstName,
                                             StudentLastName = student.StudentLastName,
                                             StudentIDNumber = student.StudentIDNumber,
                                             StudentAddress = student.StudentAddress,
                                             StudentMobile = student.StudentMobile,
                                             StudentEmailAddress = student.StudentEmailAddress,
                                             StudentAge = student.StudentAge,
                                             StudentNumber = student.StudentNumber,
                                             UserID = subject.UserID,
                                             SubjectID = subject.SubjectID,
                                             SubjectName = subject.SubjectName,
                                             SubjectDescription = subject.SubjectDescription
                                         }).FirstOrDefaultAsync();

            return studentSubjects;
        }
    }
}
