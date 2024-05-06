using System.Collections.ObjectModel;
using System.Windows;
using _4.src.Products;
using Microsoft.Data.SqlClient;

namespace _4.src.Database
{
    public class DBController
    {
        private const string _connectionString = "Data Source=HOME-PC;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True";
        private const string _dbName = "OOP";
        private readonly SqlConnection _connection;

        public DBController() 
        {
            this._connection = new SqlConnection(_connectionString);
        }

        private async void Open()
        {
            try
            {
                await this._connection.OpenAsync();
                MessageBox.Show("Открыто соединение!");
            }
            catch(SqlException e) {
                MessageBox.Show("Не удалось открыть соединение! \n" + e.Message);
            }
        }

        private async void Close() 
        {
            try
            {
                await this._connection.CloseAsync();
                MessageBox.Show("Закрыто соединение!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Не удалось закрыть соединение! \n" + e.Message);
            }
        }

        public void checkAvalibleDB() {
            try 
            {
                _connection.Open();

                SqlCommand sqlCommand = new SqlCommand("USE " + _dbName, _connection);
                sqlCommand.ExecuteReader();

                _connection.Close();
            }
            catch(Exception e) 
            {
                _connection.Close();
                executeQuery("CREATE DATABASE " + _dbName); 
            }
        }

        private void executeQuery(string query) 
        {
            try
            {
                _connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, _connection);
                sqlCommand.ExecuteReader();

                _connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
            }
        }

        public Products.Products getAllProducts() 
        {
            const string query = "use OOP;\n SELECT Sneakers.id,\r\n\t\t\t   Brands.BrandName,\r\n\t\t\t   Sneakers.model,\r\n\t\t\t   Sneakers.color,\r\n\t\t\t   Sneakers.description,\r\n\t\t\t   Sneakers.size,\r\n\t\t\t   Sneakers.price,\r\n\t\t\t   Sneakers.imageSource\r\n\t\tFROM Sneakers INNER JOIN Brands\r\n\t\tON brand_id = Brands.id\r\n";
            ObservableCollection<Sneaker> sneakers = new ObservableCollection<Sneaker>();

            try 
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(query, _connection);
                
                var resultReader = command.ExecuteReader();

                while (resultReader.Read()) 
                {
                    try
                    {
                        ushort _id = Convert.ToUInt16(resultReader.GetValue(0));
                        Sneaker.Brands _brand = Sneaker.GetBrandByName((string)resultReader.GetValue(1));
                        string _model = (string)resultReader.GetValue(2);
                        string _color = (string)resultReader.GetValue(3);
                        string _description = (string)resultReader.GetValue(4);
                        ushort _size = Convert.ToUInt16(resultReader.GetValue(5));
                        ushort _price = Convert.ToUInt16(resultReader.GetValue(6));
                        string? _imageSource = resultReader.GetValue(7) is DBNull ? null : (string?)resultReader.GetValue(7);

                        Sneaker sneaker = new Sneaker(_id, _brand, _model, _description, _size, _color, _price, _imageSource);
                        sneakers.Add(sneaker);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка преобразования данных" + ex.Message);
                    }
                }

                resultReader.Close();
            }
            catch(Exception e) 
            {
                MessageBox.Show("Query Error: error geting all products: " + e.Message);
            } 
            finally
            {
                _connection.Close();
            }
            
            
            return new Products.Products(sneakers);
        }

        public void Insert(Sneaker sneaker) 
        {
            string query = string.Format("USE " + _dbName + ";\n" + "INSERT INTO Sneakers\r\nVALUES({0}, {1}, '{2}', {3}, '{4}', '{5}', {6}, null);", sneaker.Id, ((int)sneaker.Brand + 1), sneaker.Model, sneaker.Size, sneaker.Color, sneaker.Descripcion, sneaker.Price);

            executeQuery(query);
        }

        public void Delete(Sneaker sneaker) 
        {
            string sql = string.Format("USE " + _dbName + ";\n" + "DELETE FROM Sneakers\r\nWHERE id = {0}", sneaker.Id);

            executeQuery(sql);
        }

        public void Alter(Sneaker sneaker)
        {
            this.Delete(sneaker);
            this.Insert(sneaker);
        }

        public void Transact(Sneaker sneaker) 
        {
            _connection.Open();

            SqlTransaction transaction = _connection.BeginTransaction();
            SqlCommand sqlCommand = _connection.CreateCommand();
            sqlCommand.Transaction = transaction;
            transaction.Commit();

            _connection.Close();
        }
    }
}
