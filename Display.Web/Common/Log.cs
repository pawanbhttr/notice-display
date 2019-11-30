using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Display.Web
{
    public static class Log
    {
        private static ILog _logger;

        private static void Initialize(Type type)
        {
            if (_logger == null)
            {
                _logger = LogManager.GetLogger(type);
            }
            else
            {
                if (_logger.ToString() != type.FullName)
                {
                    _logger = LogManager.GetLogger(type);
                }
            }
        }

        public static void ErrLog(this Exception e)
        {
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            Initialize(type);
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(string.Format("Location: {0}. Method: {1}. Message: {2}.", type.FullName, method.Name, e.Message));
            }
        }
    }
}