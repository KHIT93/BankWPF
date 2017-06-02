using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BankClassLib
{
    //Responsible for adding log entries for generic exceptions
    public class ExceptionLogHandler
    {
        string sSource;
        string sLog = "Application";
        string sEvent;
        int sEventID = 9940;
        public ExceptionLogHandler(string exSource, string exEvent)
        {
            this.sSource = exSource;
            this.sEvent = exEvent;
        }
        public ExceptionLogHandler(string exSource, string exEvent, int exEventID)
        {
            this.sSource = exSource;
            this.sEvent = exEvent;
            this.sEventID = exEventID;
        }
        public void Log()
        {
            if (!EventLog.SourceExists(this.sSource))
            {
                EventLog.CreateEventSource(this.sSource, this.sLog);
            }
            EventLog.WriteEntry(this.sSource, this.sEvent, EventLogEntryType.Warning, this.sEventID);
        }
    }
}
