using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace OpenStation
{
    [DelimitedRecord("|")]
    public class ScheduleItem
    {
        [FieldConverter(ConverterKind.Date, "HH:mm:ss")]
        public DateTime Airtime;
        public string ItemTitle;
        public string ItemFilename;
    }
}
