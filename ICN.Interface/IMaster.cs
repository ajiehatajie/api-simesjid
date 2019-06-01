using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Interface
{
    public interface IMaster<T>
    {
        T MasterData
        {
            get;
            set;

        }
        object Display();

        
    }
}
