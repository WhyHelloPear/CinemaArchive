using Microsoft.AspNetCore.Mvc;

namespace TBD.Models
{
    public class UserData
    {
        public UserData(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
