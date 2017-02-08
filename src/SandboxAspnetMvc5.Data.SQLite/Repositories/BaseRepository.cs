/**
@file
    BaseRepository.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2017-02-06
    - Modified: 2017-02-07
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

namespace SandboxAspnetMvc5.Data.SQLite.Repositories {

/// <summary>Base Repository.</summary>
public class BaseRepository : Data.Interfaces.IBaseRepository
{
    protected Entities.SystemLog _sysError = null;

    /// <summary>Default constructor.</summary>
    protected BaseRepository() {}

    public void CreateDatabase()
    {
        System.Data.SQLite.SQLiteConnection.CreateFile("Sandbox.sqlite3");
    }
}

}
