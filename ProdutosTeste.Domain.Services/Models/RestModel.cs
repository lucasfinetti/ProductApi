using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosTeste.Domain.Services.Models
{
    public class RestModel
    {
        public string URL { get; set; }
        public dynamic Body { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
