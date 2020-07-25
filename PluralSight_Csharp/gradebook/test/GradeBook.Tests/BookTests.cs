using System;
using Xunit;
using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] // attributes
        public void BookCalculatesAnAverageGrade()
        {
            /*
             * In this example, we will get a failed unit test
            // arrange
            var x = 5;
            var y = 2;
            var expected = 7;

            // act
            var actual = x * y;

            // assert
            Assert.Equal(expected, actual);
            */


            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            //book.ShowStatistics(); // at first, this method does not return anything

            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
