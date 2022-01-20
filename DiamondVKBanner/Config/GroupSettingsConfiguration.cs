using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DiamondVKBanner.Config
{
    [DebuggerDisplay("Configuration Data")]
    public sealed class GroupSettingsConfiguration
    {
        /// <summary>
        /// Group token
        /// </summary>
        [JsonProperty("token", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string GroupToken { get; set; }

        /// <summary>
        /// Group ID
        /// </summary>
        [JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Populate)]
        public ulong GroupID { get; set; }
    }
}
