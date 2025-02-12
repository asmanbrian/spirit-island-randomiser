using System;
using System.Text.Json.Serialization;

namespace SiRandomizer.Data
{
    public class Expansion : SelectableComponentBase<Expansion>, INamedComponent
    {
        public const string BranchAndClaw = "Branch and Claw";
        public const string JaggedEarth = "Jagged Earth";
        public const string Promo1 = "Promo Pack 1";
        public const string Promo2 = "Promo Pack 2";
        public const string Apocrypha = "Apocrypha";
        public const string Horizons = "Horizons of Spirit Island";  
        //public const string NatureIncarnate = "Nature Incarnate";  
        public const string Homebrew = "Homebrew";  

              
        
        [JsonIgnore]
        public string Tag { get; private set; }

        public Expansion() {}

        public Expansion(
            string name,  
            OverallConfiguration config,
            string tag) 
            : base(name, config) 
        {
            Tag = tag;
        }

        public override bool IsVisible()
        {
            return true;
        }
    }
}
