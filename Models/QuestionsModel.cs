using System;
namespace StackOAuth.Models
{
    public class QuestionsModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime PostDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public QuestionsModel()
        {

        }
    }
}