﻿namespace GridMvc.Html
{
    public class GridRenderOptions
    {
        public GridRenderOptions(string gridName, string viewName)
        {
            ViewName = viewName;
            GridName = gridName;
            Selectable = true;
            AllowMultipleFilters = false;
        }

        public GridRenderOptions()
            : this(string.Empty, GridExtensions.DefaultPartialViewName)
        {
        }

        /// <summary>
        ///     Specify partial view name for render grid
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        ///     Is multiple filters allowed
        /// </summary>
        public bool AllowMultipleFilters { get; set; }

        /// <summary>
        ///     Gets or set grid items selectable
        /// </summary>
        public bool Selectable { get; set; }

        /// <summary>
        ///     Specify grid Id on the client side
        /// </summary>
        public string GridName { get; set; }


        /// <summary>
        ///     Specify to render grid body only
        /// </summary>
        public bool RenderRowsOnly { get; set; }

        /// <summary>
        ///     Does items count need to show
        ///     - Author Jeeva J
        /// </summary>
        public bool ShowGridItemsCount { get; set; }

        /// <summary>
        ///     To show string while show grid items count
        ///     - Author Jeeva J
        /// </summary>
        public string GridCountDisplayName { get; set; }

        public static GridRenderOptions Create(string gridName)
        {
            return new GridRenderOptions(gridName, GridExtensions.DefaultPartialViewName);
        }

        public static GridRenderOptions Create(string gridName, string viewName)
        {
            return new GridRenderOptions(gridName, viewName);
        }
    }
}