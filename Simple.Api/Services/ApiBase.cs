using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Api.Services
{
    public static class ApiBase
    {
        internal const string Version = "v1.0";

        public const string Root = Version;

        public const string Users = Version + "/users";
    }
}
