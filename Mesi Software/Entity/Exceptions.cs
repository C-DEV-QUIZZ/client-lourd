using System;
using System.Collections.Generic;
using System.Text;

namespace Mesi_Software.Entity
{
    public static class Exceptions
    {
        public class QuestionsException : Exception
        {
            public QuestionsException(string message) : base(message){}
        }
    }
}
