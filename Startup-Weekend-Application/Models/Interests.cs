using System;
namespace Startup_Weekend_Application.Models
{
	public class Interests
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string GameTitle { get; set; }
        public string Platform { get; set; }
        public bool IsActive { get; set; }
    }
}
