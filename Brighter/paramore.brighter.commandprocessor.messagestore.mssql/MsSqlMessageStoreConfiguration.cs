// ***********************************************************************
// Assembly         : paramore.brighter.commandprocessor.messagestore.mssql
// Author           : ian
// Created          : 01-26-2015
//
// Last Modified By : ian
// Last Modified On : 02-26-2015
// ***********************************************************************
// <copyright file="MsSqlMessageStoreConfiguration.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Licence
/* The MIT License (MIT)
Copyright � 2014 Francesco Pighi <francesco.pighi@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the �Software�), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

#endregion

namespace paramore.brighter.commandprocessor.messagestore.mssql
{
    /// <summary>
    /// Class MsSqlMessageStoreConfiguration.
    /// </summary>
    public class MsSqlMessageStoreConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlMessageStoreConfiguration"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="messageStoreTableName">Name of the message store table.</param>
        /// <param name="databaseType">Type of the database.</param>
        public MsSqlMessageStoreConfiguration(string connectionString, string messageStoreTableName, DatabaseType databaseType)
        {
            Type = databaseType;
            MessageStoreTableName = messageStoreTableName;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; private set; }
        /// <summary>
        /// Gets the name of the message store table.
        /// </summary>
        /// <value>The name of the message store table.</value>
        public string MessageStoreTableName { get; private set; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public DatabaseType Type { get; private set; }

        /// <summary>
        /// Enum DatabaseType
        /// </summary>
        public enum DatabaseType
        {
            /// <summary>
            /// The ms SQL server
            /// </summary>
            MsSqlServer,
            /// <summary>
            /// The SQL ce
            /// </summary>
            SqlCe
        }
    }
}