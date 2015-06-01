﻿using System;
using System.Collections.Generic;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// A cache holding the known mappings between view model types and dialog types.
    /// </summary>
    internal class DialogTypeLocatorCache
    {
        private readonly Dictionary<Type, Type> cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeLocatorCache"/> class.
        /// </summary>
        internal DialogTypeLocatorCache()
        {
            cache = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Adds the specified view model type with its corresponding dialog type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        internal void Add(Type viewModelType, Type dialogType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");
            if (dialogType == null)
                throw new ArgumentNullException("dialogType");
            if (cache.ContainsKey(viewModelType))
                throw new ArgumentException(Resources.ViewModelTypeAlreadyAdded.CurrentFormat(viewModelType), "viewModelType");

            cache.Add(viewModelType, dialogType);
        }

        /// <summary>
        /// Gets the dialog type for specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>The dialog type if found; otherwise null.</returns>
        internal Type Get(Type viewModelType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");

            Type dialogType;
            cache.TryGetValue(viewModelType, out dialogType);
            return dialogType;
        }

        /// <summary>
        /// Removes all view model types with its corresponding dialog types.
        /// </summary>
        internal void Clear()
        {
            cache.Clear();
        }

        /// <summary>
        /// Gets the number of dialog type/view model type pairs contained in the cache.
        /// </summary>
        internal int Count
        {
            get { return cache.Count; }
        }
    }
}