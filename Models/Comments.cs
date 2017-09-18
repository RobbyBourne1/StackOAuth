using System;
namespace StackOAuth.Models
{
    public class CommentsModel
    { 
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        public AnswersModel AnswersModel { get; set; }  
        public CommentsModel()
        {
            
        }
    }
}