﻿using System.Net;
using My_OPR.Models.Master;
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
        public string? Service { get; set; }
        public ICollection<String>? AccountRole { get; set; }
        public string? Kelompok { get; set; }
        public string? Jabatan { get; set; }
    }
}