﻿using System;

namespace GridMvc.DataAnnotations
{
    /// <summary>
    ///     Specify common grid.mvc options
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GridTableAttribute : Attribute
    {
        public GridTableAttribute()
        {
            PagingEnabled = false;
            PageSize = 0;
            PagingMaxDisplayedPages = 0;
        }

        /// <summary>
        ///     Enable or disable paging of the grid
        /// </summary>
        public bool PagingEnabled { get; set; }

        /// <summary>
        ///     Sets ot get page size of the grid
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Sets ot get count of displaying pages
        /// </summary>
        public int PagingMaxDisplayedPages { get; set; }
    }
}