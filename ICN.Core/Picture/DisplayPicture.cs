using Dapper;
using ICN.Base;
using ICN.Data;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.Picture
{
    public class DisplayPicture : BaseDatabase, IMaster<PictureModel>, ILookUp
    {
        public UserModel objUser;

        public PictureModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayPicture()
        {
            MasterData = new PictureModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    Query = "select * from mst_pictures where picture_created_by = ?userId order by picture_created desc";
                    var sql = Cn.Query<PictureModel>(Query, new { userId = objUser.user_id }).ToList();

                    return sql;
                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Search(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    Query = "select * from mst_pictures where picture_created_by = ? userId and picture_filename LIKE CONCAT('%',?cari,'%') " +
                            " order by picture_created desc";
                    return Cn.Query<PictureModel>(Query, new { account_userid = objUser.user_id, cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
