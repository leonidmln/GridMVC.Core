﻿using System;

namespace GridMvc.Filtering.Types
{
    /// <summary>
    ///     Object builds filter expressions for boolean grid columns
    /// </summary>
    internal sealed class BooleanFilterType : FilterTypeBase
    {
        /// <summary>
        ///     Get target filter type
        /// </summary>
        /// <returns></returns>
        public override Type TargetType
        {
            get { return typeof (Boolean); }
        }

        public override GridFilterType GetValidType(GridFilterType type)
        {
            //in any case Boolean types must compare by Equals filter type
            //We can't compare: contains(true) and etc.
            return GridFilterType.Equals;
        }

        public override object GetTypedValue(string value)
        {
            bool b;
            if (!bool.TryParse(value, out b))
                return null;
            return b;
        }
    }
}