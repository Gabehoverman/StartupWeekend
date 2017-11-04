using System;
namespace Startup_Weekend_Application.Models
{
	public class Ping
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Game { get; set; }
        public string Platform { get; set; }
        public string PlayStyle { get; set; }
        public string SkillLevel { get; set; }
        public DateTime Time { get; set; }
    }
}
