using LibraryManagement.Application.ViewModels;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
    {
        public GetAllLoansQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
