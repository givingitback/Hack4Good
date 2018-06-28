using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charitygame.Models
{
    public class Game
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sentiment_type_name { get; set; }
        public int charity_id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
