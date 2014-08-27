/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace WinFormsMvp
{
    static public class Tracing
    {
        [DebuggerStepThrough]
        public static void Start(string message)
        {
            TraceEvent(TraceEventType.Start, message, false);
        }
        [DebuggerStepThrough]
        public static void Start(string message, params object[] args)
        {
            Start(string.Format(message, args));
        }

        [DebuggerStepThrough]
        public static void Stop(string message)
        {
            TraceEvent(TraceEventType.Stop, message, false);
        }
        [DebuggerStepThrough]
        public static void Stop(string message, params object[] args)
        {
            Stop(string.Format(message, args));
        }

        [DebuggerStepThrough]
        public static void Verbose(string message)
        {
            TraceEvent(TraceEventType.Verbose, message, false);
        }
        [DebuggerStepThrough]
        public static void Verbose(string message, params object[] args)
        {
            Verbose(string.Format(message, args));
        }
        
        [DebuggerStepThrough]
        public static void Information(string message)
        {
            TraceEvent(TraceEventType.Information, message, false);
        }
        [DebuggerStepThrough]
        public static void Information(string message, params object[] args)
        {
            Information(string.Format(message, args));
        }

        [DebuggerStepThrough]
        public static void Warning(string message)
        {
            TraceEvent(TraceEventType.Warning, message, false);
        }
        [DebuggerStepThrough]
        public static void Warning(string message, params object[] args)
        {
            Warning(string.Format(message, args));
        }

        [DebuggerStepThrough]
        public static void Error(string message)
        {
            TraceEvent(TraceEventType.Error, message, false);
        }
        [DebuggerStepThrough]
        public static void Error(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        [DebuggerStepThrough]
        public static void TraceEvent(TraceEventType type, string message, bool suppressTraceService)
        {
            TraceSource ts = new TraceSource("WinFormsMvp");

            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
            {
                if (type != TraceEventType.Verbose)
                {
                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                }
            }

            ts.TraceEvent(type, 0, message);
        }

        /// <summary>
        /// Writes trace information to the trace log.
        /// </summary>
        /// <param name="sourceType">The type of the object writing the trace message.</param>
        /// <param name="messagesCallback">A callback that builds a series of trace messages to write to the log.</param>
        public static void Verbose(Type sourceType, string messagesCallback)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (messagesCallback == null)
                throw new ArgumentNullException("messagesCallback");

            WriteInternal(sourceType, messagesCallback);
        }

        static void WriteInternal(Type sourceType, string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            Verbose(string.Format(CultureInfo.InvariantCulture,"{0}: {1}",sourceType.Name, message));
        }
    }
}
