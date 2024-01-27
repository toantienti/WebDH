﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDH.Models
{
    public class CombinedStatistical
    {
        public List<StatisticalAccount> StatisticalByCategory { get; set; }
        public List<StatisticalAccount> StatisticalByMonth { get; set; }
    }
}