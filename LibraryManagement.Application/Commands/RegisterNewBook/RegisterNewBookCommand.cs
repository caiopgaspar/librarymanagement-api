using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.RegisterNewBook
{
    public class RegisterNewBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int YearOfPublication { get; set; }
    }
}
