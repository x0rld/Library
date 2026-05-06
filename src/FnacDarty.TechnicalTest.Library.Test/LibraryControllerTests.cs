using FnacDarty.TechnicalTest.Library.Controllers;
using FnacDarty.TechnicalTest.Library.Domain.Interfaces;
using FnacDarty.TechnicalTest.Library.Models;
using Moq;
using Xunit;

namespace FnacDarty.TechnicalTest.Library.Test;

public class LibraryControllerTests
{
    [Fact]
    public void LibraryController_BorrowBook_returns_one_book_borrowed()
    {
        var libraryServiceMock = new Mock<ILibraryService>();
        var libraryController = new LibraryController(libraryServiceMock.Object);
        const int customerId = 4;
        int[] bookIds = [1];
        var request = new BorrowBookRequest(customerId, bookIds);
        var actualResult = libraryController.BorrowBook(request);
        libraryServiceMock.Verify(x => x.BorrowBooks(customerId, bookIds), Times.Once);

        IReadOnlyCollection<BorrowedBook> borrowedBooks = [
            new(1, DateOnly.FromDateTime(DateTime.Now.AddDays(14)))
        ];
        var expectedResult = new BorrowBookResponse(borrowedBooks,
            []);
        Assert.Same(expectedResult, actualResult);
    }
}