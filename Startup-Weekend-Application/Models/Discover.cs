using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Startup_Weekend_Application.Models.ManageViewModels;

public class Discover
    {
        public int Id { get; set; }
        public String Game { get; set; }
        public String Platform { get; set; }
        public String Playstyle { get; set; }
        public Genre Genre { get; set; }
    }

public enum Genre
{
    FPS=1,
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

