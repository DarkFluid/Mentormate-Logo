using System;

namespace Mentormate
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Drawing drawing = new Drawing(n);
            drawing.DrawMentormateLogo();
        }
    }
}