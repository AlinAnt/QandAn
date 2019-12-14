using System;
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


        public string UserId { get; set; }
        public AlinUser User { get; set; }
        

        //Содержание ответа
        [Required]
        public string AnswerContent {get; set;}
     
        //Время ответа на вопрос
        public  DateTime AnswerTime {get; set;}
        //Свойства навигации, связанные проблемы
    }
}