﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class VMDto
    {
        public int VMID { get; set; }
        public int CPUCores { get; set; }
        public int Storage { get; set; }
        public int RAM { get; set; }
        public string? IP { get; set; }
        public int Bandwidth { get; set; }
        public int ClientID { get; set; }
        public int NodeID { get; set; }
        public int LunID { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
}
