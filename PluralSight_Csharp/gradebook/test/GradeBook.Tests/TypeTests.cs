using System;
using Xunit;
using GradeBook;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            // SetInt(x);
            SetInt(ref x);

            Assert.Equal(42, x); // x is still 3, and not 42
        }

        private void SetInt(ref int z) // setting value x to 42 by ref
        {
            string pizza = "";
            z = 42;
        }

        // the value of x is "COPIED" into another variable, in this case z
        private void SetInt(int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            // when passing by ref, need to add the keyword "ref"
            // this is designed so that the user knows that they are passing by reference
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        // the ref notation indicates that the input is passed by reference, not value
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name); // everything in C# is pass by value, default
            book.Name = name;
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Kevin";
            var upper_name = MakeUppercase(name); // this new variable will have the name uppercased


            // Assert.Equal("KEVIN", name); // WRONG
            Assert.Equal("Kevin", name);
            Assert.Equal("KEVIN", upper_name); // CORRECT
        }

        private String MakeUppercase(string parameter)
        {
            return parameter.ToUpper(); // ToUpper: returns a copy of a string in all upper
        }

        [Fact] // attributes
        public void GetBookReturnsDifferentObjects()
        {
            // want to test if returning type is same type, in this case book
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }


        [Fact] // attributes
        public void TwoVarsCanReferenceSameObject()
        {
            // want to test if returning type is same type, in this case book
            var book1 = GetBook("Book 1");
            var book2 = book1; // is this getting the reference or a copy of data

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2)); // true if both variables are pointing to same reference

            /* Two variables can reference same object!
             */


        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
