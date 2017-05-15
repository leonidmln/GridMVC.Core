using System;
using System.Collections.Generic;
using System.Linq;
using GridMvc.Columns;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace GridMvc.Html
{
    public static class GridExtensions
    {
        internal const string DefaultPartialViewName = "_Grid";

        public static HtmlGrid<T> Grid<T>(this IHtmlHelper helper, IEnumerable<T> items)
            where T : class
        {
            return Grid(helper, items, DefaultPartialViewName);
        }

        public static HtmlDetailsGrid<TKey, T> DetailsGrid<TKey, T>(this IHtmlHelper helper, Func<TKey, IEnumerable<T>> srcFunc)
            where TKey : class
            where T : class
        {
            DetailsGrid<TKey, T> detailsGrid = new DetailsGrid<TKey, T>(srcFunc, helper.ViewContext.HttpContext);
            HtmlDetailsGrid<TKey, T> grid = new HtmlDetailsGrid<TKey, T>(detailsGrid, helper, helper.ViewContext, DefaultPartialViewName);
            return grid;
        }


        public static HtmlGrid<T> Grid<T>(this IHtmlHelper helper, IEnumerable<T> items, string viewName)
            where T : class
        {
            return Grid(helper, items, GridRenderOptions.Create(string.Empty, viewName));
        }

        public static HtmlGrid<T> Grid<T>(this IHtmlHelper helper, IEnumerable<T> items,
                                          GridRenderOptions renderOptions)
            where T : class
        {
            var newGrid = new Grid<T>(items.AsQueryable(), helper.ViewContext.HttpContext);
            newGrid.RenderOptions = renderOptions;
            var htmlGrid = new HtmlGrid<T>(newGrid, helper, helper.ViewContext, renderOptions.ViewName);
            return htmlGrid;
        }

        public static HtmlGrid<T> Grid<T>(this IHtmlHelper helper, Grid<T> sourceGrid)
            where T : class
        {
            //wrap source grid:
            var htmlGrid = new HtmlGrid<T>(sourceGrid, helper, helper.ViewContext, DefaultPartialViewName);
            return htmlGrid;
        }

        public static HtmlGrid<T> Grid<T>(this IHtmlHelper helper, Grid<T> sourceGrid, string viewName)
            where T : class
        {
            //wrap source grid:
            var htmlGrid = new HtmlGrid<T>(sourceGrid, helper, helper.ViewContext, viewName);
            return htmlGrid;
        }

        

        //support IHtmlString in RenderValueAs method
        public static IGridColumn<T> RenderValueAs<T>(this IGridColumn<T> column, Func<T, HtmlString> constraint)
        {
            Func<T, string> valueContraint = a => constraint(a).Value;
            return column.RenderValueAs(valueContraint);
        }

        //support WebPages inline helpers
        //need to implement
        /*
        public static IGridColumn<T> RenderValueAs<T>(this IGridColumn<T> column,
                                                      Func<T, Func<object, HelperResult>> constraint)
        {
            Func<T, string> valueContraint = a => constraint(a)(null).ToHtmlString();
            return column.RenderValueAs(valueContraint);
        }*/
    }
}