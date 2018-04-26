using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITUniver.TeleCalc.Web.Extensions
{
    public static class ButtonExtension
    {
        /// <summary>
        /// Сгенерировать кнопку для отправки формы с заданным именем
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name">Название кнопки</param>
        /// <returns>html-разметка</returns>

        public static MvcHtmlString Submit(this HtmlHelper html, 
            string name, 
            string onclick)
        {
            TagBuilder button = new TagBuilder("Input");
            button.AddCssClass("btn btn-default");
            button.Attributes["type"] = "submit";
            button.Attributes["value"] = name;
            button.Attributes["onclick"] = onclick;

            return new MvcHtmlString(button.ToString());
        }
    }
}