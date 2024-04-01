﻿using System;

namespace Spartacus.Domain.Entities.User
{
    public class ULoginData
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
