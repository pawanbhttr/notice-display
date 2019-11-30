using Display.Web.Models;
using Display.Web.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Display.Web.Business
{
    public class UserBusiness
    {
        RepoDAO dao = new RepoDAO();
        public DataTable UserLogin(UserModel model)
        {
            try
            {
                string sql = string.Format("Select * From UserInfo Where Username='{0}' And Password='{1}' And Active=1", model.Username, model.Password);
                var dt = dao.ExecuteDataTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SaveOrUpdateUser(UserModel model, out string error)
        {
            try
            {
                string sql = string.Empty;
                if (model.UserID == 0)
                {
                    sql += "Insert Into UserInfo (Username, Password, Fullname, UserRole, CreatedBy) ";
                    sql += string.Format("Select '{0}','{1}','{2}','{3}','{4}'", model.Username, model.Password, model.FullName, model.UserRole, model.CreatedBy);
                    dao.ExecuteNonQuery(sql);
                    error = "success";
                    return "New User successfully created.";
                }
                sql += string.Format("Update UserInfo Set Username='{0}', Fullname='{1}' Where UserID={2}", model.Username, model.FullName, model.UserID);
                dao.ExecuteNonQuery(sql);
                error = "success";
                return "User successfully updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}