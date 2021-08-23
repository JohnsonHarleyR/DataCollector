using DataCollector.Data.Database.Dtos;
using DataCollector.Database.Repositories;
using DataCollector.Logic.Models;
using System.Collections.Generic;
using PossibleAnswer = DataCollector.Logic.Enums.PossibleAnswer;

namespace DataCollector.Logic.Orchestrators
{
    public class AnswerOrchestrator
    {

        // TODO refactor code

        private AnswerRepository answerRepository = new AnswerRepository();
        private ItemOrchestrator itemOrchestrator = new ItemOrchestrator();
        private QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();
        public bool AddAnswer(Answer answer)
        {
            if (answer == null)
            {
                return false;
            }

            AnswerDto answerDto = new AnswerDto()
            {
                Id = answer.Id,
                ItemId = answer.ItemId,
                QuestionId = answer.QuestionId,
                AnswerId = answer.AnswerId
            };

            answerRepository.AddItemAnswer(answerDto);

            return true;
        }

        public void DeleteAnswer(int id)
        {
            answerRepository.DeleteItemAnswer(id);
        }

        public List<Answer> GetAllAnswers()
        {
            IEnumerable<AnswerDto> answerDtos = answerRepository.GetAllItemAnswers();
            List<Answer> answers = new List<Answer>();

            if (answerDtos == null)
            {
                return null;
            }


            foreach (var answer in answerDtos)
            {

                answers.Add(new Answer()
                {
                    Id = answer.Id,
                    ItemId = answer.ItemId,
                    Item = itemOrchestrator.GetItemById(answer.ItemId),
                    QuestionId = answer.QuestionId,
                    Question = questionOrchestrator.GetQuestionById(answer.QuestionId),
                    AnswerId = answer.AnswerId,
                    AnswerEnum = (PossibleAnswer)answer.AnswerId
                });
            }

            return answers;

        }

        public List<Answer> GetAnswersByAnswer(int? questionId, int? answerId)
        {
            IEnumerable<AnswerDto> answerDtos = answerRepository.GetItemAnswersByAnswers(questionId, answerId);
            List<Answer> answers = new List<Answer>();

            if (answerDtos == null)
            {
                return null;
            }


            foreach (var answer in answerDtos)
            {

                answers.Add(new Answer()
                {
                    Id = answer.Id,
                    ItemId = answer.ItemId,
                    Item = itemOrchestrator.GetItemById(answer.ItemId),
                    QuestionId = answer.QuestionId,
                    Question = questionOrchestrator.GetQuestionById(answer.QuestionId),
                    AnswerId = answer.AnswerId,
                    AnswerEnum = (PossibleAnswer)answer.AnswerId
                });
            }

            return answers;

        }

        public List<Answer> GetAnswersByItem(int? itemId)
        {
            IEnumerable<AnswerDto> answerDtos = answerRepository.GetItemAnswersByItem(itemId);
            List<Answer> answers = new List<Answer>();

            if (answerDtos == null)
            {
                return null;
            }


            foreach (var answer in answerDtos)
            {

                answers.Add(new Answer()
                {
                    Id = answer.Id,
                    ItemId = answer.ItemId,
                    Item = itemOrchestrator.GetItemById(answer.ItemId),
                    QuestionId = answer.QuestionId,
                    Question = questionOrchestrator.GetQuestionById(answer.QuestionId),
                    AnswerId = answer.AnswerId,
                    AnswerEnum = (PossibleAnswer)answer.AnswerId
                });
            }

            return answers;

        }

        public Answer GetAnswerById(int id)
        {
            AnswerDto answerDto = answerRepository.GetItemAnswerById(id);

            if (answerDto == null)
            {
                return null;
            }

            return new Answer()
            {
                Id = answerDto.Id,
                ItemId = answerDto.ItemId,
                Item = itemOrchestrator.GetItemById(answerDto.ItemId),
                QuestionId = answerDto.QuestionId,
                Question = questionOrchestrator.GetQuestionById(answerDto.QuestionId),
                AnswerId = answerDto.AnswerId,
                AnswerEnum = (PossibleAnswer)answerDto.AnswerId
            };
        }

        public bool UpdateAnswer(Answer answer)
        {
            if (answer == null)
            {
                return false;
            }

            AnswerDto answerDto = new AnswerDto()
            {
                Id = answer.Id,
                ItemId = answer.ItemId,
                QuestionId = answer.QuestionId,
                AnswerId = answer.AnswerId
            };

            answerRepository.UpdateItem(answerDto);

            return true;
        }

    }
}
