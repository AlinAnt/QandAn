using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using QandAn.Models;

namespace QandAn.Models
{
    public class Question
    {
        public virtual int QuestionID { get; set;}

        //Создатель вопроса
        [Display( Name = "Автор вопроса")]
        public virtual string QuestionCreator {get; set;}

        //Содержание вопроса
        [Display(Name = "Вопрос")]
        [Required]
        public virtual string QuestionContent{get; set;}
 
        //Время создания вопроса
        [Display(Name = "Дата создания вопроса")]
        [DataType(DataType.Date)]
        public virtual DateTime QuestionCreateTime{ get; set;}

        // Похожие ответы
        public virtual List<Answer> Answers {get; set; }
    }
}