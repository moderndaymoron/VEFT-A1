using System;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    [Route("/api/students")]
    public class StudentController : Controller
    {
        // Note: the variable is static such that the data will persist during
        // the execution of the web service. Data will be lost when the service
        // is restarted (and that is OK for now).

        private static List<Student> _students;

        public  StudentController()
        {
            if (_students == null )
            {
                _students = new List<Student>
                {
                    new Student
                    {
                        SSN = "1306872539",
                        Name = "Ragnar Ingi Ragnarsson"
                    },
                    new Student 
                    {
                        SSN = "0307843249",
                        Name = "Eiríkur Birkir Ragnarsson"
                    }           
                };
            }

        }
    } 
}