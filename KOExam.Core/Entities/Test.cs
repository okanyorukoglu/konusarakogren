using System;
using System.Collections.Generic;
using System.Text;

namespace KOExam.Core.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string WiredBody { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
