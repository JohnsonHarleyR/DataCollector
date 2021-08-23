using Dapper;
using DataCollector.Data.Database.Dtos;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DataCollector.Database.Repositories
{
    public class AnswerRepository
    {
        private string Schema = @"[dbo]";
        private string ConnectionString;

        public AnswerRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DataCollector"].ConnectionString;
        }

        public IEnumerable<AnswerDto> GetAllItemAnswers()
        {
            IEnumerable<AnswerDto> items;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetAllItemAnswers";

                items = connection.Query<AnswerDto>(sql, commandType: System.Data.CommandType.StoredProcedure);

            }
            return items;
        }

        public IEnumerable<AnswerDto> GetItemAnswersByAnswers(int? questionId, int? answerId)
        {
            IEnumerable<AnswerDto> answers;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetItemAnswersByAnswers";

                answers = connection.Query<AnswerDto>(sql,
                    new
                    {
                        QuestionId = questionId,
                        AnswerId = answerId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
            return answers;
        }

        public IEnumerable<AnswerDto> GetItemAnswersByItem(int? itemId)
        {
            IEnumerable<AnswerDto> answers;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetItemAnswersByItem";

                answers = connection.Query<AnswerDto>(sql,
                    new
                    {
                        ItemId = itemId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
            return answers;
        }

        public AnswerDto GetItemAnswerById(int id)
        {
            AnswerDto answer;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetItemAnswerById";

                answer = connection.Query<AnswerDto>(sql,
                    new { Id = id },
                    commandType: System.Data.CommandType.StoredProcedure)?.FirstOrDefault();

            }
            return answer;
        }

        public void AddItemAnswer(AnswerDto answerDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.AddItemAnswer";

                connection.Execute(sql,
                                    new
                                    {
                                        ItemId = answerDto.ItemId,
                                        QuestionId = answerDto.QuestionId,
                                        AnswerId = answerDto.AnswerId
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void UpdateItem(AnswerDto answerDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.UpdateItemAnswer";

                connection.Execute(sql,
                                    new
                                    {
                                        Id = answerDto.Id,
                                        ItemId = answerDto.ItemId,
                                        QuestionId = answerDto.QuestionId,
                                        AnswerId = answerDto.AnswerId
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void DeleteItemAnswer(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.DeleteItemAnswer";

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
