using System;
using System.Collections.Generic;

namespace MeetupsApi.Data
{
    public partial class Meetups
    {
        public int Id { get; set; }
        public int UserOrganizer { get; set; }
        public string Title { get; set; }
        public int? Canceled { get; set; }
    }
}
