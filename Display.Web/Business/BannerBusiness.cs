using Display.Web.Models;
using Display.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Display.Web.Business
{
    public class BannerBusiness
    {
        public string SaveOrUpdateBanner(BannerModel model)
        {
            try
            {
                RepoDAO dao = new RepoDAO();
                string sql = string.Empty;
                if (model.BannerID == 0)
                {
                    sql += string.Format("Insert Into Banner (Content, CreatedBy, CreatedDate) Values (N'{0}','{1}',GetDate()); Select Scope_Identity() As BannerID;", model.Content, model.CreatedBy);
                    dao.ExecuteNonQuery(sql);
                    return "Banner is successfully inserted";
                }
                else
                {
                    sql += string.Format("Update Banner Set Content=N'{0}' Where BannerID={1}", model.Content, model.BannerID);
                    dao.ExecuteNonQuery(sql);
                    return "Banner is successfully updated";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ActivateDeactivate(BannerModel model)
        {
            try
            {
                DisplayCommon dc = new DisplayCommon();
                dc.ActivateDeactive("Banner", "Active", DisplayCommon.BoolToInt(model.Active), "BannerID", model.BannerID);
                if (model.Active)
                    return "Banner is activated.";
                else
                    return "Banner is deactivated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}