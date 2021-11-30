using lab03.Models;
using System.Web.Http;
using System.Web.WebPages;
using System.Linq;
using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace lab03.Controllers
{

    public class StudentsController : ApiController
    {
        private StudentContext DB = new StudentContext();

        // GET api/students
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}")]
        public IHttpActionResult GetStudents(
            string path = "students.json",

            string name = null,
            string columns = "",
            string phone = null,

            int offset = 0,
            int limit = 5,

            string globalLike = "",
            string orderby = "off",

            int minId = 0,
            int maxId = 10000
        )
        {
            var students = new List<Student>();
            var sqlQuery = string.Empty;
            string orderBy;

            bool isStudListFilled = false;

            if (orderby.Equals("on")) { orderBy = "name"; }
            else { orderBy = "id"; }

            if (globalLike.IsEmpty())
            {
                string sqlName = "";
                if (name != null) { sqlName = " AND name LIKE '%' + @P2 + '%' "; }

                string sqlPhone = "";
                if (phone != null) { sqlPhone = "AND phone = @P3 "; }
                    
                sqlQuery = "SELECT * FROM Students " +
                    "WHERE id > @P0 AND id < @P1 " + sqlName + sqlPhone +
                    "ORDER BY " + orderBy + " " +
                    "OFFSET @P4 ROWS FETCH NEXT @P5 ROWS ONLY";

                students = DB.Students.SqlQuery(sqlQuery, 
                    minId, 
                    maxId, 
                    name, 
                    phone, 
                    offset, 
                    limit).ToList();

                isStudListFilled = true;
            }
            else
            {
                sqlQuery = "SELECT * FROM Students " +
                    "WHERE id > @P0 AND " +
                    "id < @P1 " +
                    "AND (id LIKE '%' + @P2 + '%' OR name LIKE '%' + @P2 + '%' " +
                    "OR phone LIKE '%' + @P2 + '%') " +
                    "ORDER BY " + orderBy + " " +
                    "OFFSET @P3 ROWS FETCH NEXT @P4 ROWS ONLY";

                students = DB.Students.SqlQuery(sqlQuery, 
                    minId, 
                    maxId, 
                    globalLike, 
                    offset, 
                    limit).ToList();

                isStudListFilled = true;
            }

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);

            students.ForEach(student => student._links = 
                new HateoasLinks(linkStudents, linkStudents + student.id));

            columns = columns.ToLower();

            if (!columns.Contains("name") && isStudListFilled)
                students.ForEach(stud => stud.name = null);
                
            if (!columns.Contains("phone") && isStudListFilled)
                students.ForEach(stud => stud.phone = null);

            if (!columns.Contains("id") && isStudListFilled)
                students.ForEach(stud => stud.id = 0);

            if (path.Equals("students.json")) { return Json(students); }

            return Ok(students);
        }

        // GET api/students/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult Get(int? id, string path = "students.json")
        {
            try
            {
                var student = DB.Students.Where(stud => stud.id == id).FirstOrDefault();
                string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);

                student._links = new HateoasLinks(
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")), 
                    linkStudent);

                if(path.Equals("students.json")) { return Json(student); }

                return Ok(student);
            }
            catch (Exception)
            {
                return Content(
                    HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }
        }

        // POST api/students
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}")]
        public IHttpActionResult PostStudent(Student student, string path = "students.json")
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Students.Add(student);
            DB.SaveChanges();

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.id);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        // PUT api/students/5
        [HttpPut]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult PutStudent(int id, Student student, string path = "students.json")
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            if (id != student.id)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Entry(student).State = EntityState.Modified;

            try { DB.SaveChanges(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Content(HttpStatusCode.BadRequest, 
                        new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                }
                else { throw; }
            }

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.id);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        // DELETE api/students/5
        [HttpDelete]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult DeleteStudent(int id, string path = "students.json")
        {
            Student student = DB.Students.Find(id);
            if (student == null)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Students.Remove(student);
            DB.SaveChanges();

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.id);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { DB.Dispose(); }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return DB.Students.Count(stud => stud.id == id) > 0;
        }
    }
}
