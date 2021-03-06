using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Course
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string TemplateID {get; set;}
        [Required]
        public int ID {get; set;}
        [Required]
        public DateTime StartDate {get; set;}
        [Required]
        public DateTime EndDate {get; set;}

        public List<Student> Students {get; set;}

    }
}
