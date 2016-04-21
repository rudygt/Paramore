﻿// ***********************************************************************
// Assembly         : paramore.brighter.commandprocessor
// Author           : ian
// Created          : 07-01-2014
//
// Last Modified By : ian
// Last Modified On : 07-29-2014
// ***********************************************************************
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Licence
/* The MIT License (MIT)
Copyright © 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

#endregion

namespace paramore.brighter.commandprocessor
{
    /// <summary>
    /// Class MessagingConfiguration.
    /// Used to set the components of a work queue solution
    /// </summary>
    public class MessagingConfiguration
    {
        /// <summary>
        /// Gets the message store.
        /// </summary>
        /// <value>The message store.</value>
        public IAmAMessageStore<Message> MessageStore { get; private set; }
        /// <summary>
        /// Gets the messaging gateway.
        /// </summary>
        /// <value>The messaging gateway.</value>
        public IAmAMessageProducer MessagingGateway { get; private set; }
        /// <summary>
        /// Gets the message mapper registry.
        /// </summary>
        /// <value>The message mapper registry.</value>
        public IAmAMessageMapperRegistry MessageMapperRegistry { get; private set; }

        public int MessageStoreWriteTimeout { get; set; }
        public int MessagingGatewaySendTimeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingConfiguration"/> class.
        /// </summary>
        /// <param name="messageStore">The message store.</param>
        /// <param name="messagingGateway">The messaging gateway.</param>
        /// <param name="messageMapperRegistry">The message mapper registry.</param>
        /// <param name="messageStoreWriteTimeout">How long to wait when writing to the message store</param>
        /// <param name="messagingGatewaySendTimeout">How long to wait when sending via the gateway</param>
        public MessagingConfiguration(
            IAmAMessageStore<Message> messageStore,
            IAmAMessageProducer messagingGateway,
            IAmAMessageMapperRegistry messageMapperRegistry,
            int messageStoreWriteTimeout = 300,
            int messagingGatewaySendTimeout = 300
            )
        {
            MessageStore = messageStore;
            MessagingGateway = messagingGateway;
            MessageMapperRegistry = messageMapperRegistry;
            MessageStoreWriteTimeout = messageStoreWriteTimeout;
            MessagingGatewaySendTimeout = messagingGatewaySendTimeout;
        }
    }
}