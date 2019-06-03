using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Data;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.Postal
{
    public class DisplayPostal : BaseDatabase, IMaster<PostalModel>, ILookUp
    {
        public UserModel objUser;

        public PostalModel objPostal;

        public PostalModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayPostal()
        {
            MasterData = new PostalModel();
        }

        public object Display()
        {
            throw new NotImplementedException();
        }

        public object DisplayProvince()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViProvinceGetAll).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DisplayKabupaten()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKabupatenGetAll).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DisplayKecamatan()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKecamatanGetAll).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public object DisplayKelurahan()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKeluarahanGetAll).ToList();


                }
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

                    return Cn.Query<PostalModel>(DbQuery.PostalCodeFilter, new {  cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object SearchPostalCode(string province,string kabupaten,string kecamatan)
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.PostalCodeFilter, new { province = province,
                        kabupaten = kabupaten,
                        kecamatan = kecamatan
                    }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public object SearchProvince(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.VIProvinceSearchByName, new { province =  strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object SearchKabupaten(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKabupatenSearchByName, new { kabupaten = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object SearchKecamatan(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKecamatanSearchByName, new { kecamatan = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object SearchKelurahan(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<PostalModel>(DbQuery.ViKelurahanSearchByName, new { kelurahan = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
