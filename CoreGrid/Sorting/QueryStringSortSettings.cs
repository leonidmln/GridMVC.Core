using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GridMvc.Utility;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Grid sort settings takes from query string
    /// </summary>
    public class QueryStringSortSettings : IGridSortSettings
    {
        public const string DefaultDirectionQueryParameter = "grid-dir";
        public const string DefaultColumnQueryParameter = "grid-column";
        public readonly HttpContext Context;
        private string _columnQueryParameterName;
        private string _directionQueryParameterName;

      

        public QueryStringSortSettings(HttpContext context)
        {
            if (context == null)
                throw new ArgumentException("No http context here!");
            Context = context;
            ColumnQueryParameterName = DefaultColumnQueryParameter;
            DirectionQueryParameterName = DefaultDirectionQueryParameter;
        }

        public string ColumnQueryParameterName
        {
            get { return _columnQueryParameterName; }
            set
            {
                _columnQueryParameterName = value;
                RefreshColumn();
            }
        }

        public string DirectionQueryParameterName
        {
            get { return _directionQueryParameterName; }
            set
            {
                _directionQueryParameterName = value;
                RefreshDirection();
            }
        }

        #region IGridSortSettings Members

        public string ColumnName { get; set; }
        public GridSortDirection Direction { get; set; }

        #endregion

        private void RefreshColumn()
        {
            //Columns
            string currentSortColumn = Context.Request.Query.GetValue("ColumnQueryParameterName");
            ColumnName = currentSortColumn;
            if (string.IsNullOrEmpty(currentSortColumn))
            {
                Direction = GridSortDirection.Ascending;
            }
        }

        private void RefreshDirection()
        {
            //Direction
            string currentDirection = Context.Request.Query.GetValue(DirectionQueryParameterName);

            if (string.IsNullOrEmpty(currentDirection))
            {
                Direction = GridSortDirection.Ascending;
                return;
            }
            GridSortDirection dir;
            Enum.TryParse(currentDirection, true, out dir);
            Direction = dir;
        }
    }
}