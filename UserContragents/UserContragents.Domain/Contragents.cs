using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserContragents.Domain
{
    public class Contragents
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string DDSNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public AppUsers User { get; set; }
    }
}
