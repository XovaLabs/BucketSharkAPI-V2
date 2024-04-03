using BucketSharkAPI;
using System;
using System.Data;
using System.Data.SQLite;

namespace BucketSharkAPI
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void UpdateCategorySums()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Retrieve all categories
                var categories = GetAllCategories(conn);

                Console.WriteLine(categories);

                foreach (DataRow category in categories.Rows)
                {
                    // Sum payments for each category
                    decimal sum = SumPaymentsForCategory(conn, (int)category["id"]);

                    // Update total sum in the category table
                    UpdateCategoryTotalSum(conn, (int)category["id"], sum);
                }
            }
        }

        private DataTable GetAllCategories(SQLiteConnection conn)
        {
            string sql = "SELECT id, name FROM categories";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        private decimal SumPaymentsForCategory(SQLiteConnection conn, int categoryId)
        {
            string sql = "SELECT SUM(amount) FROM payments WHERE category_id = @categoryId";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                object result = cmd.ExecuteScalar();
                return (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
        }

        private void UpdateCategoryTotalSum(SQLiteConnection conn, int categoryId, decimal sum)
        {
            string sql = "UPDATE categories SET total_sum = @sum WHERE id = @categoryId";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@sum", sum);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
        }
    }

}


