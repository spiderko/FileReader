using System;

namespace FileReader.Core.Models
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
    }
}
