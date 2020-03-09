using System;
using System.Collections.Generic;

namespace MeetupsApi.Data
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int Admin { get; set; }
    }
}
