using KOExam.Core.Entities;
using KOExam.Data.Context;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOExam.Data.Repositories
{
    public class WiredRepository : IWiredRepository
    {
        private readonly KOContext _context;

        public WiredRepository(KOContext context)
        {
            _context = context;
        }
        public int CreateExam(Test test)
        {
            _context.Database.EnsureCreated();
            _context.Tests.Add(test);
            int insertResult =  _context.SaveChanges();
            return insertResult;

           
            
        }

        

        public IEnumerable<Test> GetAllArticles()
        {
           return _context.Tests.ToList();
        }

 

        public Test GetById(int id)
        {
            return _context.Tests.Find(id);
        }

        
    }
}
