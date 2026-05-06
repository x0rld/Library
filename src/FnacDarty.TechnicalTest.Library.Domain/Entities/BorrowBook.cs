using FnacDarty.TechnicalTest.Library.Domain.Entities;

namespace FnacDarty.TechnicalTest.Library.Models;

public record BorrowedBookResult(
    IReadOnlyCollection<BorrowedBook> BorrowedBook,
    IReadOnlyCollection<RejectedBook> RejectedBooks)
{
    public static BorrowedBookResult FromLoan(LoanResult loanResult)
    {
        return new BorrowedBookResult(
            loanResult.ApprovedLoan.Select(b => new BorrowedBook(b.BookId, b.DueAt)).ToArray(),
            loanResult.RejectedLoan.Select(r => new RejectedBook(r.BookId, r.ReasonCode, r.ReasonLabel)).ToArray());
    }
}

public record RejectedBook(int BookIed, string ReasonCode, string ReasonLabel);

public record BorrowedBook(int BookId, DateOnly DueAt);