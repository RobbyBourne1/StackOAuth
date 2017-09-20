using System;
namespace StackOAuth.Models
{
    public class CommentsModel
    { 
        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public string AnswersModelId { get; set; }
        public AnswersModel AnswersModel { get; set; }  
        public string QuestionModelId { get; set; }
        public QuestionsModel QuestionsModel { get; set; }
        public CommentsModel()
        {
            
        }
    }
}