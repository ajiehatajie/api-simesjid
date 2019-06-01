using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Interface
{
    public interface ILookUp
    {
        object Search(string strSearch);
        string Query { get; set; }
    }
}
