using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Models
{
    public class Question
    {
        [Required]
        public int ID { get; set;}

        public string UserId { get; set; }
        public AlinUser User { get; set; }

        [Required]
        [Display(Name = "Вопрос")]
        public string QuestionContent{get; set;}
 
        //Время создания вопроса
        [Display(Name = "Дата создания вопроса")]
        [DataType(DataType.Date)]
        public  DateTime QuestionCreateTime{ get; set;}

        // Похожие ответы
        public  List<Answer> Answers {get; set; }
    }
}