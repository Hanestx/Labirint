using System;

namespace Labirint
{
    public sealed class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
            
        }
    }
}