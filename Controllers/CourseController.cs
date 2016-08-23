using System;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace WebApplication.Controllers
{

    [Route("/api/courses")]
    public class CoursesController : Controller
    {
        // Note: the variable is static such that the data will persist during
        // the execution of the web service. Data will be lost when the service
        // is restarted (and that is OK for now).

        private static List<Course> _courses;

        public CoursesController()
        {
            if (_courses == null )
            {
                _courses = new List<Course>
                {
                    new Course
                    {
                        ID         = 1,
                        Name       = "Web services",
                        TemplateID = "T-514-VEFT",
                        StartDate  = DateTime.Now,
                        EndDate    = DateTime.Now.AddMonths(3)
                    },
                    new Course
                    {
                        ID         = 2,
                        Name       = "Web programming II",
                        TemplateID = "T-666-WEPO",
                        StartDate  = DateTime.Now.AddDays(10),
                        EndDate    = DateTime.Now.AddMonths(3)
                    },
                                        new Course
                    {
                        ID         = 3,
                        Name       = "How to rock hard",
                        TemplateID = "T-123-TOOL",
                        StartDate  = DateTime.Now.AddMonths(12),
                        EndDate    = DateTime.Now.AddMonths(15)
                    }
                };
            }
        }
        
        [HttpGet]
        public List<Course> GetCourses() 
        {
            return _courses;
        }

        [HttpPost]
        public IActionResult Create([FormBody] Course c) 
        {
            if(c == null) 
            {
                return BadRequest();
            }
            else
            {
                _courses.Add(c);
                return CreatedAtRoute("GetCourses", new { id = c.ID, c});
            }
        }
    } 
}