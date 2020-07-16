using Simple.Domain.SeedWork;
using System;

namespace Simple.Domain.Users
{ 
    public class User: Entity, IAggregateRoot
    {
        public UserID Id { get; private set; }

        public string Name { get; set; }

        private User()
        {
            Id = new UserID(Guid.NewGuid());
        }

        private User(string name)
        {
            Id = new UserID(Guid.NewGuid());
            Name = name;

            // register here domain event
        }

        public static User Create(string name)
        {

            // check here some logic , unique email...

            return new User(name);
        }
    }
}
