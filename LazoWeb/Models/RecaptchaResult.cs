using System.Runtime.Serialization;

namespace LazoWeb.Models
{
    [DataContract]
    public class RecaptchaResult
    {
        [DataMember(Name ="success")]
        public bool Success { get; set; }
        [DataMember(Name = "error-codes")]
        public string[] ErrorCodes { get; set; }
    }
}