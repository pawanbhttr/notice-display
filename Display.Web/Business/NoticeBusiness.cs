using Display.Web.Models;
using Display.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Display.Web.Business
{
    public class NoticeBusiness
    {
        public string SaveOrUpdateNotice(NoticeModel model)
        {
            try
            {
                RepoDAO dao = new RepoDAO();
                string sql = string.Empty;
                if (model.NoticeID == 0)
                {
                    sql += string.Format("Insert Into Notice (Content, CreatedBy, CreatedDate) Values (N'{0}','{1}',GetDate());", model.Content, model.CreatedBy);
                    dao.ExecuteNonQuery(sql);
                    return "Notice is successfully inserted";
                }
                else
                {
                    sql += string.Format("Update Notice Set Content=N'{0}' Where NoticeID={1}", model.Content, model.NoticeID);
                    dao.ExecuteNonQuery(sql);
                    return "Notice is successfully updated";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ActivateDeactivate(NoticeModel model)
        {
            try
            {
                DisplayCommon dc = new DisplayCommon();
                dc.ActivateDeactive("Notice", "Active", DisplayCommon.BoolToInt(model.Active), "NoticeID", model.NoticeID);
                if (model.Active)
                    return "Notice is activated.";
                else
                    return "Notice is deactivated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}