using Microsoft.Data.SqlClient;

namespace LibraryManager
{
    internal class Program
    {
        const string ConnectionString = "Server=lab7L95SR\\SQLEXPRESS; Initial Catalog=LibraryDB; Integrated Security=true; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the LibraryManager App!");
            
            while (true)
            {
                Console.WriteLine("Please select a menu option.");
                Console.WriteLine("1. Add a new book\n2. View all books\n3. Update a books price\n4. Delete a book\n5. Exit");
                int menu_option = Convert.ToInt32(Console.ReadLine());
                switch (menu_option)
                {
                    // "if menu_options is equal to 1"
                    case 1:
                        // add a new book
                        AddBook();
                        break;

                    case 2:
                        // list all books
                        break;

                    case 3:
                        // update a books price
                        break;

                    case 4:
                        // delete a book
                        break;

                    case 5:
                        // exits the program
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
            
        }

        static void AddBook()
        {
            Console.WriteLine("Please enter the title of the book.");
            string book_title = Console.ReadLine();

            Console.WriteLine("Please enter the replacement price of the book.");
            double replacement_price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the CategoryID which the book belongs to.");
            int book_category = Convert.ToInt32(Console.ReadLine());

            // create a new connection to the database, using the connectionString above.
            SqlConnection db_conn = new(ConnectionString);
            // execute the following commands, using the connection we created.
            using (db_conn)
            {
                // open the connection
                db_conn.Open();
                // provide the SQL we would like to execute on the database
                // we use variables with an @ to denote that we will provide the values later. they are placeholders.
                string sql = "INSERT INTO Book VALUES (@title, @price, @cat_id);";

                // create a new command object to interact with the database, using the sql we wrote, and the connection we made
                SqlCommand db_command = new(sql, db_conn);
                // provide the ACTUAL VALUES to replace the PLACEHOLDER VALUES
                db_command.Parameters.AddWithValue("@title", book_title);
                db_command.Parameters.AddWithValue("@price", replacement_price);
                db_command.Parameters.AddWithValue("@cat_id", book_category);

                // run the query on the database
                int rows_affected = db_command.ExecuteNonQuery();
                // close the connection
                db_conn.Close();

                // checks whether the book was added successfully, and prints out to the console.
                if (rows_affected > 0)
                {
                    Console.WriteLine("Book was successfully added.");
                } else
                {
                    Console.WriteLine("There was an error adding the book.");
                }


            }
        }
    }
}
