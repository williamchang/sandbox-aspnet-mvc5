/**
@file
    SystemRepository.cs
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

namespace SandboxAspnetMvc5.Data.Repositories {

/// <summary>System repository.</summary>
/// <remarks>
/// Dependencies:
/// Data.Entities.SystemSetting
/// </remarks>
public class SystemRepository : BaseRepository, ISystemRepository
{
    protected readonly string _sqlConnectionString;

    /// <summary>Default constructor.</summary>
    protected SystemRepository() {}

    /// <summary>Argument constructor.</summary>
    public SystemRepository(string sqlConnectionString)
    {
        this._sqlConnectionString = sqlConnectionString;
    }

    /// <summary>Create (INSERT) system log.</summary>
    public Entities.SystemLog CreateLog(Entities.SystemLog l)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (@DateCreated, @Thread, @Level, @Logger, @Message, @Exception);";
            sqlCommand.Parameters.AddWithValue("@DateCreated", l.DateCreated);
            sqlCommand.Parameters.AddWithValue("@Thread", l.Thread);
            sqlCommand.Parameters.AddWithValue("@Level", l.Level);
            sqlCommand.Parameters.AddWithValue("@Logger", l.Logger);
            sqlCommand.Parameters.AddWithValue("@Message", l.Message);
            sqlCommand.Parameters.AddWithValue("@Exception", l.Exception);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
        return l;
    }

    /// <summary>Create (INSERT) system setting.</summary>
    public Entities.SystemSetting CreateSetting(Entities.SystemSetting s)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES (@Id, @ApplicationName, @Name, @Value, @DateModified);";
            sqlCommand.Parameters.AddWithValue("@Id", s.Id);
            sqlCommand.Parameters.AddWithValue("@ApplicationName", s.ApplicationName);
            sqlCommand.Parameters.AddWithValue("@Name", s.Name);
            sqlCommand.Parameters.AddWithValue("@Value", s.Value);
            sqlCommand.Parameters.AddWithValue("@DateModified", s.DateModified);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
        return s;
    }

    /// <summary>Delete system log permanently.</summary>
    public void DeleteLog(int id)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM SystemLog WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
    }

    /// <summary>Delete system logs permanently (everything).</summary>
    public void DeleteLogs()
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM SystemLog;DBCC CHECKIDENT('SystemLog', RESEED, 0);";
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
    }

    /// <summary>Delete system setting permanently.</summary>
    public void DeleteSetting(Guid id)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM SystemSetting WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
    }

    /// <summary>Delete system setting permanently (duplicates are removed).</summary>
    public void DeleteSetting(string name)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM SystemSetting WHERE Name = @Name;";
            sqlCommand.Parameters.AddWithValue("@Name", name);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
    }

    /// <summary>Get system log.</summary>
    public Entities.SystemLog GetLog(int id)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM SystemLog WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            using(var sqlReader = sqlCommand.ExecuteReader()) {
                if(!sqlReader.Read()) {return null;}
                return new Entities.SystemLog {
                    Id = sqlReader.GetInt32(sqlReader.GetOrdinal("Id")),
                    DateCreated = sqlReader.GetDateTime(sqlReader.GetOrdinal("DateCreated")),
                    Thread = sqlReader.GetString(sqlReader.GetOrdinal("Thread")),
                    Level = sqlReader.GetString(sqlReader.GetOrdinal("Level")),
                    Logger = sqlReader.GetString(sqlReader.GetOrdinal("Logger")),
                    Message = sqlReader.GetString(sqlReader.GetOrdinal("Message")),
                    Exception = sqlReader.GetString(sqlReader.GetOrdinal("Exception"))
                };
            }
        }
    }

    /// <summary>Get system logs.</summary>
    public IList<Entities.SystemLog> GetLogs()
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM SystemLog ORDER BY id ASC;";
            using(var sqlReader = sqlCommand.ExecuteReader()) {
                var objs1 = new List<Entities.SystemLog>();
                while(sqlReader.Read()) {
                    objs1.Add(new Entities.SystemLog() {
                        Id = sqlReader.GetInt32(sqlReader.GetOrdinal("Id")),
                        DateCreated = sqlReader.GetDateTime(sqlReader.GetOrdinal("DateCreated")),
                        Thread = sqlReader.GetString(sqlReader.GetOrdinal("Thread")),
                        Level = sqlReader.GetString(sqlReader.GetOrdinal("Level")),
                        Logger = sqlReader.GetString(sqlReader.GetOrdinal("Logger")),
                        Message = sqlReader.GetString(sqlReader.GetOrdinal("Message")),
                        Exception = sqlReader.GetString(sqlReader.GetOrdinal("Exception"))
                    });
                }
                return objs1;
            }
        }
    }

    /// <summary>Get system setting.</summary>
    public Entities.SystemSetting GetSetting(Guid id)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM SystemSetting WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            using(var sqlReader = sqlCommand.ExecuteReader()) {
                if(!sqlReader.Read()) {return null;}
                return new Entities.SystemSetting {
                    Id = sqlReader.GetGuid(sqlReader.GetOrdinal("Id")),
                    ApplicationName = sqlReader.GetString(sqlReader.GetOrdinal("ApplicationName")),
                    Name = sqlReader.GetString(sqlReader.GetOrdinal("Name")),
                    Value = sqlReader.GetString(sqlReader.GetOrdinal("Value")),
                    DateModified = sqlReader.GetDateTime(sqlReader.GetOrdinal("DateModified"))
                };
            }
        }
    }

    /// <summary>Get system setting.</summary>
    public Entities.SystemSetting GetSetting(string name)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM SystemSetting WHERE Name = @Name;";
            sqlCommand.Parameters.AddWithValue("@Name", name);
            using(var sqlReader = sqlCommand.ExecuteReader()) {
                if(!sqlReader.Read()) {return null;}
                return new Entities.SystemSetting {
                    Id = sqlReader.GetGuid(sqlReader.GetOrdinal("Id")),
                    ApplicationName = sqlReader.GetString(sqlReader.GetOrdinal("ApplicationName")),
                    Name = sqlReader.GetString(sqlReader.GetOrdinal("Name")),
                    Value = sqlReader.GetString(sqlReader.GetOrdinal("Value")),
                    DateModified = sqlReader.GetDateTime(sqlReader.GetOrdinal("DateModified"))
                };
            }
        }
    }

    /// <summary>Get system settings.</summary>
    public IList<Entities.SystemSetting> GetSettings()
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM SystemSetting ORDER BY ApplicationName ASC, Name ASC;";
            using(var sqlReader = sqlCommand.ExecuteReader()) {
                var objs1 = new List<Entities.SystemSetting>();
                while(sqlReader.Read()) {
                    objs1.Add(new Entities.SystemSetting() {
                        Id = sqlReader.GetGuid(sqlReader.GetOrdinal("Id")),
                        ApplicationName = sqlReader.GetString(sqlReader.GetOrdinal("ApplicationName")),
                        Name = sqlReader.GetString(sqlReader.GetOrdinal("Name")),
                        Value = sqlReader.GetString(sqlReader.GetOrdinal("Value")),
                        DateModified = sqlReader.GetDateTime(sqlReader.GetOrdinal("DateModified"))
                    });
                }
                return objs1;
            }
        }
    }

    /// <summary>Set (UPDATE) system log.</summary>
    public Entities.SystemLog SetLog(Entities.SystemLog l)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "UPDATE SystemLog SET Thread = @Thread, Logger = @Logger, Message = @Message, Exception = @Exception WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", l.Id);
            sqlCommand.Parameters.AddWithValue("@Thread", l.Thread);
            sqlCommand.Parameters.AddWithValue("@Logger", l.Logger);
            sqlCommand.Parameters.AddWithValue("@Message", l.Message);
            sqlCommand.Parameters.AddWithValue("@Exception", l.Exception);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
        return l;
    }

    /// <summary>Set (UPDATE) system setting.</summary>
    public Entities.SystemSetting SetSetting(Entities.SystemSetting s)
    {
        using(var sqlConnection = new System.Data.SqlClient.SqlConnection(_sqlConnectionString))
        using(var sqlCommand = sqlConnection.CreateCommand()) {
            sqlConnection.Open();
            sqlCommand.CommandText = "UPDATE SystemSetting SET ApplicationName = @ApplicationName, Name = @Name, Value = @Value, DateModified = @DateModified WHERE Id = @Id;";
            sqlCommand.Parameters.AddWithValue("@Id", s.Id);
            sqlCommand.Parameters.AddWithValue("@ApplicationName", s.ApplicationName);
            sqlCommand.Parameters.AddWithValue("@Name", s.Name);
            sqlCommand.Parameters.AddWithValue("@Value", s.Value);
            sqlCommand.Parameters.AddWithValue("@DateModified", s.DateModified);
            var numRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numRowsAffected <= 0) {
                throw new Exception(String.Format("numRowsAffected:{0}", numRowsAffected));
            }
        }
        return s;
    }

    /// <summary>Set (UPDATE) or create (INSERT) system setting.</summary>
    public Entities.SystemSetting SetSetting(string name, string value)
    {
        try {
            Entities.SystemSetting obj1 = this.GetSetting(name);
            obj1.Value = value;
            obj1.DateModified = DateTime.Now;
            return this.SetSetting(obj1);
        } catch(NullReferenceException) {
            return CreateSetting(new Entities.SystemSetting() {
                Name = name,
                Value = value,
                DateModified = DateTime.Now
            });
        }
    }
}

}
