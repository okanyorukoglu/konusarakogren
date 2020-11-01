using KOExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOExam.Web.DTOs
{
    public class TestDTO
    {
        public List<ArticleDTO> articleDTOs { get; set; }
        public Test Question { get; set; }
    }
}
