using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backbone_Test.DAL
{
    public class TodoRepository : IRepository<Todo>
    {

        private ToDoEntitiesContainer db = new ToDoEntitiesContainer();


        public IQueryable<Todo> FindAll()
        {
            return db.TodoSet;
        }

        public Todo Get(int id)
        {
            return db.TodoSet.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Todo Add(Todo todo)
        {
            db.TodoSet.AddObject(todo);
            return todo;
        }

        public void Delete(Todo todo)
        {
            db.TodoSet.DeleteObject(todo);
            
        }
    }
}