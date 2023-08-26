using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Interface.ISubject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Subject
{
    public class SubjectBusiness : ISubject
    {
        private readonly Context _context;
        public SubjectBusiness(Context context)
        {
            _context = context;
        }

        public void Delete(StudentManagement.Model.Subjects.Subjects e)
        {
            _context.Entry(e).State = EntityState.Deleted;
        }

        public async Task<List<StudentManagement.Model.Subjects.Subjects>> GetAllSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<StudentManagement.Model.Subjects.Subjects> GetSubjectById(int Id)
        {

            return await _context.Subjects.FindAsync(Id);
        }
        public async Task<StudentManagement.Model.Subjects.Subjects> GetSubjectByName(string Name)
        {

            return await  _context.Subjects.FirstOrDefaultAsync(s => s.SubjectName == Name);
        }

        public bool Post(StudentManagement.Model.Subjects.Subjects e)
        {
            _context.Subjects.Add(e);
            return true;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Put(StudentManagement.Model.Subjects.Subjects e)
        {
            _context.Entry(e).State = EntityState.Modified;
        }
    }
}
