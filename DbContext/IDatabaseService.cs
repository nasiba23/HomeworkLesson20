using System.Collections.Generic;

namespace HomeworkLesson20.DbContext
{
    public interface IDatabaseService
    {
        List<T> GetList<T>();
    }
}