using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointCounting.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}