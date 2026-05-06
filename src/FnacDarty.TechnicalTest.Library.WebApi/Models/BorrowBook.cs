namespace FnacDarty.TechnicalTest.Library.Models;

public record BorrowBookRequest(int CustomerId, IReadOnlyCollection<int> BookIds);

public record BorrowBookResponse(
    IReadOnlyCollection<BorrowedBook> BorrowedBook,
    IReadOnlyCollection<RejectedBook> RejectedBooks);

public record RejectedBook(int BookIed, string ReasonCode, string ReasonLabel);

public record BorrowedBook(int BookId, DateOnly DueAt);