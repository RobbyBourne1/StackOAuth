using System;
namespace StackOAuth.Models
{
    public class AnswersModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }

        public AnswersModel()
        {
            
        }
    }
}