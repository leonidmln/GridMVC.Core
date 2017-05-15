﻿using System;

namespace GridMvc.Filtering.Types
{
    /// <summary>
    ///     Object contains some logic for filtering Double columns
    /// </summary>
    internal sealed class DoubleFilterType : FilterTypeBase
    {
        public override Type TargetType
        {
            get { return typeof (Double); }
        }

        public override GridFilterType GetValidType(GridFilterType type)
        {
            switch (type)
            {
                case GridFilterType.Equals:
                case GridFilterType.GreaterThan:
                case GridFilterType.LessThan:
                case GridFilterType.GreaterThanOrEquals:
                case GridFilterType.LessThanOrEquals:
                    return type;
                default:
                    return GridFilterType.Equals;
            }
        }

        public override object GetTypedValue(string value)
        {
            double db;
            if (!double.TryParse(value, out db))
                return null;
            return db;
        }
    }
}