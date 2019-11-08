using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    public enum QuestionType
    {
        Undefine=0,
        SingleAnswerQuestion = 1,//Один правильный ответ
        MultiAnswerQuestion = 2,//Несколько правильных ответов
        DigitAnswerQuestion = 3,//Правильный ответ число
        StringAnswerQuestion = 4,//Правильный ответ строка
        EstablishSequenceAnswerQuestion = 5,//Установить последовательность
        EstablishConformityеnswerQuestion = 6,//Установить соответствие
        MultiWordAnswerQuestion = 7//Ответ несколько слов
    };
}
