using System;
namespace StackOAuth.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsModerator { get; set; } = false;

        public UserModel()
        {
            
        }
    }
}