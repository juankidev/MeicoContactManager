using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meico.Models.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Company { get; set; }

        public string? Note { get; set; }
    }
}
