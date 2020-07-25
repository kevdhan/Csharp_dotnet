using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book // making the class public to allow access for Unit Tests
    {
        private List<double> grades;
        public string Name;

        public Book(string name) // constructor method
        {
            grades = new List<double>();
            Name = name;
        }

        /* Method to add grades to grades List
         */
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        /* Method to print out lowest, highest, average grades
         */
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;


            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }
    }
}
