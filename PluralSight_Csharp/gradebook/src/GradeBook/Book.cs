using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name) // constructor method
        {
            grades = new List<double>();
            this.name = name;
        }

        /* Method to add grades to grades List
         */
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        /* Method to print out lowest, highest, average grades
         */
        public void ShowStatistics()
        {
            var avgGrade = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                lowGrade = Math.Min(grade, lowGrade);
                highGrade = Math.Max(grade, highGrade);
                avgGrade += grade;
            }
            avgGrade /= grades.Count;

            Console.WriteLine($"Lowest Grade: {lowGrade}");
            Console.WriteLine($"Highest Grade: {highGrade}");
            Console.WriteLine($"Average Grade: {avgGrade}");
        }
    }
}
