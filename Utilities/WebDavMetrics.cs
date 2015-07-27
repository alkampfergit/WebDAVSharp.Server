﻿using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Utilities
{
    /// <summary>
    /// Helper for metrics.
    /// </summary>
    internal static class WebDavMetrics
    {

        private static readonly Timer _callTimer = Metric.Timer("Web Dav Calls", Unit.Calls);

        /// <summary>
        /// Used to 
        /// </summary>
        /// <returns></returns>
        public static TimerContext GetMetricCallContext()
        {
            return _callTimer.NewContext();
        }
    }
}
