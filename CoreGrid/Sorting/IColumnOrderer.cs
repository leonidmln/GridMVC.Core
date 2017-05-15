﻿using System.Linq;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Custom user column orderer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IColumnOrderer<T>
    {
        IQueryable<T> ApplyOrder(IQueryable<T> items);
        IQueryable<T> ApplyOrder(IQueryable<T> items, GridSortDirection direction);
    }
}