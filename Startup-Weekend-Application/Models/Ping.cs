using System;
namespace Startup_Weekend_Application.Models
{
	public class Ping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public DateTime Time { get; set; }
    }
}
