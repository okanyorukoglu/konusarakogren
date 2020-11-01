using KOExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOExam.Data.Repositories
{
    public interface IWiredRepository
    {
        IEnumerable<Test> GetAllArticles();
        int CreateExam(Test test);

        Test GetById(int id);


        

        

    }
}
