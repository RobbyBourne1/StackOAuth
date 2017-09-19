using System;
namespace StackOAuth.Models
{
    public class AnswersModel
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public ApplicationUser AppUser { get; set; }

        public AnswersModel()
        {
            
        }
    }
}