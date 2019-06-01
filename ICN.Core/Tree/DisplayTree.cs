using ICN.Base;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Core.Tree
{
    public class DisplayTree : BaseDatabase, IMaster<TreeModel>, ILookUp
    {
        public TreeModel MasterData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Query { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Display()
        {
            throw new NotImplementedException();
        }

        public object Search(string strSearch)
        {
            throw new NotImplementedException();
        }
    }
}
