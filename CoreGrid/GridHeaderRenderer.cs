using System;
using System.Collections.Generic;
using System.Text;
using GridMvc.Columns;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace GridMvc
{
    public class GridHeaderRenderer : GridStyledRenderer, IGridColumnHeaderRenderer
    {
        private const string ThClass = "grid-header";

        private readonly List<IGridColumnHeaderRenderer> _additionalRenders = new List<IGridColumnHeaderRenderer>();

        public GridHeaderRenderer()
        {
            AddCssClass(ThClass);
        }

        public IHtmlContent Render(IGridColumn column)
        {
            string cssStyles = GetCssStylesString();
            string cssClass = GetCssClassesString();

            if (!string.IsNullOrWhiteSpace(column.Width))
                cssStyles = string.Concat(cssStyles, " width:", column.Width, ";").Trim();

            var builder = new TagBuilder("th");
            if (!string.IsNullOrWhiteSpace(cssClass))
                builder.AddCssClass(cssClass);
            if (!string.IsNullOrWhiteSpace(cssStyles))
                builder.MergeAttribute("style", cssStyles);

            builder.InnerHtml.SetHtmlContent(RenderAdditionalContent(column));

            return builder;
        }

        protected virtual IHtmlContent RenderAdditionalContent(IGridColumn column)
        {
            HtmlString strHtml = new HtmlString(string.Empty);
            
            if (_additionalRenders.Count == 0)
                return strHtml;


            using (System.IO.StringWriter ms = new System.IO.StringWriter())
            {

                foreach (IGridColumnHeaderRenderer gridColumnRenderer in _additionalRenders)
                {
                   
                    gridColumnRenderer.Render(column).WriteTo(ms, System.Text.Encodings.Web.HtmlEncoder.Default);
                }

                return new HtmlString(ms.ToString());
            }
        }

        public void AddAdditionalRenderer(IGridColumnHeaderRenderer renderer)
        {
            if (_additionalRenders.Contains(renderer))
                throw new InvalidOperationException("This renderer already exist");
            _additionalRenders.Add(renderer);
        }

        public void InsertAdditionalRenderer(int position, IGridColumnHeaderRenderer renderer)
        {
            if (_additionalRenders.Contains(renderer))
                throw new InvalidOperationException("This renderer already exist");
            _additionalRenders.Insert(position, renderer);
        }
    }
}