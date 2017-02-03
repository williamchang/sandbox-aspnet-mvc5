/**
@file
    BaseRepository.cs
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

/// <summary>Base Repository.</summary>
public class BaseRepository : IBaseRepository
{
    protected Entities.SystemLog _sysError = null;

    /// <summary>Default constructor.</summary>
    protected BaseRepository() {}
}

}
