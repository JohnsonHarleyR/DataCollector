using Dapper;
using DataCollector.Data.Database.Dtos;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DataCollector.Data.Database.Repositories
{
    public class QuestionRepository
    {

        private string Schema = @"[dbo]";
        private string ConnectionString;

        public QuestionRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DataCollector"].ConnectionString;
        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            IEnumerable<QuestionDto> questions;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetAllQuestions";

                questions = connection.Query<QuestionDto>(sql, commandType: System.Data.CommandType.StoredProcedure);

            }
            return questions;
        }

        public QuestionDto GetQuestionById(int id)
        {
            QuestionDto question;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetQuestionById";

                question = connection.Query<QuestionDto>(sql,
                    new { Id = id },
                    commandType: System.Data.CommandType.StoredProcedure)?.FirstOrDefault();

            }
            return question;
        }

        public IEnumerable<QuestionDto> GetQuestionsByDependencies(int? dependentQuestionId, int? dependentAnswerId)
        {
            IEnumerable<QuestionDto> questions;

            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.GetQuestionsByDependencies";

                questions = connection.Query<QuestionDto>(sql,
                    new
                    {
                        DependentQuestionId = dependentQuestionId,
                        DependentAnswerId = dependentAnswerId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
            return questions;

        }

        public void AddQuestion(QuestionDto questionDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.AddQuestion";

                connection.Execute(sql,
                                    new
                                    {
                                        Question = questionDto.Question,
                                        DependentQuestionId = questionDto.DependentQuestionId,
                                        DependentAnswerId = questionDto.DependentAnswerId
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void UpdateQuestion(QuestionDto questionDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.UpdateQuestion";

                connection.Execute(sql,
                                    new
                                    {
                                        Id = questionDto.Id,
                                        Question = questionDto.Question,
                                        DependentQuestionId = questionDto.DependentQuestionId,
                                        DependentAnswerId = questionDto.DependentAnswerId
                                    },
                                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void DeleteQuestion(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = $"{Schema}.DeleteQuestion";

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
