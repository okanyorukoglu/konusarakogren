using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KOExam.Core.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }

        public string QuestionText { get; set; }

        public string A_Option { get; set; }

        public string B_Option { get; set; }

        public string C_Option { get; set; }

        public string D_Option { get; set; }

        public string TrueSolution { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
