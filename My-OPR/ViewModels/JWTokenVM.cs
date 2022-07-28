using My_OPR.Models.Master;
using System.Net;
namespace My_OPR.ViewModels
{
    public class JWTokenVM
    {
        public HttpStatusCode? status { get; set; }
        public string? idToken { get; set; }
        public string? message { get; set; }
        public UserInfo? UserInfo { get; set; }
    }

    public class UserInfo
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NPP { get; set; }
        public ICollection<String>? AccountRole { get; set; }
        public Employee? Employee { get; set; }

    }
}
