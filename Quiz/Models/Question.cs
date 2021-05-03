using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    class Question
    {
        public string text { get; set; }
        public int answer { get; set; }

        public Question(string t)
        {
            this.text = t;
            this.answer = -1;
        }
    }
}
