using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace OpenStation
{
    [DelimitedRecord("|")]
    public class PlayerItem
    {
        public string Item;
    }
}
