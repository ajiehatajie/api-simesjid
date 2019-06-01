using System;
using System.Data;

namespace ICN.Interface
{
    public interface IDataContainer
    {
        object CollectData(IDataReader reader);

        object SelectData(IDataReader reader);
    }
}
