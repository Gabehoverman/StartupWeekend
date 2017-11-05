using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Startup_Weekend_Application.Models.ManageViewModels;

namespace Startup_Weekend_Application.Models
{


    public class Discover
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Game { get; set; }
        public string Platform { get; set; }
        public Playstyle Playstyle { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        FPS = 1,
        Fighting,
        Survival,
        Fantasy,
        RPG,
        MMORPG,
        Sandbox,
        Moba,
        Strategy,
        Racing,
        Stealth,
        Simulation,
        Sports,
        TableTop,
        Card,
        Other

    }

    public enum Playstyle
    {
        Casual = 1,
        Competative
    }

}

