using System.Collections.Generic;
using HomeworkLesson20.Models;

namespace HomeworkLesson20.DbContext
{
    public interface IDatabaseService
    {
        List<T> GetList<T>();
        void Create(Person person);
        Person SearchId(int id);
        Person SearchName(string name, string lastName, string middleName);
    }
}