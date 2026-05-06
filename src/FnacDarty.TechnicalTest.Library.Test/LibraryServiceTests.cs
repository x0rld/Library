using FnacDarty.TechnicalTest.Library.Domain.Entities;
using FnacDarty.TechnicalTest.Library.Domain.Interfaces;
using FnacDarty.TechnicalTest.Library.Domain.Services;
using FnacDarty.TechnicalTest.Library.Models;
using Moq;
using Xunit;

namespace FnacDarty.TechnicalTest.Library.Test;

public class LibraryServiceTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock = new();
    private readonly Mock<ILoanService> _loanServiceMock = new();
    private readonly LibraryService _libraryService;

    public LibraryServiceTests()
    {
        _libraryService = new LibraryService(_bookRepositoryMock.Object, _loanServiceMock.Object);
    }

    [Fact]
    public void AddBook_Should_add_book_to_library()
    {
        _bookRepositoryMock.Setup(x => x.GetAll()).Returns([new Book(1, "book 1", "author 1")]);

        _libraryService.AddBook("book 2", "author 2");

        _bookRepositoryMock.Verify(x => x.Add(It.Is<Book>(b => b.Id == 2 && b.Title == "book 2" && b.Author == "author 2")), Times.Once);
    }

    [Fact]
    public void GetAllBooks_should_return_all_books()
    {
        _bookRepositoryMock.Setup(x => x.GetAll()).Returns([new Book(1, "book 1", "author 1")]);

        var books = _libraryService.GetAllBooks();

        Assert.Single(books);
    }

    [Fact]
    public void BorrowBooks_should_add_loan_to_the_book()
    {
        const int bookId = 1;
        const int customerId = 10;

        IReadOnlyCollection<int> bookIdsToBorrow = [bookId];
        _loanServiceMock.Setup(x => x.LoanBooks(customerId, bookIdsToBorrow)).Returns(
            new LoanResult(
                [new ApprovedLoan(bookId, DateOnly.FromDateTime(DateTime.Now.AddDays(14)))],
                []
            ));
        var result = _libraryService.BorrowBooks(customerId, bookIdsToBorrow);

        var expectedResult = new BorrowedBookResult(
            [new BorrowedBook(bookId, DateOnly.FromDateTime(DateTime.Now.AddDays(14)))],
            []
        );
        _loanServiceMock.Verify(x => x.LoanBooks(customerId, bookIdsToBorrow));
        Assert.Equivalent(expectedResult, result);
    }
}