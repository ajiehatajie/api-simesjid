﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICN.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DbQuery {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DbQuery() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ICN.Core.Properties.DbQuery", typeof(DbQuery).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from mst_accounts where account_id = ?id and account_userid =?userid.
        /// </summary>
        internal static string AccountDelete {
            get {
                return ResourceManager.GetString("AccountDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT a.*,b.user_name,b.user_email FROM mst_accounts a
        ///INNER JOIN mst_users b ON a.account_userid=b.user_id where account_userid = ?userId order by account_name asc.
        /// </summary>
        internal static string AccountGetAll {
            get {
                return ResourceManager.GetString("AccountGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_accounts (account_id,account_name,account_balance,account_desc,account_userid) values (?id,?name,?balance,?desc,?user).
        /// </summary>
        internal static string AccountNew {
            get {
                return ResourceManager.GetString("AccountNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_accounts where account_userid = ? userId and account_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;)  order by account_name asc.
        /// </summary>
        internal static string AccountSearchByName {
            get {
                return ResourceManager.GetString("AccountSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update mst_accounts set account_name=?name,account_balance=?balance,account_desc=?desc where account_id = ?id  and account_userid =?userid.
        /// </summary>
        internal static string AccountUpdate {
            get {
                return ResourceManager.GetString("AccountUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from mst_categories where category_id = ?id and category_userid =?userid.
        /// </summary>
        internal static string CategoryDeleteById {
            get {
                return ResourceManager.GetString("CategoryDeleteById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_categories where category_userid = ?userId and category_id=?id order by category_name asc.
        /// </summary>
        internal static string CategoryDetailByCategoryId {
            get {
                return ResourceManager.GetString("CategoryDetailByCategoryId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_categories where category_userid = ?userId order by category_name asc.
        /// </summary>
        internal static string CategoryGetAll {
            get {
                return ResourceManager.GetString("CategoryGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_categories (category_id,category_name,category_desc,category_type,category_color,category_userid) values (?id,?name,?desc,?type,?color,?user).
        /// </summary>
        internal static string CategoryNew {
            get {
                return ResourceManager.GetString("CategoryNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_categories where category_userid = ? userId and category_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;) order by category_name asc.
        /// </summary>
        internal static string CategorySearchByName {
            get {
                return ResourceManager.GetString("CategorySearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update from mst_categories set category_name=?name,category_desc=?desc,category_type=?type where account_id = ?id  and category_userid =?userid.
        /// </summary>
        internal static string CategoryUpdate {
            get {
                return ResourceManager.GetString("CategoryUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from trx_expenses where expense_id = ?id and expense_created_by =?userid.
        /// </summary>
        internal static string ExpenseDelete {
            get {
                return ResourceManager.GetString("ExpenseDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from trx_expenses where expense_created_by = ?userId order by expense_created desc.
        /// </summary>
        internal static string ExpenseGetAll {
            get {
                return ResourceManager.GetString("ExpenseGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into trx_expenses (expense_id,expense_name,expense_amount,expense_ref,expense_date, 
        ///                        expense_accountid,expense_categoryid,expense_subcategoryid,expense_note,expense_pictureid, 
        ///                        expense_created_by,expense_settingid) values (?id,?name,?amount,?referency,?date,?account,?category,?subcategory 
        ///                        ,?note,?picture,?userid,?settingid).
        /// </summary>
        internal static string ExpenseNew {
            get {
                return ResourceManager.GetString("ExpenseNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from trx_expenses where expense_created_by = ? userId and expense_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;) order by expense_created desc.
        /// </summary>
        internal static string ExpenseSearchByName {
            get {
                return ResourceManager.GetString("ExpenseSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update from trx_expenses set expense_name=?name,expense_amount=?amount,expense_ref=?referency 
        ///                         expense_date=?date,expense_accountid=?account,expense_categoryid=?category, 
        ///                         expense_subcategoryid=?subcategory,expense_note=?note,expense_pictureid=?picture,expense_updated=?updated,expense_updated_by=?userid where expense_id = ?id  and expense_created_by =?userid;.
        /// </summary>
        internal static string ExpenseUpdate {
            get {
                return ResourceManager.GetString("ExpenseUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from trx_incomes where income_id = ?id and income_created_by =?userid.
        /// </summary>
        internal static string IncomeDelete {
            get {
                return ResourceManager.GetString("IncomeDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from trx_incomes where income_created_by = ?userId order by income_created desc.
        /// </summary>
        internal static string IncomeGetAll {
            get {
                return ResourceManager.GetString("IncomeGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into trx_incomes (income_id,income_name,income_amount,income_ref,income_date, 
        ///                        income_accountid,income_categoryid,income_subcategoryid,income_note,income_pictureid, 
        ///                        income_created_by,income_settingid) values (?id,?name,?amount,?referency,?date,?account,?category,?subcategory 
        ///                        ,?note,?picture,?userid,?settingid).
        /// </summary>
        internal static string IncomeNew {
            get {
                return ResourceManager.GetString("IncomeNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from trx_incomes where income_created_by = ? userId and income_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;) order by income_created desc.
        /// </summary>
        internal static string IncomeSearchByName {
            get {
                return ResourceManager.GetString("IncomeSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update trx_incomes set income_name=?name,income_amount=?amount,income_ref=?referency 
        ///                         income_date=?date,income_accountid=?account,income_categoryid=?category, 
        ///                         income_subcategoryid=?subcategory,income_note=?note,income_pictureid=?picture,income_updated=?updated,income_updated_by=?userid where income_id = ?id  and income_created_by =?userid;.
        /// </summary>
        internal static string IncomeUpdate {
            get {
                return ResourceManager.GetString("IncomeUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM mst_category_mosque ORDER BY category_name ASC.
        /// </summary>
        internal static string MosqueCategoryAll {
            get {
                return ResourceManager.GetString("MosqueCategoryAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from mst_pictures where picture_id = ?id and picture_created_by =?userid.
        /// </summary>
        internal static string PictureDelete {
            get {
                return ResourceManager.GetString("PictureDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_pictures (picture_id,picture_filename,picture_path,picture_created_by) values (?id,?name,?path,userid).
        /// </summary>
        internal static string PictureNew {
            get {
                return ResourceManager.GetString("PictureNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update mst_pictures set picture_filename=?name,picture_path=?path where picture_id = ?id  and picture_created_by =?userid.
        /// </summary>
        internal static string PictureUpdate {
            get {
                return ResourceManager.GetString("PictureUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM mst_postal WHERE province=?province AND kabupaten=?kabupaten AND kecamatan=?kecamatan.
        /// </summary>
        internal static string PostalCodeSearch {
            get {
                return ResourceManager.GetString("PostalCodeSearch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_users (user_id,user_name,user_email,user_password) values (?id,?name,?email,?password).
        /// </summary>
        internal static string RegisterNew {
            get {
                return ResourceManager.GetString("RegisterNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO 
        ///      mst_settings (setting_id,setting_mosque_name,setting_mosque_id,
        ///      setting_created_by) VALUES (?id,?NAME,?TYPE,?userid).
        /// </summary>
        internal static string RegisterNewSetting {
            get {
                return ResourceManager.GetString("RegisterNewSetting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO mst_access (access_roleid,access_userid)
        ///SELECT role_id,?userid FROM mst_roles.
        /// </summary>
        internal static string RolesInsertRegister {
            get {
                return ResourceManager.GetString("RolesInsertRegister", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_role_users where role_userid=?role_userid order by role_name asc.
        /// </summary>
        internal static string RoleUserSearchById {
            get {
                return ResourceManager.GetString("RoleUserSearchById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from mst_settings where setting_id = ?id and setting_created_by =?userid.
        /// </summary>
        internal static string SettingDelete {
            get {
                return ResourceManager.GetString("SettingDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_settings where setting_created_by = ?userId order by setting_mosque_name desc.
        /// </summary>
        internal static string SettingGetAll {
            get {
                return ResourceManager.GetString("SettingGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO mst_settings (
        ///setting_id,setting_mosque_name,
        ///setting_mosque_id,setting_countries,setting_province,setting_kabupaten,
        ///setting_kecamatan,setting_kelurahan,setting_postalcode,setting_address,	
        ///setting_web,setting_phone,setting_mosque_email,setting_currency,setting_languange, 
        ///setting_logo,setting_created_by) 
        ///VALUES (?id,?NAME,?mosid,?country,?propinsi,?kabupaten,?kecamatan,?kelurahan,?postal,
        ///?adress?,?web,?phone,?email,?currency,languange,logo,userid).
        /// </summary>
        internal static string SettingNew {
            get {
                return ResourceManager.GetString("SettingNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_settings where setting_created_by = ? userId and setting_mosque_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;) order by setting_created desc.
        /// </summary>
        internal static string SettingSearchByMosque {
            get {
                return ResourceManager.GetString("SettingSearchByMosque", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE mst_settings SET 
        ///setting_mosque_name=?NAME,setting_countries=?country,setting_province=?propinsi,setting_kabupaten=?kabupaten,
        ///,setting_kecamatan=?kecamatan,setting_kelurahan=?kelurahan, setting_postalcode=?postal,setting_address=?address, 
        ///setting_web=?web,setting_phone=?phone,setting_mosque_email=?email, 
        ///setting_currency=?currency,setting_languange=?languange,setting_logo=?logo WHERE setting_id = ?id  AND setting_created_by =?userid;.
        /// </summary>
        internal static string SettingUpdate {
            get {
                return ResourceManager.GetString("SettingUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_categories (category_id,category_name,category_desc,category_type,category_color,category_parentid,category_userid) values (?id,?name,?desc,?type,?color,?parent,?user).
        /// </summary>
        internal static string SubCategoryAdd {
            get {
                return ResourceManager.GetString("SubCategoryAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from vi_subcategory where category_userid = ?userId and category_id=?id order by category_name asc.
        /// </summary>
        internal static string SubCategoryDetail {
            get {
                return ResourceManager.GetString("SubCategoryDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from vi_subcategory where category_userid = ?userId and parent_id=?parent order by category_name asc.
        /// </summary>
        internal static string SubCategoryGetAll {
            get {
                return ResourceManager.GetString("SubCategoryGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM mst_tree WHERE tree_id=?id and tree_settingid=?settingid.
        /// </summary>
        internal static string TreeDeleteById {
            get {
                return ResourceManager.GetString("TreeDeleteById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from vi_tree where tree_settingid=?settingid order by tree_parentid asc.
        /// </summary>
        internal static string TreeGetBySettingId {
            get {
                return ResourceManager.GetString("TreeGetBySettingId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO mst_tree (tree_id,tree_userid,tree_jobposition,tree_parentid,tree_settingid,setting_created_by) 
        ///VALUES (?id,?userid,?job,?parent,?setting,?created_by).
        /// </summary>
        internal static string TreeNew {
            get {
                return ResourceManager.GetString("TreeNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_tree WHERE tree_settingid=?settingid ORDER BY tree_parentid ASC.
        /// </summary>
        internal static string TreeSearchBySettingId {
            get {
                return ResourceManager.GetString("TreeSearchBySettingId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_users where user_id = ?userId order by user_name asc.
        /// </summary>
        internal static string UserByUserId {
            get {
                return ResourceManager.GetString("UserByUserId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from mst_users where user_id = ?id.
        /// </summary>
        internal static string UserDelete {
            get {
                return ResourceManager.GetString("UserDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_users.
        /// </summary>
        internal static string UserGetAll {
            get {
                return ResourceManager.GetString("UserGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into mst_users (user_id,user_name,user_email,user_password,user_lastname,user_parentid) values (?id,?name,?email,?password,?lastname,?parent).
        /// </summary>
        internal static string UserNew {
            get {
                return ResourceManager.GetString("UserNew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_users where user_email = ?email.
        /// </summary>
        internal static string UserSearchByEmail {
            get {
                return ResourceManager.GetString("UserSearchByEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from mst_users where user_id = ? userId and user_name LIKE CONCAT(&apos;%&apos;,?cari,&apos;%&apos;) order by user_name asc.
        /// </summary>
        internal static string UserSearchByName {
            get {
                return ResourceManager.GetString("UserSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update mst_users set user_name=?name,user_email=?email,user_password=?password,user_lastname=?lastname where user_id = ?userid.
        /// </summary>
        internal static string UserUpdate {
            get {
                return ResourceManager.GetString("UserUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kabupaten.
        /// </summary>
        internal static string ViKabupatenGetAll {
            get {
                return ResourceManager.GetString("ViKabupatenGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kabupaten WHERE kabupaten LIKE CONCAT(&apos;%&apos;,?kabupaten,&apos;%&apos;);.
        /// </summary>
        internal static string ViKabupatenSearchByName {
            get {
                return ResourceManager.GetString("ViKabupatenSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kecamatan.
        /// </summary>
        internal static string ViKecamatanGetAll {
            get {
                return ResourceManager.GetString("ViKecamatanGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kecamatan WHERE kecamatan LIKE CONCAT(&apos;%&apos;,?kecamatan,&apos;%&apos;);.
        /// </summary>
        internal static string ViKecamatanSearchByName {
            get {
                return ResourceManager.GetString("ViKecamatanSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kelurahan.
        /// </summary>
        internal static string ViKeluarahanGetAll {
            get {
                return ResourceManager.GetString("ViKeluarahanGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_kelurahan WHERE kelurahan LIKE CONCAT(&apos;%&apos;,?kelurahan,&apos;%&apos;);.
        /// </summary>
        internal static string ViKelurahanSearchByName {
            get {
                return ResourceManager.GetString("ViKelurahanSearchByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_province .
        /// </summary>
        internal static string ViProvinceGetAll {
            get {
                return ResourceManager.GetString("ViProvinceGetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM vi_province WHERE province LIKE CONCAT(&apos;%&apos;,?province,&apos;%&apos;);.
        /// </summary>
        internal static string VIProvinceSearchByName {
            get {
                return ResourceManager.GetString("VIProvinceSearchByName", resourceCulture);
            }
        }
    }
}
