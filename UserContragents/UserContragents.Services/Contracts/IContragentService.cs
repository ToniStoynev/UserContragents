using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserContragents.Domain;
using UserContragents.Models;
using UserContragents.Models.ViewModels;

namespace UserContragents.Services.Contracts
{
    public interface IContragentService
    {
        bool AddContragent(AddContragentBindingModel model);

        IQueryable<Contragents> GetAll(string id);

        ContragentDetaislViewModel GetContragentById(string id);
    }
}
