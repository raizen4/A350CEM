﻿using Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public static class Constants
    {
        public static User LoggedUser=null;
        public static string WebApiEndpoint = "http://10.1.157.130:4000";
        public static string Token = "";
        public class Headers
        {
            /// <summary>
            /// The type of the content.
            /// </summary>
            public const string ContentType = "application/json";
        }

    }
}
