using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSTVIModel;

namespace Client
{
    class EdmService
    {
        WSTVIEntities _entity;

        public EdmService()
        {
            _entity = new WSTVIEntities(new Uri("http://localhost:54801/WcfDataService1.svc/"));
        }

        public void Print()
        {
            Console.WriteLine("--- Notes ---");
            foreach (var student in _entity.Students)
            {
                Console.WriteLine($"{student.Id} - {student.Name}");
                foreach (var note in _entity.Notes.Where(i => i.StudentId == student.Id))
                {
                    Console.WriteLine($" {note.Subj}:{note.Note1} ");
                }
            }
        }

        public void Add(string name)
        {
            Student student = new Student() { Name = name };
            _entity.AddToStudents(student);
            _entity.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var student = _entity.Students.AsEnumerable().First(i => i.Id == id);
            student.Name = name;
            _entity.UpdateObject(student);
            _entity.SaveChanges();
        }
    }
}
