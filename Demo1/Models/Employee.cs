using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class Employee: IdentityUser
    {

        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
