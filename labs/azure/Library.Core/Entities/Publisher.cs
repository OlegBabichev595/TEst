using System;

namespace Library.Core.Entities
{
    public class Publisher : Entity<Guid>
    {
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}