using System;
using NET01._1.Entities;

namespace NET01._1
{
    public static class ExtensionEntity
    {
        public static Guid GenerateGuid(this Entity entity) => entity.Guid = Guid.NewGuid();

    }
}