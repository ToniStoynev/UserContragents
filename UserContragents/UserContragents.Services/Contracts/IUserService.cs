using System;
using System.Collections.Generic;
using System.Text;
using UserContragents.Domain;
using UserContragents.Models.BidingModels;
using UserContragents.Models.ViewModels;

namespace UserContragents.Services.Contracts
{
    public interface IUserService
    {
        bool EditUser(EditUserBindingModel model);

        UserViewModel GetUserById(string id);
    }
}
