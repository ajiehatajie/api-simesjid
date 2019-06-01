using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Interface
{
    public interface IEntity
    {
        string IDFormat { get; }
        string IDInitial { get; }
        bool Validate(object obj = null);
    }
}
