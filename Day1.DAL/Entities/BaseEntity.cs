using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public State State { get; set; } = 0;
    }
    public enum State
    {
        Active = 0,
        Remote = 255
    }
}
