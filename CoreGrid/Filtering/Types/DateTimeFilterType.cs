﻿using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GridMvc.Filtering.Types
{
    /// <summary>
    ///     Object contains some logic for filtering DateTime columns
    /// </summary>
    internal sealed class DateTimeFilterType : FilterTypeBase
    {
        public override Type TargetType
        {
            get { return typeof(DateTime); }
        }

        public override Expression GetFilterExpression(Expression leftExpr, string value, GridFilterType filterType)
        {
            //var dateExpr = Expression.Property(leftExpr, leftExpr.Type, "Date");

            //if (filterType == GridFilterType.Equals)
            //{
            //    var dateObj = GetTypedValue(value);
            //    if (dateObj == null) return null;//not valid

            //    var startDate = Expression.Constant(dateObj);
            //    var endDate = Expression.Constant(((DateTime)dateObj).AddDays(1));

            //    var left = Expression.GreaterThanOrEqual(leftExpr, startDate);
            //    var right = Expression.LessThan(leftExpr, endDate);

            //    return Expression.And(left, right);
            //}

            return base.GetFilterExpression(leftExpr, value, filterType);
        }

        /// <summary>
        ///     There are filter types that allowed for DateTime column
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override GridFilterType GetValidType(GridFilterType type)
        {
            switch (type)
            {
                case GridFilterType.Equals:
                case GridFilterType.GreaterThan:
                case GridFilterType.GreaterThanOrEquals:
                case GridFilterType.LessThan:
                case GridFilterType.LessThanOrEquals:
                    return type;
                default:
                    return GridFilterType.Equals;
            }
        }

        public override object GetTypedValue(string value)
        {
            DateTime date;
            if (!DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return null;
            return date;
        }
    }
}