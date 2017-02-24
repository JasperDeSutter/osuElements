using System;
using System.Runtime.Serialization;

namespace osuElements.Api
{
    /// <summary>
    /// The replay-data returned by the API
    /// </summary>
    [DataContract]
    public class ApiReplay
    {
        /// <summary>
        /// The encoded string of the replay data
        /// </summary>
        [DataMember(Name = "content", Order = 0)]
        public string Content { get; set; }

        /// <summary>
        /// The encoding type of the replay data
        /// </summary>
        [DataMember(Name = "encoding", Order = 1)]
        public string Encoding { get; set; }

    }
}