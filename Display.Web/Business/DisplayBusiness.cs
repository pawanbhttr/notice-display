using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Display.Web.Repository;
using Display.Web.Models;
using System.Data;
using System.Text;

namespace Display.Web.Business
{
    public class DisplayBusiness
    {
        DisplayCommon dc = new DisplayCommon();
        public string GetBanner()
        {
            try
            {
                return string.Join(" ", dc.GetBanner().Where(i => i.Active == true).Select(row => row.Content));
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
                return dc.GetCarousel().Where(row => row.Active == true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNotice()
        {
            try
            {
                return string.Join(" ", dc.GetNotice().Where(row => row.Active == true).Select(row => row.Content));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}