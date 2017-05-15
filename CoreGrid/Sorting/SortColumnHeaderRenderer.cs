using System.Globalization;
using GridMvc.Columns;
using GridMvc.Pagination;
using GridMvc.Utility;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Renderer for sortable column.
    ///     Object renders column name as link
    /// </summary>
    internal class QueryStringSortColumnHeaderRenderer : IGridColumnHeaderRenderer
    {
        private readonly QueryStringSortSettings _settings;

        public QueryStringSortColumnHeaderRenderer(QueryStringSortSettings settings)
        {
            _settings = settings;
        }

        public IHtmlContent Render(IGridColumn column)
        {
            return GetSortHeaderContent(column);
        }

        protected IHtmlContent GetSortHeaderContent(IGridColumn column)
        {
            var sortTitle = new TagBuilder("div");
            sortTitle.AddCssClass("grid-header-title");

            if (column.SortEnabled)
            {
                var columnHeaderLink = new TagBuilder("a");
                //changed by LM
                columnHeaderLink.InnerHtml.SetHtmlContent(column.Title);

                string url = GetSortUrl(column.Name, column.Direction);
                columnHeaderLink.Attributes.Add("href", url);
                sortTitle.InnerHtml.AppendHtml(columnHeaderLink);
            }
            else
            {
                var columnTitle = new TagBuilder("span");

                //changed by LM
                columnTitle.InnerHtml.SetHtmlContent(column.Title);
                sortTitle.InnerHtml.AppendHtml(columnTitle);
            }

            if (column.IsSorted)
            {
                sortTitle.AddCssClass("sorted");
                sortTitle.AddCssClass(column.Direction == GridSortDirection.Ascending ? "sorted-asc" : "sorted-desc");

                var sortArrow = new TagBuilder("span");
                sortArrow.AddCssClass("grid-sort-arrow");
                sortTitle.InnerHtml.AppendHtml(sortArrow);
            }


            return sortTitle;
        }

        private string GetSortUrl(string columnName, GridSortDirection? direction)
        {
            //switch direction for link:
            GridSortDirection newDir = direction == GridSortDirection.Ascending
                                           ? GridSortDirection.Descending
                                           : GridSortDirection.Ascending;
            //determine current url:
            var builder = new CustomQueryStringBuilder(_settings.Context.Request.Query.ToNameValueCollection());
            string url =
                builder.GetQueryStringExcept(new[]
                    {
                        GridPager.DefaultPageQueryParameter,
                        _settings.ColumnQueryParameterName,
                        _settings.DirectionQueryParameterName
                    });
            if (string.IsNullOrEmpty(url))
                url = "?";
            else
                url += "&";
            return string.Format("{0}{1}={2}&{3}={4}", url, _settings.ColumnQueryParameterName, columnName,
                                 _settings.DirectionQueryParameterName,
                                 ((int) newDir).ToString(CultureInfo.InvariantCulture));
        }
    }
}