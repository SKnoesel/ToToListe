using System.Collections.Generic;
using MvcMovie.Models;
using System.IO;
using System.Text.Json;

namespace MvcMovie.Controllers
{
    public class ToDorepo
    {
        public ToDorepo()
        {
            if (!File.Exists("ToDos.txt"))
            {
                File.WriteAllText("ToDos.txt", "");
                GenerateToDos();

            }
        }

        public List<ToDo> getToDos() {

            string Data = File.ReadAllText("ToDos.txt");
            if (string.IsNullOrEmpty(Data))
            {
                return new List<ToDo>();
            }
            List<ToDo> ToDos = JsonSerializer.Deserialize<List<ToDo>>(Data);
            return ToDos;


        }

        public ToDo getbyid(int id)
        {
            return getToDos().Single(x => x.Id == id);
        }

        public void addToDo(ToDo ersteToDo) {

            List<ToDo> ToDos = getToDos();
            ToDos.Add(ersteToDo);

            string Data = JsonSerializer.Serialize(ToDos);
            File.WriteAllText("ToDos.txt", Data);

        }
        public void Update(ToDo ToDo)
        {
            Delete(ToDo.Id);
            addToDo(ToDo);
        }
        private void GenerateToDos()
        {
            ToDo ersteToDo = new ToDo(1, "Daten Persistiern", new DateTime(2022, 11, 02));
            ToDo zweiteToDo = new ToDo(2 , "Neue ToDo Erzugen", new DateTime(2022, 11, 02));
            ToDo dritteToDo = new ToDo(3, "Bau eine Tablelle", new DateTime(2022, 11, 02));
            ToDo vierteToDo = new ToDo(4, "Bau ein Update Funktion", new DateTime(2022, 11, 02));
            ToDo fünfteToDo = new ToDo(5, "Bau ein Delete Funktion", new DateTime(2022, 11, 02));

            addToDo(ersteToDo);
            addToDo(zweiteToDo);
            addToDo(dritteToDo);
            addToDo(vierteToDo);
            addToDo(fünfteToDo);
        }
        public int getnextid()
        {
            List<ToDo> ToDos = getToDos();
            return ToDos.MaxBy(x => x.Id).Id + 1;
        }
        public void Complete(int ID)
        {
            List<ToDo> ToDos = getToDos();
            ToDo toDoToUpdate = ToDos.Single(x => x.Id == ID);

            toDoToUpdate.Abgehakt = "Ja";

            string Data = JsonSerializer.Serialize(ToDos);
            File.WriteAllText("ToDos.txt", Data);

        }
        public void Delete(int ID)
        {
            List<ToDo> ToDos = getToDos();
            ToDo toDoToDelete = ToDos.Single(x => x.Id == ID);
            ToDos.Remove(toDoToDelete);
            string Data = JsonSerializer.Serialize(ToDos);
            File.WriteAllText("ToDos.txt", Data);
        }
    }
}
