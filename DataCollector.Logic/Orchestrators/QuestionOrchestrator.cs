using DataCollector.Data.Database.Dtos;
using DataCollector.Data.Database.Repositories;
using DataCollector.Logic.Enums;
using DataCollector.Logic.Models;
using System.Collections.Generic;

namespace DataCollector.Logic.Orchestrators
{
    public class QuestionOrchestrator
    {
        private QuestionRepository repo = new QuestionRepository();

        public bool AddQueston(Question question)
        {
            if (question == null)
            {
                return false;
            }


            QuestionDto questionDto = new QuestionDto()
            {
                Question = question.QuestionString,
                DependentQuestionId = question.DependentQuestionId,
                DependentAnswerId = question.DependentAnswerId
            };

            repo.AddQuestion(questionDto);

            return true;
        }


        public void DeleteQuestion(int id)
        {
            repo.DeleteQuestion(id);
        }

        public List<Question> GetAllQuestions()
        {
            IEnumerable<QuestionDto> questionDtos = repo.GetAllQuestions();
            List<Question> questions = new List<Question>();

            if (questionDtos == null)
            {
                return null;
            }

            foreach (var question in questionDtos)
            {
                Question dependentQuestion = GetQuestionById(question.Id);

                // first grab the question and answer item to store

                questions.Add(new Question()
                {
                    Id = question.Id,
                    QuestionString = question.Question,
                    DependentQuestionId = question.DependentQuestionId,
                    DependentQuestion = dependentQuestion,
                    DependentAnswerId = question.DependentAnswerId,
                    DependentAnswer = (PossibleAnswer?)question.DependentAnswerId
                });
            }

            return questions;

        }

        public List<Question> GetQuestionsByDependencies(int? dependentQuestionId, int? dependentAnswerId)
        {
            IEnumerable<QuestionDto> questionDtos =
                repo.GetQuestionsByDependencies(dependentQuestionId, dependentAnswerId);
            List<Question> questions = new List<Question>();

            if (questionDtos == null)
            {
                return null;
            }

            foreach (var question in questionDtos)
            {
                Question dependentQuestion = GetQuestionById(question.DependentQuestionId);

                // first grab the question and answer item to store

                questions.Add(new Question()
                {
                    Id = question.Id,
                    QuestionString = question.Question,
                    DependentQuestionId = question.DependentQuestionId,
                    DependentQuestion = dependentQuestion,
                    DependentAnswerId = question.DependentAnswerId,
                    DependentAnswer = (PossibleAnswer?)question.DependentAnswerId
                });
            }

            return questions;

        }

        public Question GetQuestionById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            QuestionDto questionDto = repo.GetQuestionById((int)id);

            if (questionDto == null)
            {
                return null;
            }

            Question dependentQuestion = GetQuestionById(questionDto.DependentQuestionId);

            return new Question()
            {
                Id = questionDto.Id,
                QuestionString = questionDto.Question,
                DependentQuestionId = questionDto.DependentQuestionId,
                DependentQuestion = dependentQuestion,
                DependentAnswerId = questionDto.DependentAnswerId,
                DependentAnswer = (PossibleAnswer?)questionDto.DependentAnswerId
            };
        }

        public bool UpdateQuestion(Question question)
        {
            if (question == null)
            {
                return false;
            }

            QuestionDto questionDto = new QuestionDto()
            {
                Id = question.Id,
                Question = question.QuestionString,
                DependentQuestionId = question.DependentQuestionId,
                DependentAnswerId = question.DependentAnswerId
            };

            repo.UpdateQuestion(questionDto);

            return true;
        }

    }
}
