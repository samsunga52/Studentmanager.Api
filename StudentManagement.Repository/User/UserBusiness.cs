using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Interface.IExternalUser;
using StudentManagement.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.User
{
    public class UserBusiness : IExternalUser
    {
        private readonly Context _dataContext;
        public UserBusiness(Context dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            try
            {
                return await _dataContext.ApplicationUsers.Where(x => x.Email == username).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<bool> CreateAsync(ExternalUser user)
        {

            try
            {
                _dataContext.ApplicationUsers.Add(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<bool> UpdateAsync(ExternalUser user)
        {
            try
            {
                _dataContext.ApplicationUsers.Update(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ExternalUser> FindByIdAsync(int UserID)
        {
            return await _dataContext.ApplicationUsers.Where(x => x.ExternalUserID == UserID).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfEmailExist(string email)
        {
            try
            {
                return await _dataContext.ApplicationUsers.AnyAsync(x => x.Email == email.ToLower());
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
