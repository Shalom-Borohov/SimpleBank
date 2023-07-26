using System;

namespace SimpleBank.IO.Writers
{
    public class ColorWriter : Writer, IAbleToColor
    {
        public void ChangeForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void ResetForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
