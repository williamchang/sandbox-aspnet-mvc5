/**
@file
    IBaseRepository.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-31
    .
@note
    References:
    - General:
        - Nothing.
        .
    .
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace SandboxAspnetMvc5.Data.Repositories {

/// <summary>
/// Extends the basic data repository interface with an interface that supports a number 
/// of specific methods while avoiding a concrete dependency.
/// </summary>
public interface IBaseRepository
{
    /// <summary>
    /// Returns the total number of entities in the database.
    /// </summary>
    //long Count<T>();

    /// <summary>
    /// Delete entity by id.
    /// </summary>
    //void Delete<T>(Object id);

    /// <summary>
    /// Delete entity.
    /// </summary>
    //void Delete(Object entity);

    /// <summary>
    /// Finds an object instance by an unique id.
    /// </summary>
    /// <param name="id">ID value</param>
    /// <exception cref="ObjectNotFoundException">If the row is not found</exception>
    /// <returns>T</returns>
    //T Find<T>(Object id);

    /// <summary>
    /// Retrieves the entity with the given id
    /// </summary>
    /// <returns>the entity or null if it doesn't exist</returns>
    //T Get<T>(Object id);

    /// <summary>
    /// For entities that have assigned Id's, you must explicitly call Save to add a new one.
    /// </summary>
    //T Save<T>(T entity);

    /// <summary>
    /// For entities that have assigned Id's, you should explicitly call Update to update an existing one.
    /// </summary>
    //T Update<T>(T entity);

    /// <summary>
    /// Begin transaction.
    /// </summary>
    //void BeginTransaction();

    /// <summary>
    /// End transaction.
    /// </summary>
    //void EndTransaction();
}

}
