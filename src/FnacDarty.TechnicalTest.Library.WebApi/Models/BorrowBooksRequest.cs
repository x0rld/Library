namespace FnacDarty.TechnicalTest.Library.WebApi.Models;

public record BorrowBooksRequest(int CustomerId, IReadOnlyCollection<int> BookIds);