using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserContragents.Data;
using UserContragents.Domain;
using UserContragents.Models.BidingModels;
using UserContragents.Models.ViewModels;

namespace UserContragents.Services.Contracts
{
    public class UserService : IUserService
    {
        private readonly UserContragetnsDbContext db;

        public UserService(UserContragetnsDbContext db)
        {
            this.db = db;
        }

        public bool EditUser(EditUserBindingModel model)
        {
            var userFromDb = this.db.Users.SingleOrDefault(x => x.Id == model.Id);

            userFromDb.UserName = model.Username;
            userFromDb.Name = model.Name;
            userFromDb.Password = model.Password;

            db.Update(userFromDb);

            int result = this.db.SaveChanges();

            return result > 0;
        }

        public UserViewModel GetUserById(string id)
        {
            var userFromDb = this.db.Users.FirstOrDefault(x => x.Id == id);

            var viewModel = new UserViewModel
            {
                Username = userFromDb.UserName,
                Name = userFromDb.Name,
                Password = userFromDb.Password
            };

            return viewModel;
        }
    }
}
