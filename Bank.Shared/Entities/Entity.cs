using System;
using Flunt.Notifications;

namespace Bank.Shared.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(1, 8);
        }
        public string Id { get; private set; }
        
    }
}