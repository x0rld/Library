using FnacDarty.TechnicalTest.Library.Domain.Entities;

namespace FnacDarty.TechnicalTest.Library.Domain.Interfaces
{
    public interface ILibraryService
    {
        void AddBook(string title, string author);

        IReadOnlyCollection<Book> GetAllBooks();
        void BorrowBooks(int customerId, IReadOnlyCollection<int> bookIds);
    }
}