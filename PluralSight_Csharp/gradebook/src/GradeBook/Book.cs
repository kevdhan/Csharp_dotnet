using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // inheritance, NamedObject --> Book
    public class NamedObject : object
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    // interface --> pure abstraction
    public interface IBook // "I" --> Stands for instantiation, good practice
    {
        // instantiating everything a book would need
        void AddGrade(double grade); // method
        Statistics GetStatistics();
        string Name { get; }
        string Taco { get; }
        event GradeAddedDelegate GradeAdded; // instantiation of event GradeAddedDelegate

    }

    // abstract class, polymorphism
    // Book inherits from NamedObject
    // here is the foundation of a class book, it should have the ability to add a grade and a Name (inherited by NamedObject)
    public abstract class Book : NamedObject, IBook 
    {
        public Book(string name) : base(name) // because inheriting from NamedObject which has a constructor, this class must need a constructor too
        {
        }

        public string Taco { get; }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();                                                                                                                                                            
        }
    }

    // InMemoryBook (data saved in runtime) inherits from Book (abstract class)
    public class InMemoryBook : Book// making the class public to allow access for Unit Tests
    {
        private List<double> grades;

        /* Having public variables can be dangerous/unsecure
         */
        // public string Name;

        /*
        public string Name // creating a property, a method of encapsulating the private variable
        {
            get
            {
                return name;
            }
            set
            {
                if((String.IsNullOrEmpty(value)))
                {
                    name = value;
                }
            }
        }

        private string name;
        */


        /* 
         * readonly variable
         */
        readonly string category = "Science"; // you can only get value, cannot change

        /*
         * const field/local (const not considered a variable, cannot be modified)
         */
        const string category2 = "Science";
        public const string CATEGORY = "Science"; // convention to write in all caps

        public InMemoryBook(string name) : base(name) // constructor method
        {
            grades = new List<double>();
            Name = name;
            category = "";
            // category2 = ""; --> error because const
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
        public override void AddGrade(double grade) // this AddGrade method is different 
        {
            // adding conditionals to make sure code/gradebook does not break
            if (grade <= 100 && grade >= 0) // using AND statement
            {
                grades.Add(grade);
                if (GradeAdded != null) // when grade added is correct
                {
                    // this = sending this object
                    // EventArgs() = TBA
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                // Console.WriteLine("Invalid Value");

                // throwing an exception if the grade input is not within the specified range
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        // public event delegate --> GradeAddedDelegate above | Instantiating a GradeAddedDelegate
        public override event GradeAddedDelegate GradeAdded;

        /* Method to print out lowest, highest, average grades
         */
        public override Statistics GetStatistics()
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
