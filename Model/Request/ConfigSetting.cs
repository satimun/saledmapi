﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class ConfigSetting
    {
        public string DBMode { get; set; }
        public string ConnStr { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
