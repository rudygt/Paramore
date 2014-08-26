// ***********************************************************************
// Assembly         : paramore.brighter.commandprocessor
// Author           : ian
// Created          : 07-01-2014
//
// Last Modified By : ian
// Last Modified On : 07-01-2014
// ***********************************************************************
// <copyright file="MessageHeader.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Licence
/* The MIT License (MIT)
Copyright � 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

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

using System;
using System.Collections.Generic;

namespace paramore.brighter.commandprocessor
{
    /// <summary>
    /// Enum MessageType
    /// The type of a message, used on the receiving side of a Task Queue to handle the message appropriately
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The m t_ none{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        MT_NONE = 0,
        /// <summary>
        /// The m t_ command{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        MT_COMMAND = 1,
        /// <summary>
        /// The m t_ event{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        MT_EVENT = 2,
        /// <summary>
        /// The m t_ document{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        MT_DOCUMENT = 3,
        /// <summary>
        /// The m t_ quit{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        MT_QUIT = 4
    }

    /// <summary>
    /// Class MessageHeader
    /// The header for a <see cref="Message"/>
    /// </summary>
    public class MessageHeader : IEquatable<MessageHeader>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; private set; }
        /// <summary>
        /// Gets the topic.
        /// </summary>
        /// <value>The topic.</value>
        public string Topic { get; private set; }
        /// <summary>
        /// Gets the type of the message. Used for routing the message to a handler
        /// </summary>
        /// <value>The type of the message.</value>
        public MessageType MessageType { get; private set; }
        /// <summary>
        /// Gets the bag.
        /// </summary>
        /// <value>The bag.</value>
        public Dictionary<string, object> Bag { get; private set; } //intended for extended headers

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHeader"/> class.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="topic">The topic.</param>
        /// <param name="messageType">Type of the message.</param>
        public MessageHeader(Guid messageId, string topic, MessageType messageType)
        {
            Id = messageId;
            Topic = topic;
            MessageType = messageType;
            Bag = new Dictionary<string, object>();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals(MessageHeader other)
        {
            return Id == other.Id && Topic == other.Topic && MessageType == other.MessageType;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MessageHeader) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Topic != null ? Topic.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) MessageType;
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(MessageHeader left, MessageHeader right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(MessageHeader left, MessageHeader right)
        {
            return !Equals(left, right);
        }
    }
}