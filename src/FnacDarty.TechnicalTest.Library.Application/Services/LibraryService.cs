using FnacDarty.TechnicalTest.Library.Domain.Entities;
using FnacDarty.TechnicalTest.Library.Domain.Interfaces;
using FnacDarty.TechnicalTest.Library.Models;

namespace FnacDarty.TechnicalTest.Library.Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanService _loanService;

        public LibraryService(IBookRepository bookRepository, ILoanService loanService)
        {
            _bookRepository = bookRepository;
            _loanService = loanService;
        }

        public IReadOnlyCollection<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public BorrowedBookResult BorrowBooks(int customerId, IReadOnlyCollection<int> bookIds)
        {
            var loanResult = _loanService.LoanBooks(customerId, bookIds);
           return BorrowedBookResult.FromLoan(loanResult);
        }

        public void AddBook(string title, string author)
        {
            var allBooks = _bookRepository.GetAll();
            var id = allBooks.Count == 0 ? 1 : allBooks.Max(b => b.Id) + 1;
            var book = new Book(id, title, author);

            _bookRepository.Add(book);
        }
    }
}
