using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian_App.BookTypes
{
    public class AudioBook : IBook
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public bool isBorrowed { get; set; }

        public AudioBook(string Title)
        {
            this.Title = Title;
            Location = "Library";
            isBorrowed = false;

        }
        public string GetLocation()
        {
            return Location;
        }

        public void MarkAsBorrowed()
        {
            isBorrowed = true;
        }

        public void MarkAsReturned()
        {
            isBorrowed = false;
        }
    }
}

