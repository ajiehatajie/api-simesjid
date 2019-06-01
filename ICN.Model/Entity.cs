using ICN.Interface;
using System;

namespace ICN.Model
{
    public abstract class Entity : IEntity
    {
        public string IDFormat { get; private set; } = "{INIT}.{DATE:yy}.[User_Branch_Id].{RUN_NUM:00000000}";

        public string IDInitial { get; private set; } = string.Empty;

        public string Initial { set { IDInitial = value; } }
        public string Format { set { IDFormat = value; } }
        public abstract bool Validate(object obj = null);

        
    }
}
