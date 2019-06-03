using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Data;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ICN.Core.Tipologi
{
    public class DisplayTipologi : BaseDatabase, IMaster<MosqueCategoryModel>, ILookUp
    {
        public MosqueCategoryModel MasterData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Query { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<MosqueCategoryModel>(DbQuery.MosqueCategoryAll).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }

        public object Search(string strSearch)
        {
            throw new NotImplementedException();
        }
    }
}
