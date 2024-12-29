using System.Linq.Expressions;
using LibraryApplication.Models;
using MySql.Data.MySqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApplication.Repository
{
    public class BookRepository : IBookRepository
    {

        private static MySqlConnection conn;
        public BookRepository()
        {
            string connectionString = "server=localhost;database=dotnet_test;user=root;password=student";
            conn = new MySqlConnection(connectionString);

        }

        void IBookRepository.AddBook(Book book)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO books (Id, Title,Author) values (@Id, @Title, @Author)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.Parameters.AddWithValue("@Id", book.Id);
                mySqlCommand.Parameters.AddWithValue("@Title",book.Title);
                mySqlCommand.Parameters.AddWithValue("@Author",book.Author);

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               ex.ToString();
            }finally { conn.Close(); }
           
        }

        void IBookRepository.DeleteBook(int id)
        {
            
            conn.Open();
            string query = "DELETE FROM books where Id = @Id";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Id",id);
            command.ExecuteNonQuery();
            conn.Close();
        }

        List<Book> IBookRepository.GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM books";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();

                    book.Id = reader.GetInt32("id");
                    book.Author = reader.GetString("Author");
                    book.Title = reader.GetString("Title");
                    books.Add(book);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally 
            { 
                conn.Close(); 
            }
            return books;
        }

        Book IBookRepository.GetBook(int id)
        {
            Book book = new Book();
            try
            {
                conn.Open();
                string query = "SELECT * FROM books where id="+id;
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if(reader.Read())
                {

                    book.Id = reader.GetInt32("id");
                    book.Author = reader.GetString("Author");
                    book.Title = reader.GetString("Title");
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return book;
        }

        void IBookRepository.UpdateBook(Book book)
        {
            conn.Open();
            string query = "Update books set Title = @Title, Author = @Author  where Id = @Id";  
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Id", book.Id);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}
