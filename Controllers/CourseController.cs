using System;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    [Route("/api/courses")]
    public class CoursesController : Controller
    {
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

        // GET /api/courses
        [HttpGet(Name="GetCourses")]
        public List<Course> GetCourses()
        {
            return _courses;
        }

        // GET /api/courses/1
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

        // DELETE /api/courses/1
        [HttpDelete("{did}")]
        public IActionResult Delete(string did)
        {
            Course c = _courses.Find(x => x.ID == Int32.Parse(did));
            if (c == null)
            {
                return NotFound();
            }
            
            _courses.Remove(c);
            return new NoContentResult();
        }

        // POST /api/courses
        [HttpPost]
        public IActionResult Create(Course c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _courses.Add(c);
            return CreatedAtRoute("GetCourses","" ,_courses);
        }

        // PUT /api/courses/1
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

        // GET /api/courses/1/students
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
        
        // PUT /api/courses/1/students
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
