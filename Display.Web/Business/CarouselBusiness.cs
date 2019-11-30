using Display.Web.Models;
using Display.Web.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Display.Web.Business
{
    public class CarouselBusiness
    {
        RepoDAO dao = new RepoDAO();
        public string ActivateDeactivate(CarouselModel model)
        {
            try
            {
                DisplayCommon dc = new DisplayCommon();
                dc.ActivateDeactive("Carousel", "Active", DisplayCommon.BoolToInt(model.Active), "CarouselID", model.CarouselID);
                if (model.Active)
                    return "Presentation is activated.";
                else
                    return "Presentation is deactivated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SaveOrUpdateCarousel(CarouselModel model, HttpPostedFileBase file, out string error)
        {
            try
            {
                if (model.Type == "Image")
                {
                    if (file.ContentLength > 2097152)
                    {
                        error = "danger";
                        return "File Size Should be less than 2 MB";
                    }
                    var filename = string.Empty;
                    if (UploadFile(file, out filename))
                        model.Content = filename;
                    else if (filename == "invalid")
                    {
                        error = "danger";
                        return "Please select jpg/jpeg/png file to upload";
                    }
                        
                }
                string sql = string.Empty;
                if (model.CarouselID == 0)
                {
                    sql += "Insert Into Carousel (Content, Type, Title, SubTitle, CreatedBy) ";
                    sql += string.Format("Select N'{0}','{1}',N'{2}',N'{3}','{4}'", model.Content, model.Type, model.Title, model.SubTitle, model.CreatedBy);
                    dao.ExecuteNonQuery(sql);
                    error = "success";
                    return "Presentation inserted successfully";
                }
                sql += string.Format("Update Carousel Set Content=N'{0}', Title=N'{1}', SubTitle=N'{2}' Where CarouselID={3}", model.Content, model.Title, model.SubTitle, model.CarouselID);
                dao.ExecuteNonQuery(sql);
                error = "success";
                return "Presentation updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UploadFile(HttpPostedFileBase file, out string filename)
        {
            try
            {
                if (file == null)
                {
                    filename = string.Empty;
                    return false;
                }
                var ext = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                if (!"jpeg,jpg,png".Contains(ext.ToLower()))
                {
                    filename = "invalid";
                    return false;
                }
                var path = HttpContext.Current.Server.MapPath("~/Contents/Images/");
                var name = Guid.NewGuid();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                filename = string.Format("{0}.{1}", name, ext);
                file.SaveAs(Path.Combine(path, filename));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}