﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Test.Model
{
    public partial class SessionSlot
    {
        public SessionSlot()
        {
            SessionSlotDatas = new HashSet<SessionSlotData>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Guid { get; set; }
        public DateTime LoginAtUtc { get; set; }
        public DateTime LastActiveAtUtc { get; set; }
        public string ApplicationName { get; set; }
        public DateTime LastBrowserActiveAtUtc { get; set; }

        public virtual ICollection<SessionSlotData> SessionSlotDatas { get; set; }
    }
}