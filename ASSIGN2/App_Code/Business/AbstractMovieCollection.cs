using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for AbstractCollection
    /// </summary>
    public abstract class AbstractBusinessCollection<T> : Collection<T> where T : AbstractBusiness
    {
        public AbstractBusinessCollection()
        {

        }

        /// <summary>
        /// Add a review object to this collection
        /// </summary>
        public void AddToCollection(T entity)
        {
            this.Add(entity);
        }
        /// <summary>
        /// Remove a review from collection
        /// </summary>        
        public void RemoveFromCollection(T entity)
        {
            this.Remove(entity);
        }


        /// <summary>
        /// Search for the object with the passed id value
        /// </summary>
        public T FindById(int id)
        {
            foreach (T entity in this)
            {
                if (entity.Id == id)
                    return entity;
            }
            return null;
        }

        #region properties
        /// <summary>
        /// Is this collection empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }
        #endregion
    }
}