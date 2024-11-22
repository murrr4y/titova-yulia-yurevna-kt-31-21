﻿using System.Text.RegularExpressions;

namespace titova_yulia_kt_31_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D*-\d*-\d{2}").Success;
        }
    }
}
