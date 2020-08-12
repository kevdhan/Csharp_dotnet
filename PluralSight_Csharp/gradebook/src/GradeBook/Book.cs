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

        // switches and enumeration
        public void AddGrade(char letter) // used to be AddLetterGrade
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        /* Method to add grades to grades List
         */
        public void AddGrade(double grade) // this AddGrade method is different 
        {
            // adding conditionals to make sure code/gradebook does not break
            if (grade <= 100 && grade >= 0) // using AND statement
            {
                grades.Add(grade);
            }
            else
            {
                // Console.WriteLine("Invalid Value");

                // throwing an exception if the grade input is not within the specified range
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        /* Method to print out lowest, highest, average grades
         */
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;


            /* foreach method
            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            */


            /* for method
            */
            for (var idx = 0; idx < grades.Count; idx++)
            {
                result.Low = Math.Min(grades[idx], result.Low);
                result.High = Math.Max(grades[idx], result.High);
                result.Average += grades[idx];
            }
            result.Average /= grades.Count;


            /* do while method
            */
            //var index = 0;
            //while (index < grades.Count)
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //}; // last index = count - 1
            //result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}
