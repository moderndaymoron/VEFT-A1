using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class Student
    {
        [Required]
        public string SSN {get; set;}
        [Required]
        public string Name {get; set;}
    }
}
