using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class ToDoController : Controller
    {
        private ToDorepo Repo = new ToDorepo(); 

        public IActionResult Index()
        {
            return View("index", Repo.getToDos());
        }

        public IActionResult Complete(int id)
        {
            Repo.Complete(id); 
            return RedirectToAction("Index");
        }
        public IActionResult Add(string Inhalt, DateTime EndDatum)
        {
            int nextId = Repo.getnextid();
            ToDo neueToDo = new ToDo(nextId, Inhalt, EndDatum);
            Repo.addToDo(neueToDo);

            return RedirectToAction("Index");
        }

        public IActionResult EditView(int id)
        {
            ToDo todo = Repo.getToDos().Single(x => x.Id == id);

            return View("Edit", todo);
        }

        public IActionResult Edit(int Id, string Inhalt, DateTime EndDatum, string Abgehakt)
        {
            ToDo toDoToUpdate = Repo.getbyid(Id);

            toDoToUpdate.Inhalt = Inhalt;
            toDoToUpdate.Enddatum = EndDatum;
            toDoToUpdate.Abgehakt = Abgehakt;

            Repo.Update(toDoToUpdate);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
