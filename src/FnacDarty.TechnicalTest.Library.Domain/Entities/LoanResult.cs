namespace FnacDarty.TechnicalTest.Library.Domain.Entities;

public record LoanResult(
    IReadOnlyCollection<ApprovedLoan> ApprovedLoan,
    IReadOnlyCollection<RejectedLoan> RejectedLoan);

public record RejectedLoan(int BookId, string ReasonCode, string ReasonLabel);

public record ApprovedLoan(int BookId, DateOnly DueAt);