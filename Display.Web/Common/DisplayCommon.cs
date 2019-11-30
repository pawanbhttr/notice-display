using Display.Web.Models;
using Display.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace Display.Web
{
    public class DisplayCommon
    {
        RepoDAO dao = new RepoDAO();
        public List<BannerModel> GetBanner()
        {
            try
            {
                var list = new List<BannerModel>();
                var sql = "Select * From Banner Order By CreatedDate Desc;";
                var dt = dao.ExecuteDataTable(sql);

                list = dt.AsEnumerable().Select((row, index) => new BannerModel
                {
                    BannerID = row.Field<int>("BannerID"),
                    Content = row.Field<string>("Content"),
                    CreatedDate = (row.Field<DateTime>("CreatedDate")).ToShortDateString(),
                    Active = row.Field<bool>("Active")
                }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CarouselModel> GetCarousel()
        {
            try
            {
                var list = new List<CarouselModel>();
                var sql = "Select * From Carousel Order By CreatedDate Desc;";
                var dt = dao.ExecuteDataTable(sql);

                list = dt.AsEnumerable().Select((row, index) => new CarouselModel
                {
                    CarouselID = row.Field<int>("CarouselID"),
                    Content = row.Field<string>("Content"),
                    Type = row.Field<string>("Type"),
                    Title = row.Field<string>("Title"),
                    SubTitle = row.Field<string>("SubTitle"),
                    CreatedDate = (row.Field<DateTime>("CreatedDate")).ToShortDateString(),
                    Active = row.Field<bool>("Active")
                }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoticeModel> GetNotice()
        {
            try
            {
                var list = new List<NoticeModel>();
                var sql = "Select * From Notice Order By CreatedDate Desc;";
                var dt = dao.ExecuteDataTable(sql);

                list = dt.AsEnumerable().Select((row, index) => new NoticeModel
                {
                    NoticeID = row.Field<int>("NoticeID"),
                    Content = row.Field<string>("Content"),
                    CreatedDate = (row.Field<DateTime>("CreatedDate")).ToShortDateString(),
                    Active = row.Field<bool>("Active")
                }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> GetUserInfo()
        {
            try
            {
                var list = new List<UserModel>();
                var sql = "Select * From UserInfo Order By CreatedDate Desc;";
                var dt = dao.ExecuteDataTable(sql);

                list = dt.AsEnumerable().Select((row, index) => new UserModel
                {
                    UserID = row.Field<int>("UserID"),
                    Username = row.Field<string>("Username"),
                    FullName = row.Field<string>("FullName"),
                    UserRole = row.Field<string>("UserRole"),
                    CreatedDate = (row.Field<DateTime>("CreatedDate")).ToShortDateString(),
                    Active = row.Field<bool>("Active")
                }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActivateDeactive(string tableName, string columnName, int columnValue, string parameterColumn, int parameterValue)
        {
            try
            {
                string sql = string.Format("Update {0} Set {1} = {2} Where {3} = {4}", tableName, columnName, columnValue, parameterColumn, parameterValue);
                dao.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ToInt32(object obj)
        {
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }

        public static int BoolToInt(bool obj)
        {
            if (obj)
                return 1;
            else
                return 0;
        }
    }
}