using DataTransferObjects;
using System;
using System.Text;
using System.Web.Mvc;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Class for holding HTML Helper methods.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public static class HtmlHelpers
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: 
        /// 
        /// Creates page links using bootstrap 4 classes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="html"></param>
        /// <param name="info"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo info, Func<int, string> pageUrl)
        {
            TagBuilder tbNav = new TagBuilder("nav");
            tbNav.MergeAttribute("aria-label", "Product navigation");
            TagBuilder tbUl = new TagBuilder("ul");
            tbUl.AddCssClass("pagination");
            tbUl.AddCssClass("pagination-lg");
            tbUl.AddCssClass("justify-content-center");
            for (int i = 1; i <= info.TotalPages; i++)
            {

                TagBuilder tbLi = new TagBuilder("li");
                TagBuilder tbA = new TagBuilder("a");
                tbLi.AddCssClass("page-item");
                if (i == info.CurrentPage)
                {
                    TagBuilder tbSpanInner = new TagBuilder("span");
                    TagBuilder tbSpanOuter = new TagBuilder("span");
                    tbLi.AddCssClass("active");
                    tbLi.MergeAttribute("aria-current", "page");
                    tbSpanInner.AddCssClass("sr-only");
                    tbSpanInner.SetInnerText("(current)");
                    tbSpanOuter.AddCssClass("page-link");
                    tbSpanOuter.InnerHtml = i.ToString() + tbSpanInner.ToString();
                    tbLi.InnerHtml = tbSpanOuter.ToString();
                }
                else
                {
                    tbA.AddCssClass("page-link");
                    tbA.MergeAttribute("href", pageUrl(i));
                    tbA.InnerHtml = i.ToString();
                    tbLi.InnerHtml = tbA.ToString();
                }
                tbUl.InnerHtml += tbLi.ToString();
            }
            tbNav.InnerHtml = tbUl.ToString();

            return MvcHtmlString.Create(tbNav.ToString());   
        }
    }
}
