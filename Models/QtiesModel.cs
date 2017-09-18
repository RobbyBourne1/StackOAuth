using System;
namespace StackOAuth.Models
{
    public class QtiesModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public QuestionsModel QuestionModel { get; set; }    
        public int TagsId { get; set; }
        public TagsModel TagsModel { get; set; }
        public QtiesModel()
        {

        }
    }
}