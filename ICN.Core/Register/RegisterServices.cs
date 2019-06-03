using Dapper;
using ICN.Base;
using ICN.Core.Account;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.Register
{
    public class RegisterServices : BaseDatabase, IBusiness<RegisterModel>
    {
        
        public async Task<int> Add(RegisterModel data)
        {
            try
            {
                
                using (var x = OpenDB())
                {
                    
                    var guid = Guid.NewGuid().ToString();
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.user_password);
                    x.Open();
                    var con = x.BeginTransaction();
                    try
                    {
                      
                        var res = await x.ExecuteAsync(DbQuery.RegisterNew, new
                        {
                            id = guid,
                            name = data.user_name,
                            email = data.user_email,
                            password = hashedPassword
                        });


                        await x.ExecuteAsync(DbQuery.RegisterNewSetting, new {
                            id = guid, name = data.mosque_name, userid = guid, type = data.mosque_type
                        });


                        //await CreateCategory(guid, guid);
                        #region "CREATE CATEGORY"


                        var CategoryStandard = new List<string>()
                        {
                            "INFAQ & SODAQAH",
                            "ZAKAT",
                            "HONOR",
                            "OPERASIONAL","PERALATAN","PERLENGKAPAN","HUTANG & PIUTANG"
                        };

                        string color;
                        string parentRoot = null;
                        foreach (var item in CategoryStandard)
                        {
                            var guidCategory = Guid.NewGuid().ToString();

                            switch (item)
                            {
                                case "INFAQ & SODAQAH":
                                    #region "INFAQ"


                                    color = "#2ecc71";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid,
                                        parent = parentRoot

                                    });
                                    var SubCategoryStandard = new List<string>()
                                        {
                                                "KEROPAK MASJID",
                                                "INSTANSI","PERORANGAN"
                                        };
                                    foreach (var itemSub in SubCategoryStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,
                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }

                                    #endregion
                                    break;
                                case "ZAKAT":
                                    #region "ZAKAT"
                                    color = "#3498db";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryZakatStandard = new List<string>()
                                {
                                        "ZAKAT MAL","ZAKAT FITRAH","ZAKAT PENGHASILAN"
                                };
                                    foreach (var itemSub in SubCategoryZakatStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,

                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                case "HONOR":
                                    #region "HONOR"
                                    color = "#8e44ad";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryHonorStandard = new List<string>()
                                {
                                        "IMAM MASJID","PENGURUS MASJID","SATPAM"
                                };
                                    foreach (var itemSub in SubCategoryHonorStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,

                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                case "OPERASIONAL":
                                    #region "HONOR"
                                    color = "#16a085";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryOperasionalStandard = new List<string>()
                                {
                                        "LISTRIK","AIR","PERAWATAN","JASA PERAWATAN"
                                };
                                    foreach (var itemSub in SubCategoryOperasionalStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,

                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                case "PERALATAN":
                                    #region "PERALATAN"
                                    color = "#f1c40f";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryPERALATANStandard = new List<string>()
                                {
                                        "PEMBELIAN PERALATAN","PERAWATAN PERALATAN"
                                };
                                    foreach (var itemSub in SubCategoryPERALATANStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,

                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                case "PERLENGKAPAN":
                                    #region "PERLENGKAPAN"
                                    color = "#c0392b";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryPERLENGKAPANStandard = new List<string>()
                                    {
                                            "PEMBELIAN PERLENGKAPAN","PERAWATAN PERLENGKAPAN"
                                    };
                                    foreach (var itemSub in SubCategoryPERLENGKAPANStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,

                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                case "HUTANG & PIUTANG":
                                    #region "HUTANG & PIUTANG"
                                    color = "#2c3e50";
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = guidCategory,
                                        name = item,
                                        parent = parentRoot,
                                        desc = "SUMBER DARI " + item,
                                        userid = guid,
                                        color = color,
                                        settingid = guid

                                    });
                                    var SubCategoryHutangStandard = new List<string>()
                                    {
                                            "UANG","PERALATAN","PERLENGKAPAN"
                                    };
                                    foreach (var itemSub in SubCategoryHutangStandard)
                                    {
                                        await x.ExecuteAsync(DbQuery.CategoryNew, new
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = item,
                                            desc = "SUMBER DARI " + itemSub,
                                            userid = guid,
                                            color = color,
                                            parent = guidCategory,
                                            settingid = guid

                                        });
                                    }
                                    #endregion
                                    break;
                                default:
                                    break;
                            }



                            #region "SUB CATEGORY"

                            #endregion
                        }
                        #endregion


                        // await CreateRoles(guid);

                        await x.ExecuteAsync(DbQuery.RolesInsertRegister, new { userid = guid });

                        con.Commit();

                        x.Close();

                        return res;
                    }
                    catch (Exception ex)
                    {
                        con.Rollback();
                        x.Close();
                        throw ex;
                    }
                    
                   
                   
                   
                 
                  

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #region "GENERATE FOR NEW USER"
        private async Task CreateSetting(string userId,string Mosque,string type)
        {
            try
            {
                using (var x = OpenDB())
                {
                    x.Open();
                    var guid = Guid.NewGuid().ToString();
                   
                    await x.ExecuteAsync(DbQuery.RegisterNewSetting, new { id = guid, name=Mosque, userid = userId,type = type });
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task CreateRoles(string userId)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();

                    await x.ExecuteAsync(DbQuery.RolesInsertRegister, new { userid = userId });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task CreateAccount(string userId, string Mosque, string type)
        {
            try
            {
                using (var x = OpenDB())
                {
                   

                    var AccountStandard = new List<string>() { "CASH", "NON CASH" };

                    foreach (var item in AccountStandard)
                    {
                        var guid = Guid.NewGuid().ToString();
                        await x.ExecuteAsync(DbQuery.AccountNew, new {
                            id = guid,
                            name = item ,
                            balance = 0,
                            desc ="AKUN TRANSANSI "+item,
                            userid = userId });
                    }
                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task CreateCategory(string userId, string Mosque)
        {
            try
            {
                using (var x = OpenDB())
                {
                  
                    #region "CREATE CATEGORY"

                   
                    var CategoryStandard = new List<string>()
                    {
                        "INFAQ & SODAQAH",
                        "ZAKAT",
                        "HONOR",
                        "OPERASIONAL","PERALATAN","PERLENGKAPAN"
                    };

                    string color;
                    string parentRoot = null;
                    foreach (var item in CategoryStandard)
                    {
                        var guid = Guid.NewGuid().ToString();

                        switch (item)
                        {
                            case "INFAQ & SODAQAH":
                                #region "INFAQ"

                               
                                color = "#2ecc71";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,settingid = Mosque,
                                    parent = parentRoot

                                });
                                var SubCategoryStandard = new List<string>()
                                {
                                        "KEROPAK MASJID",
                                        "INSTANSI","PERORANGAN"
                                };
                                foreach (var itemSub in SubCategoryStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,parent = guid,
                                        settingid = Mosque

                                    });
                                }

                                #endregion
                                break;
                            case "ZAKAT":
                                #region "ZAKAT"
                                color = "#3498db";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    parent = parentRoot,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,
                                    settingid = Mosque

                                });
                                var SubCategoryZakatStandard = new List<string>()
                                {
                                        "ZAKAT MAL","ZAKAT FITRAH","ZAKAT PENGHASILAN"
                                };
                                foreach (var itemSub in SubCategoryZakatStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                      
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,
                                        parent = guid,
                                        settingid = Mosque

                                    });
                                }
                                #endregion
                                break;
                            case "HONOR":
                                #region "HONOR"
                                color = "#8e44ad";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    parent = parentRoot,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,
                                    settingid = Mosque

                                });
                                var SubCategoryHonorStandard = new List<string>()
                                {
                                        "IMAM MASJID","PENGURUS MASJID","SATPAM"
                                };
                                foreach (var itemSub in SubCategoryHonorStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                      
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,
                                        parent = guid,
                                        settingid = Mosque

                                    });
                                }
                                #endregion
                                break;
                            case "OPERASIONAL":
                                #region "HONOR"
                                color = "#16a085";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    parent = parentRoot,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,
                                    settingid = Mosque

                                });
                                var SubCategoryOperasionalStandard = new List<string>()
                                {
                                        "LISTRIK","AIR","PERAWATAN","JASA PERAWATAN"
                                };
                                foreach (var itemSub in SubCategoryOperasionalStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                       
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,
                                        parent = guid,
                                        settingid = Mosque

                                    });
                                }
                                #endregion
                                break;
                            case "PERALATAN":
                                #region "PERALATAN"
                                color = "#f1c40f";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    parent = parentRoot,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,
                                    settingid = Mosque

                                });
                                var SubCategoryPERALATANStandard = new List<string>()
                                {
                                        "PEMBELIAN PERALATAN","PERAWATAN PERALATAN"
                                };
                                foreach (var itemSub in SubCategoryPERALATANStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                       
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,
                                        parent = guid,
                                        settingid = Mosque

                                    });
                                }
                                #endregion
                                break;
                            case "PERLENGKAPAN":
                                #region "PERLENGKAPAN"
                                color = "#c0392b";
                                await x.ExecuteAsync(DbQuery.CategoryNew, new
                                {
                                    id = guid,
                                    name = item,
                                    parent = parentRoot,
                                    desc = "SUMBER DARI " + item,
                                    userid = userId,
                                    color = color,
                                    settingid = Mosque

                                });
                                var SubCategoryPERLENGKAPANStandard = new List<string>()
                                {
                                        "PEMBELIAN PERLENGKAPAN","PERAWATAN PERLENGKAPAN"
                                };
                                foreach (var itemSub in SubCategoryPERLENGKAPANStandard)
                                {
                                    await x.ExecuteAsync(DbQuery.CategoryNew, new
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = item,
                                      
                                        desc = "SUMBER DARI " + itemSub,
                                        userid = userId,
                                        color = color,
                                        parent = guid,
                                        settingid = Mosque

                                    });
                                }
                                #endregion
                                break;
                            default:
                                break;
                        }

                       
                      
                        #region "SUB CATEGORY"

                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<RegisterModel> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(RegisterModel data,string id)
        {
            throw new NotImplementedException();
        }



    }
}
