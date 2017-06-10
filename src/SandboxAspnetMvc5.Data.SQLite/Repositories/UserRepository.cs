/**
@file
    UserRepository.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2017-06-04
    - Modified: 2017-06-04
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

/// <summary>User repository.</summary>
/// <remarks>
/// Dependencies:
/// Data.Entities.User
/// Data.Entities.UserAccount
/// Data.Entities.UserProfile
/// Data.Entities.UserSetting
/// </remarks>
public class UserRepository : BaseRepository, Interfaces.IUserRepository
{
    protected readonly string _sqlConnectionString;

    /// <summary>Default constructor.</summary>
    protected UserRepository() {}

    /// <summary>Argument constructor.</summary>
    public UserRepository(string sqlConnectionString)
    {
        this._sqlConnectionString = sqlConnectionString;
    }

    /// <summary>Create (INSERT) user.</summary>
    public Entities.UserAccount CreateUser(Entities.UserAccount u)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create (INSERT) user account.</summary>
    public Entities.UserCredential CreateUserAccount(Entities.UserCredential a)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create (INSERT) user profile.</summary>
    public Entities.UserProfile CreateUserProfile(Entities.UserProfile p)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create (INSERT) user profile.</summary>
    public int CreateUserProfile(Guid userId, IList<Entities.UserProfile> objs1)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create (INSERT) user setting.</summary>
    public Entities.UserSetting CreateUserSetting(Entities.UserSetting s)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user.</summary>
    public Entities.UserAccount GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user by email.</summary>
    public Entities.UserAccount GetUser(string email)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user by email and (hashed) password. Only for user login authentication.</summary>
    public Entities.UserAccount GetUser(string email, string passwordHashed)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get (first) user account.</summary>
    public Entities.UserCredential GetUserAccount(Entities.UserAccount u)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get (first) user account.</summary>
    public Entities.UserCredential GetUserAccount(Guid userId)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user account by activation key.</summary>
    public Entities.UserCredential GetUserAccount(string activationKey)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user profile subtypes (for key).</summary>
    /// <remarks>For HTML form select element.</remarks>
    public IList<Entities.UserProfile> GetUserProfile(Guid userId)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get users.</summary>
    public IList<Entities.UserAccount> GetUsers()
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user setting.</summary>
    public Entities.UserSetting GetUserSetting(Entities.UserAccount u, string key)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get user setting.</summary>
    public Entities.UserSetting GetUserSetting(Guid userId, string key)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get trashed users.</summary>
    public IList<Entities.UserAccount> GetUsersTrashed()
    {
        throw new NotImplementedException();
    }

    /// <summary>Is user exist.</summary>
    public bool IsUserExist(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>Is user email exist.</summary>
    public bool IsUserExist(string email)
    {
        throw new NotImplementedException();
    }

    /// <summary>Remove (DELETE) user permanently.</summary>
    public void RemoveUser(Entities.UserAccount u)
    {
        throw new NotImplementedException();
    }

    /// <summary>Remove (DELETE) user permanently.</summary>
    public void RemoveUser(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>Remove (DELETE) user permanently.</summary>
    public void RemoveUser(string email)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>Remove (DELETE) user profile permanently.</summary>
    public void RemoveUserProfile(Entities.UserProfile p)
    {
        throw new NotImplementedException();
    }

    /// <summary>Remove (DELETE) user setting permanently.</summary>
    public void RemoveUserSetting(Entities.UserSetting s)
    {
        throw new NotImplementedException();
    }

    /// <summary>Remove (DELETE) user setting permanently (duplicates are removed).</summary>
    public void RemoveUserSetting(Guid userId, string key)
    {
        throw new NotImplementedException();
    }

    /// <summary>Restore user.</summary>
    public void RestoreUser(Guid id)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>Set user account activation key. Only for user login forgot.</summary>
    public Entities.UserAccount SetUserAccountActivationKey(string email, string activationKey)
    {
        throw new NotImplementedException();
    }

    /// <summary>Set (UPDATE) user.</summary>
    public Entities.UserAccount SetUser(Entities.UserAccount u)
    {
        throw new NotImplementedException();
    }

    /// <summary>Set (UPDATE) user. Only for persistent cookie or query string.</summary>
    public Entities.UserAccount SetUser(Entities.UserAccount u, string sessionKey)
    {
        throw new NotImplementedException();
    }

    /// <summary>Set (UPDATE) user account. Only for user activation.</summary>
    public Entities.UserCredential SetUserAccount(Entities.UserCredential a, string password, string activationKey, bool isActivated)
    {
        throw new NotImplementedException();
    }

    /// <summary>Set (UPDATE) user account. Only for user activation.</summary>
    public Entities.UserCredential SetUserAccount(Entities.UserAccount u, string password, string activationKey, bool isActivated)
    {
        return SetUserAccount(GetUserAccount(u), password, activationKey, isActivated);
    }

    /// <summary>Set (UPDATE) or create (INSERT) user setting.</summary>
    public Entities.UserSetting SetUserSetting(Entities.UserAccount u, string key, string value)
    {
        throw new NotImplementedException();
    }

    /// <summary>Set (UPDATE) or create (INSERT) user setting.</summary>
    public Entities.UserSetting SetUserSetting(Guid userId, string key, string value)
    {
        throw new NotImplementedException();
    }

    /// <summary>Trash user.</summary>
    public void TrashUser(Guid id)
    {
        throw new NotImplementedException();
    }
}

}
