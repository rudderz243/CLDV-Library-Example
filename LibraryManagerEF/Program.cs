namespace LibraryManagerEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static void AddBook()
        {
            // get user input
            Console.WriteLine("Book Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Book Price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("CategoryID:");
            int cat_id = Convert.ToInt32(Console.ReadLine());

            // create new instance of our database, using EF
            var db_context = new AppDbContext();
            // use that instance we created to interact with the DB
            using (db_context)
            {
                // create a new Book using the class we created and the input we got.
                var new_book = new Book
                {
                    Title = title,
                    ReplacementPrice = price,
                    CategoryID = cat_id
                };
                // add the book to the database
                db_context.Add(new_book);
                // save changes
                db_context.SaveChanges();

                Console.WriteLine("Added successfully!");
            }
        }
    }
}
