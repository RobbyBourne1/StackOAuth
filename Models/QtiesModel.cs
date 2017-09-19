using System;
namespace StackOAuth.Models
{
    public class QtiesModel
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public QuestionsModel QuestionModel { get; set; }    
        public string TagsId { get; set; }
        public TagsModel TagsModel { get; set; }
        public QtiesModel()
        {

        }
    }
}