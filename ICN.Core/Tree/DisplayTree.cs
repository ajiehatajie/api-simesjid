using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.Tree
{
    public class DisplayTree : BaseDatabase, IMaster<TreeModel>, ILookUp
    {
        public UserModel objUser;

        public TreeModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayTree()
        {
            MasterData = new TreeModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {


                    return Cn.Query<TreeModel>(DbQuery.TreeSearchBySettingId, new { userId = objUser.user_id }).ToList();

                }
            }

        }

        public object Search(string strSearch)
        {
            throw new NotImplementedException();
        }
    }
}
