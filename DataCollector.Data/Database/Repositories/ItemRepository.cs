using Dapper;
using DataCollector.Data.Database.Dtos;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DataCollector.Database.Repositories
{
    public class ItemRepository
    {
        private string Schema = @"[dbo]";
        private string ConnectionString;

        public ItemRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DataCollector"].ConnectionString;
        }

        public IEnumerable<ItemDto> GetAllItems()
        {
            IEnumerable<ItemDto> items;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetAllItems";

                items = connection.Query<ItemDto>(sql, commandType: System.Data.CommandType.StoredProcedure);

            }
            return items;
        }

        public ItemDto GetItemById(int id)
        {
            ItemDto item;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetSetupByGameCode";

                item = connection.Query<ItemDto>(sql,
                    new { Id = id },
                    commandType: System.Data.CommandType.StoredProcedure)?.FirstOrDefault();

            }
            return item;
        }

        public void AddItem(ItemDto itemDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.AddItem";

                connection.Execute(sql,
                                    new
                                    {
                                        Name = itemDto.Name
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void UpdateItem(ItemDto itemDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.UpdateItem";

                connection.Execute(sql,
                                    new
                                    {
                                        Id = itemDto.Id,
                                        Name = itemDto.Name
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void DeleteItem(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.DeleteItem";

                connection.Execute(sql,
                                    new
                                    {
                                        Id = id
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }


    }
}