﻿#region Licence
/* The MIT License (MIT)
Copyright © 2015 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

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

using System;
using paramore.brighter.commandprocessor.eventsourcing.Handlers;

namespace paramore.brighter.commandprocessor.eventsourcing.Attributes
{
    /// <summary>
    /// Class UseCommandSourcingAttribute.
    /// We use this attribute to indicate that we want to use Event Sourcing, where the application state is the system of record
    /// but we want to store the commands that led to the current application state, so that we can rebuild application state
    /// or recreate commands
    /// See  <a href="http://martinfowler.com/eaaDev/EventSourcing.html">Martin Fowler Event Sourcing</a> for more on this approach.
    /// </summary>
    public class UseCommandSourcingAttribute : RequestHandlerAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHandlerAttribute"/> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="timing">The timing.</param>
        public UseCommandSourcingAttribute(int step, HandlerTiming timing = HandlerTiming.Before) : base(step, timing){}


        /// <summary>
        /// Gets the type of the handler.
        /// </summary>
        /// <returns>Type.</returns>
        public override Type GetHandlerType()
        {
            return typeof (CommandSourcingHandler<>);
        }

    }
}
