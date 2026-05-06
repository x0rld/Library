using FnacDarty.TechnicalTest.Library.Domain.Entities;
using FnacDarty.TechnicalTest.Library.Domain.Interfaces;

namespace FnacDarty.TechnicalTest.Library.Domain.Services;

public class LoanService : ILoanService
{
    public LoanResult LoanBooks(int customerId, IReadOnlyCollection<int> bookIds)
    {
        throw new NotImplementedException();
    }
}