using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public string NameOfBorrower { get; set; }
        public DateTime DateOfBorrowing { get; set; }
        public DateTime DateOfReturn { get; set; }

        public override string ToString()
        {
            return $"{Author}: {Title}";
        }

        public void Initialize()
        {
            IsBorrowed = false;
            NameOfBorrower = "";
            DateOfBorrowing = DateTime.MinValue;
            DateOfReturn = DateTime.MinValue;
        }
    }
}
