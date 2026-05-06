using System.Diagnostics;
using FnacDarty.TechnicalTest.Library.Controllers;
using FnacDarty.TechnicalTest.Library.Domain.Interfaces;
using FnacDarty.TechnicalTest.Library.Models;
using FnacDarty.TechnicalTest.Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FnacDarty.TechnicalTest.Library.Test;

public class LibraryControllerTests
{
    [Fact]
    public void BorrowBooks_returns_one_book_borrowed()
    {
        var libraryServiceMock = new Mock<ILibraryService>();
        var libraryController = new LibraryController(libraryServiceMock.Object);
        const int customerId = 4;
        int[] bookIds = [1];
        IReadOnlyCollection<BorrowedBook> borrowedBooks =
        [
            new(1, DateOnly.FromDateTime(DateTime.Now.AddDays(14)))
        ];
        var expectedResult = new BorrowedBookResult(borrowedBooks, []);

        libraryServiceMock.Setup(x => x.BorrowBooks(customerId, bookIds)).Returns(expectedResult);

        var request = new BorrowBooksRequest(customerId, bookIds);
        var actualActionResult = libraryController.BorrowBooks(request);

        var okResult = Assert.IsType<OkObjectResult>(actualActionResult.Result);
        Assert.Same(expectedResult, okResult.Value);
    }
}