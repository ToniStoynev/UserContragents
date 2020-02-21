using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserContragents.Domain
{
    public class AppUsers : IdentityUser
    {
        public AppUsers()
        {
            this.Contragents = new HashSet<Contragents>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Contragents> Contragents { get; set; }
    }
}
