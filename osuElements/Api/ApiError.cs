using System;
using System.Runtime.Serialization;

namespace osuElements.Api
{
    /// <summary>
    /// Error returned by the API
    /// </summary>
    [DataContract]
    public class ApiError
    {
        /// <summary>
        /// The error message
        /// </summary>
        [DataMember(Name = "error", Order = 0)]
        public string Error { get; set; }

        public override string ToString()
        {
            return Error;
        }

    }
}