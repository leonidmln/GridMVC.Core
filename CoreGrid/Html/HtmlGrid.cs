using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using GridMvc.Columns;
using GridMvc.Pagination;
using Microsoft.AspNetCore.Http;

namespace GridMvc.Html
{
    /// <summary>
    ///     Grid adapter for html helper
    /// </summary>
    public class HtmlGrid<T> : GridHtmlOptions<T>, IGrid where T : class
    {
        protected readonly Grid<T> _source;


        public HtmlGrid(Grid<T> source, IHtmlHelper helper, ViewContext viewContext, string viewName)
            : base(source, helper, viewContext, viewName)
        {
            _source = source;
        }

        public override IGridHtmlOptions<T> WithDetails(IBaseOptions control)
        {
            //DetailsSourceFunction = control.DetailsSourceFunction;
            return base.WithDetails(control);
            
        }

        public System.Func<object, IEnumerable<object>> DetailsSourceFunction { get; set; }

        public bool HasDetails
        {
            get { return DetailsControl != null; }
        }
        public GridRenderOptions RenderOptions
        {
            get { return _source.RenderOptions; }
        }

        IGridColumnCollection IGrid.Columns
        {
            get { return _source.Columns; }
        }

        public string GridCssClass
        {
            get {return _source.GridCssClass;}
            set { _source.GridCssClass = value; }
        }


        IEnumerable<object> IGrid.ItemsToDisplay
        {
            get { return (_source as IGrid).ItemsToDisplay; }
        }

        //int IGrid.ItemsCount
        //{
        //    get { return _source.ItemsCount; }
        //    set { _source.ItemsCount = value; }
        //}

        int IGrid.DisplayingItemsCount
        {
            get { return _source.DisplayingItemsCount; }
        }

        IGridPager IGrid.Pager
        {
            get { return _source.Pager; }
        }

        bool IGrid.EnablePaging
        {
            get { return _source.EnablePaging; }
        }



   

        string IGrid.EmptyGridText
        {
            get { return _source.EmptyGridText; }
        }

        string IGrid.Language
        {
            get { return _source.Language; }
        }

        public ISanitizer Sanitizer
        {
            get { return _source.Sanitizer; }
        }

        string IGrid.GetRowCssClasses(object item)
        {
            return _source.GetRowCssClasses(item);
        }

        /// <summary>
        ///     To show Grid Items count
        ///     - Author by Jeeva
        /// </summary>
        int IGrid.ItemsCount
        {
            get { return _source.ItemsCount; }
        }

        IGridSettingsProvider IGrid.Settings
        {
            get { return _source.Settings; }
        }
    }
}