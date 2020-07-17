using Simple.Domain.SeedWork;
using System;

namespace Simple.Domain.Users
{ 
    public class User: Entity, IAggregateRoot
    {
        public UserID Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        private User()
        {
            Id = new UserID(Guid.NewGuid());
        }

        private User(string first_name, string last_name, string email)
        {
            Id = new UserID(Guid.NewGuid());
            FirstName = first_name;
            LastName = last_name;
            Email = email;

            // register here domain event
        }

        public static User Create(string first_name, string last_name, string email)
        {

            // check here some logic , unique email...

            return new User(first_name, last_name, email);
        }
    }
}
