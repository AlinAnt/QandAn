using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using QandAn.Models;

namespace QandAn.Models
{
    public class Answer
    {
        public virtual int AnswerID {get; set;}

        //Внешний ключ, идентификатор вопроса, 
        //соответствующего ответу
        public virtual int QuestionID {get; set;}

        public virtual string AnswerCreator {get; set;}
        //Содержание ответа
        [Required]
        public virtual string AnswerContent {get; set;}
        //Время ответа на вопрос
        public virtual DateTime AnswerTime {get; set;}
        //Свойства навигации, связанные проблемы
        public virtual Question Question {get; set;}
    }
}