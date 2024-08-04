using Librarian_App;
using System;
using Librarian_App.BookTypes;
using System.Linq.Expressions;

class Test
{
    static List<IBook> books = new List<IBook>();
    static void Main()
    {
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1 - Add new book");
        Console.WriteLine("2 - Find a book");
        Console.WriteLine("3 - Borrow a book");
        Console.WriteLine("4 - Return a book");
        Console.WriteLine("0 - Exit");

        var input = Convert.ToInt32(Console.ReadLine());
        ReadInput(input);

    }
    static void ReadInput(int input)
    {
        if (input == 0)
        {
            exit();
        }
        else if (input == 1)
        {
            AddNewBook(); 
        }
        else if (input == 2)
        {
            FindBook();
        }
        else if (input == 3)
        {
            BorrowBook();
        }
        else if (input == 4)
        {
            ReturnBook();
        }
        else
        {
            Console.WriteLine("This operation is not supported");
            Main();
        }
        Main();

    }

    static void exit() {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }

    static void AddNewBook() {
        IBook book = null;
        Console.WriteLine("Enter Book Type");
        Console.WriteLine("1 - EBook");
        Console.WriteLine("2 - Audio Book");
        Console.WriteLine("3 - HardCover");
        var bookType = Console.ReadLine();
        Console.WriteLine("Enter Book Title:");
        var bookTitle = Console.ReadLine();


        switch (bookType)
        {
            case "1":
                if (bookTitle != null) 
                {
                    book = new Ebook(bookTitle);

                }
                break;
            case "2":
                if (bookTitle != null)
                {
                    book = new HardCover(bookTitle);
                }
                break;
            case "3":
                if (bookTitle != null)
                {
                   book = new HardCover(bookTitle);
                }
                break;
            default:
                Console.WriteLine("Invalid book type");
                break;
        }

        if (book != null) 
        {
            books.Add(book);
        }
    }

    static void FindBook()
    {
        Console.WriteLine("Enter Book Title:");
        var bookTitle = Console.ReadLine();
        bool bookFound = false;

        //IBook book = books<T>.Find(b => b == bookTitle);
        foreach (var book in books)
        {
            var isBorrowed = book.GetType().GetProperty("isBorrowed").GetValue(book).ToString();
            if (book.GetType().GetProperty("Title").GetValue(book).ToString() == bookTitle) {
                Console.WriteLine($"The book {bookTitle} is {(isBorrowed == "True" ? "borrowed" : "available")}");
                bookFound = true;
                break;
            }
            bookFound = false;
        }
        if (!bookFound) {
            Console.WriteLine($"The book {bookTitle} is not available");
        }

    }
    static void BorrowBook()
    {
        Console.WriteLine("Enter book title:");
        string bookTitle = Console.ReadLine();
        bool bookFound = false;

        foreach (var book in books)
        {
            var isBorrowed = book.GetType().GetProperty("isBorrowed").GetValue(book).ToString();
            if (book.GetType().GetProperty("Title").GetValue(book).ToString() == bookTitle)
            {
                if (isBorrowed == "False")
                {
                    book.MarkAsBorrowed();
                    Console.WriteLine($"The book {bookTitle} has been borrowed");
                }
                else 
                {
                    Console.WriteLine($"The book {bookTitle} is already borrowed");
                }
                bookFound = true;
                break;
            }
            bookFound = false;
        }
        if (!bookFound)
        {
            Console.WriteLine($"The book {bookTitle} is not available");
        }

    }
    static void ReturnBook()
    {
        Console.WriteLine("Enter book title:");
        string bookTitle = Console.ReadLine();
        bool bookFound = false;

        foreach (var book in books)
        {
            var isBorrowed = book.GetType().GetProperty("isBorrowed").GetValue(book).ToString();
            if (book.GetType().GetProperty("Title").GetValue(book).ToString() == bookTitle)
            {
                if (isBorrowed == "True")
                {
                    book.MarkAsReturned();
                    Console.WriteLine($"The book {bookTitle} has been returned");
                }
                else
                {
                    Console.WriteLine($"The book {bookTitle} is available to be borrowed");
                }
                bookFound = true;
                break;
            }
            bookFound = false;
        }
        if (!bookFound)
        {
            Console.WriteLine($"The book {bookTitle} is not available");
        }

    }
}