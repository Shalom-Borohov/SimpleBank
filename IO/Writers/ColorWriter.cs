using System;

namespace SimpleBank.IO.Writers
{
    public class ColorWriter : Writer, IAbleToColor
    {
        public void ChangeForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
