/**
@file
    ISystemRepository.cs
@author
    William Chang
@version
    0.2
@date
    - Created: 2015-08-20
    - Modified: 2016-10-22
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

namespace SandboxAspnetMvc5.Data.Interfaces {

/// <summary>System repository interface.</summary>
/// <remarks>
/// Dependencies:
/// Data.Entities.SystemSetting
/// </remarks>
public interface ISystemRepository : IBaseRepository
{
    /// <summary>Create (INSERT) system log.</summary>
    Entities.SystemLog CreateLog(Entities.SystemLog l);

    /// <summary>Create (INSERT) system setting.</summary>
    Entities.SystemSetting CreateSetting(Entities.SystemSetting s);

    /// <summary>Delete system log permanently.</summary>
    void DeleteLog(int id);

    /// <summary>Delete system logs permanently (everything).</summary>
    void DeleteLogs();

    /// <summary>Delete system setting permanently.</summary>
    void DeleteSetting(Guid id);

    /// <summary>Delete system setting permanently (duplicates are removed).</summary>
    void DeleteSetting(string name);

    /// <summary>Get system log.</summary>
    Entities.SystemLog GetLog(int id);

    /// <summary>Get system logs.</summary>
    IList<Entities.SystemLog> GetLogs();

    /// <summary>Get system setting.</summary>
    Entities.SystemSetting GetSetting(Guid id);

    /// <summary>Get system setting.</summary>
    Entities.SystemSetting GetSetting(string name);

    /// <summary>Get system settings.</summary>
    IList<Entities.SystemSetting> GetSettings();

    /// <summary>Set (UPDATE) system log.</summary>
    Entities.SystemLog SetLog(Entities.SystemLog l);

    /// <summary>Set (UPDATE) system setting.</summary>
    Entities.SystemSetting SetSetting(Entities.SystemSetting s);

    /// <summary>Set (UPDATE) or create (INSERT) system setting.</summary>
    Entities.SystemSetting SetSetting(string name, string value);
}

}
