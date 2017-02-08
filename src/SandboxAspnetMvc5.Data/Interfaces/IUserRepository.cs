/**
@file
    IUserRepository.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-26
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

/// <summary>User repository interface.</summary>
/// <remarks>
/// Library Dependencies:
/// Data.Entities.User
/// Data.Entities.UserAccount
/// Data.Entities.UserProfile
/// Data.Entities.UserSetting
/// </remarks>
public interface IUserRepository : IBaseRepository
{
    /// <summary>Create (INSERT) user.</summary>
    Entities.UserAccount CreateUser(Entities.UserAccount u);

    /// <summary>Create (INSERT) user account.</summary>
    Entities.UserCredential CreateUserAccount(Entities.UserCredential a);

    /// <summary>Create (INSERT) user profile.</summary>
    Entities.UserProfile CreateUserProfile(Entities.UserProfile p);

    /// <summary>Create (INSERT) user profile.</summary>
    int CreateUserProfile(Guid userId, IList<Entities.UserProfile> objs1);

    /// <summary>Create (INSERT) user setting.</summary>
    Entities.UserSetting CreateUserSetting(Entities.UserSetting s);

    /// <summary>Get user.</summary>
    Entities.UserAccount GetUser(Guid id);

    /// <summary>Get user by email.</summary>
    Entities.UserAccount GetUser(string email);

    /// <summary>Get user by email and (hashed) password. Only for user login authentication.</summary>
    Entities.UserAccount GetUser(string email, string passwordHashed);

    /// <summary>Get user account.</summary>
    Entities.UserCredential GetUserAccount(Entities.UserAccount u);

    /// <summary>Get (first) user account.</summary>
    Entities.UserCredential GetUserAccount(Guid id);

    /// <summary>Get (first) user account by activation key.</summary>
    Entities.UserCredential GetUserAccount(string activationKey);

    /// <summary>Get user profile subtypes (for key).</summary>
    /// <remarks>For HTML form select element.</remarks>
    IList<Entities.UserProfile> GetUserProfile(Guid userId);

    /// <summary>Get users.</summary>
    IList<Entities.UserAccount> GetUsers();

    /// <summary>Get user setting.</summary>
    Entities.UserSetting GetUserSetting(Entities.UserAccount u, string key);

    /// <summary>Get user setting.</summary>
    Entities.UserSetting GetUserSetting(Guid userId, string key);

    /// <summary>Get trashed users.</summary>
    IList<Entities.UserAccount> GetUsersTrashed();

    /// <summary>Is user exist.</summary>
    bool IsUserExist(Guid id);

    /// <summary>Is user email exist.</summary>
    bool IsUserExist(string email);

    /// <summary>Remove (DELETE) user permanently.</summary>
    void RemoveUser(Entities.UserAccount u);

    /// <summary>Remove (DELETE) user permanently.</summary>
    void RemoveUser(Guid id);

    /// <summary>Remove (DELETE) user permanently.</summary>
    void RemoveUser(string email);

    /// <summary>Remove (DELETE) user profile permanently.</summary>
    void RemoveUserProfile(Entities.UserProfile p);

    /// <summary>Remove (DELETE) user setting permanently.</summary>
    void RemoveUserSetting(Entities.UserSetting s);
    
    /// <summary>Remove (DELETE) user setting permanently (duplicates are removed).</summary>
    void RemoveUserSetting(Guid userId, string key);

    /// <summary>Restore user.</summary>
    void RestoreUser(Guid id);

    /// <summary>Set activation key. Only for user login forgot.</summary>
    Entities.UserAccount SetUserAccountActivationKey(string email, string activationKey);

    /// <summary>Set (UPDATE) user.</summary>
    Entities.UserAccount SetUser(Entities.UserAccount u);

    /// <summary>Set (UPDATE) user. Only for persistent cookie or query string.</summary>
    Entities.UserAccount SetUser(Entities.UserAccount u, string sessionKey);

    /// <summary>Set (UPDATE) user account. Only for user activation.</summary>
    Entities.UserCredential SetUserAccount(Entities.UserCredential a, string password, string activationKey, bool isActivated);

    /// <summary>Set (UPDATE) user account. Only for user activation.</summary>
    Entities.UserCredential SetUserAccount(Entities.UserAccount u, string password, string activationKey, bool isActivated);

    /// <summary>Set (UPDATE) or create (INSERT) user setting.</summary>
    Entities.UserSetting SetUserSetting(Entities.UserAccount u, string key, string value);

    /// <summary>Set (UPDATE) or create (INSERT) user setting.</summary>
    Entities.UserSetting SetUserSetting(Guid userId, string key, string value);

    /// <summary>Trash user.</summary>
    void TrashUser(Guid id);
}

}
