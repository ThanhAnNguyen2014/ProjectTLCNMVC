﻿using System;
using System.Collections.Generic;

namespace ProjectTLCNMVC.Entities
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateAttendance { get; set; }

        public virtual Users User { get; set; }
    }
}
