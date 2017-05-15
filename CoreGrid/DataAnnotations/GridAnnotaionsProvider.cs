﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using GridMvc.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GridMvc.DataAnnotations
{
    internal class GridAnnotaionsProvider : IGridAnnotaionsProvider
    {
        public GridColumnAttribute GetAnnotationForColumn<T>(PropertyInfo pi)
        {
            pi = GetMetadataProperty<T>(pi);

            var gridAttr = pi.GetAttribute<GridColumnAttribute>();

            GridColumnAttribute dataAnnotationAttr = gridAttr;

            DataAnnotationsOptions dataAnnotations = ExtractDataAnnotations(pi);

            if (dataAnnotations != null)
            {
                if (gridAttr == null)
                {
                    dataAnnotationAttr = new GridColumnAttribute
                        {
                            Title = dataAnnotations.DisplayName,
                            FilterEnabled = dataAnnotations.FilterEnabled ?? false,
                            Format = dataAnnotations.Format
                        };
                }
                else
                {
                    dataAnnotationAttr.Title = string.IsNullOrEmpty(gridAttr.Title) ? dataAnnotations.DisplayName : gridAttr.Title;
                    dataAnnotationAttr.FilterEnabled = dataAnnotations.FilterEnabled ?? gridAttr.FilterEnabled;
                    dataAnnotationAttr.Format = string.IsNullOrEmpty(gridAttr.Format) ? dataAnnotations.Format : gridAttr.Format;
                }
            }
            return dataAnnotationAttr;
        }

        public GridHiddenColumnAttribute GetAnnotationForHiddenColumn<T>(PropertyInfo pi)
        {
            pi = GetMetadataProperty<T>(pi);

            var gridAttr = pi.GetAttribute<GridHiddenColumnAttribute>();
            if (gridAttr != null) return gridAttr;

            GridHiddenColumnAttribute dataAnnotationAttr = null;

            DataAnnotationsOptions dataAnnotations = ExtractDataAnnotations(pi);

            if (dataAnnotations != null)
            {
                dataAnnotationAttr = new GridHiddenColumnAttribute
                    {
                        Format = dataAnnotations.Format
                    };
            }
            return dataAnnotationAttr;
        }

        public bool IsColumnMapped(PropertyInfo pi)
        {
            return pi.GetAttribute<NotMappedColumnAttribute>() == null;
        }

        public GridTableAttribute GetAnnotationForTable<T>()
        {
            var modelType = typeof(T).GetAttribute<ModelMetadataTypeAttribute>();
            if (modelType != null)
            {
                var metadataAttr = modelType.MetadataType.GetAttribute<GridTableAttribute>();
                if (metadataAttr != null)
                    return metadataAttr;
            }
            return typeof(T).GetAttribute<GridTableAttribute>();
        }

        private PropertyInfo GetMetadataProperty<T>(PropertyInfo pi)
        {
            var modelType = typeof(T).GetAttribute<ModelMetadataTypeAttribute>();
            if (modelType != null)
            {
                PropertyInfo metadataProperty = modelType.MetadataType.GetProperty(pi.Name);
                if (metadataProperty != null)
                    return metadataProperty; //replace property
            }
            return pi;
        }

        private DataAnnotationsOptions ExtractDataAnnotations(PropertyInfo pi)
        {
            DataAnnotationsOptions result = null;
            var displayAttr = pi.GetAttribute<DisplayAttribute>();
            if (displayAttr != null)
            {
                result = new DataAnnotationsOptions();
                result.DisplayName = displayAttr.GetName();
                result.FilterEnabled = displayAttr.GetAutoGenerateFilter();
            }
            var displayFormatAttr = pi.GetAttribute<DisplayFormatAttribute>();
            if (displayFormatAttr != null)
            {
                if (result == null) result = new DataAnnotationsOptions();
                result.Format = displayFormatAttr.DataFormatString;
            }
            return result;
        }


        private class DataAnnotationsOptions
        {
            public string Format { get; set; }
            public string DisplayName { get; set; }
            public bool? FilterEnabled { get; set; }
            public int Order { get; set; }
        }
    }
}