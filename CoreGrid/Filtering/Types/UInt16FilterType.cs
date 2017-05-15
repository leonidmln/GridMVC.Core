﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridMvc.Filtering.Types
{
    /// <summary>
    ///     Object contains some logic for filtering UInt16 columns
    /// </summary>
    internal sealed class UInt16FilterType : FilterTypeBase
    {
        public override Type TargetType
        {
            get { return typeof(UInt16); }
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
            UInt16 i;
            if (!UInt16.TryParse(value, out i))
                return null;
            return i;
        }
    }
}
