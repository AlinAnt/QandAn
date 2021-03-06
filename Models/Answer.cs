using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Models
{
    public class Answer
    {
        [Required]
        public  int ID {get; set;}

        public Question Question {get; set;}
        public int QuestionID {get; set;}

        public int Rating { get; set; }
        public List<ApplicationUser> Voting { get; set; }

        public string UserId { get; set; }
        [Display(Name = "Создатель ответа")]
        public ApplicationUser User { get; set; }
        
        [Required]
        [Display(Name = "Содержимое ответа")]
        public string AnswerContent {get; set;}
     
        //Время ответа на вопрос
        [Display(Name = "Время создания ответа")]
        public  DateTime AnswerTime {get; set;}
        //Свойства навигации, связанные проблемы
    }
}