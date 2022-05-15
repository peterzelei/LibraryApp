using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime DateOfBorrowing { get; set; }

        public override string ToString()
        {
            return $"{Author}: {Title}";
        }
    }
}
