using System;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
                        EndDate    = DateTime.Now.AddMonths(3),
                        Students   = new List<Student>
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
                        }
                    },
                    new Course
                    {
                        ID         = 2,
                        Name       = "Web programming II",
                        TemplateID = "T-666-WEPO",
                        StartDate  = DateTime.Now.AddDays(10),
                        EndDate    = DateTime.Now.AddMonths(3),
                        Students   = new List<Student>
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
                            },
                            new Student
                            {
                                SSN = "1306652539",
                                Name = "Jose rodriguez"
                            }
                        }
                    },
                    new Course
                    {
                        ID         = 3,
                        Name       = "History of Jeff Lynne - Don't bring me down",
                        TemplateID = "T-FAN-ELO1",
                        StartDate  = DateTime.Now.AddMonths(12),
                        EndDate    = DateTime.Now.AddMonths(15),
                        Students   = new List<Student>
                        {
                            new Student
                            {
                                SSN = "0101750009",
                                Name = "Dabs"
                            }
                        }
                    }
                };
            }
        }

        [HttpGet(Name="GetCourses")]
        public List<Course> GetCourses()
        {
            return _courses;
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseByID(string id)
        {
            int courseID = Int32.Parse(id);
            Course c = _courses.Find(x => x.ID == courseID);
            if (c == null)
            {
                return NotFound();
            }
            return new ObjectResult(c);
        }

        [HttpPost]
        public IActionResult Create(Course c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _courses.Add(c);
                return CreatedAtRoute("GetCourses","" ,_courses);
            }
        }

        [HttpPut("{cid}")]
        public IActionResult Update(string cid, Course c)
        {
            Console.WriteLine(c.TemplateID + c.Name);
            int courseID = Int32.Parse(cid);
            Console.WriteLine(courseID);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Course updatedCourse = _courses.Find(x => x.ID == courseID);
            if (updatedCourse == null)
            {
                return NotFound();
            }
            
            updatedCourse.ID = c.ID;
            updatedCourse.Name = c.Name;
            updatedCourse.TemplateID = c.TemplateID;
            updatedCourse.StartDate = c.StartDate;
            updatedCourse.EndDate = c.EndDate;

            return new NoContentResult();
        }

        [HttpGet("{id}/students")]
        public IActionResult GetStundentsByCourse(String id) 
        {
            int courseID = Int32.Parse(id);
            Course c = _courses.Find(x => x.ID == courseID);
            if (c == null)
            {
                return NotFound();
            }
            return Json(c.Students);
        }
        
        [HttpPut("{cid}/students")]
        public IActionResult AddStudentToCourse(String cid, Student s) 
        {
            Console.WriteLine(s.SSN + s.Name);
            int courseID = Int32.Parse(cid);
            Console.WriteLine(courseID);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Course updatedCourse = _courses.Find(x => x.ID == courseID);
            if (updatedCourse == null)
            {
                return NotFound();
            }
            
            updatedCourse.Students.Add(s);

            return new NoContentResult();
        }
    }
}
