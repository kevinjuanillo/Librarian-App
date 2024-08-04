using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian_App
{
    public interface IBook
    {
        void MarkAsBorrowed();
        void MarkAsReturned();
        string GetLocation();
    }
}
