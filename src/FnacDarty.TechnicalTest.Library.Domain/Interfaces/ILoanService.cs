using FnacDarty.TechnicalTest.Library.Domain.Entities;

namespace FnacDarty.TechnicalTest.Library.Domain.Interfaces;

public interface ILoanService
{
    LoanResult LoanBooks(int customerId, IReadOnlyCollection<int> bookIds);
}

