using System;
using System.Collections.Generic;
using System.Text;
using Console_RPG.Items;

namespace Console_RPG
{
    class Location
    {
        public static Location snoIsle = new Location("Sno Isle", "Location of the Scary Teacher. You get the strange feeling that your goal is to defeat God.", false);
        public static Location mushroomKingdom = new Location("Mushroom Kingdom", "Home of Plumbers, Princesses, and gets invaded by a giant turtle every few years.", false, new Battle(new List<Enemy>() { Enemy.mario, Enemy.luigi }));
        public static Location skeld = new Location("The Skeld", "A spaceship flying throughout the cosmos. But something seems... sus.", false, new Battle(new List<Enemy>() { Enemy.imposter }));
        public static Location netherFortress = new Location("Nether Fortress", "Wow, you got lucky! These things usually take way longer to find.", false, new Battle(new List<Enemy>() { Enemy.blaze, Enemy.wSkeleton }));
        public static Location waterLevel = new Location("Obligitory Water Level", "Look. I get it. These levels are the worst. However I'm contractually obligated to add one. To make it up to you I won't give you any enemies", false);
        public static Location saulGoodman = new Location("Saul Goodmans Office", "Hi, I'm saul Goodman. Did you know that you have rights? Constitution says you do, and so do I. I believe that until proven guilty, every man women and child is innocent. And that's why I fight for you!", false, new Battle(new List<Enemy>() { Enemy.sGoodman }));
        public static Location hyrule = new Location("Hyrule", "The kingdom holding princess Zelda who... Wait is Nintendo going to whine about copyright. Oh no.", false, new Battle(new List<Enemy>() { Enemy.nGuard, Enemy.nLawyer }));
        public static Location facebookHQ = new Location("Facebook HQ", "Or is it called Meta? I'm calling it Facebook because I don't care what the Lizard says. ", false, new Battle(new List<Enemy>() { Enemy.bbqSauce }));
        public static Location damonsHouse = new Location("Damon's House", "Don't worry about Thomas who is in his walls.", false);
        public static Location damonsBasement = new Location("Damon's Basement", "A place of unimagainable horrors. The backrooms are just a small snipit into what this nightmare has to offer. Has weak enemies tho.", false, new Battle(new List<Enemy>() { Enemy.weakling }));
        public static Location animeHQ = new Location("Anime HQ", "To the dismay of weebs everywhere, there are no anime girls at Anime HQ.", false, new Battle(new List<Enemy>() { Enemy.weakling, Enemy.weakling, Enemy.weakling, Enemy.weakling }));
        public static Location kalebsHouse = new Location("Kaleb's House", "Wow! Kalebs room is so clean. You should give that kid extra credit points because its so clean.", false, new Battle(new List<Enemy>() { Enemy.bribe, Enemy.kaleb }));
        public static Location iceLevel = new Location("Obligitory Ice Level", "Don't worry. The ice isn't slippery so it should be fine.", false, new Battle(new List<Enemy>() { Enemy.oIceEnemy, Enemy.oOIceEnemy }));
        public static Location desert = new Location("Sahara Desert", "Yes the Sahara Desert is right next to the obligitory ice level. Don't worry about these Minecraft physics.", false);
        public static Location northKorea = new Location("North Korea", "The most authoritarian regime in the history of the planet. But it's not France so this should be doable.", false, new Battle(new List<Enemy>() { Enemy.kJU }));
        public static Location mountDoom = new Location("Mount Doom", "Unfortunatly you don't have a ring to discard. Even worse, the enemy in the mountain can't be killed normally. I wonder how you would beat an enemy made of fire.", false, new Battle(new List<Enemy>() { Enemy.fireBall }));
        public static Location secretTunnel = new Location("Secret Tunnel", "Congratulations! You found the secret tunnel. *Insert the Avatar song here*", true);
        public static Location secretTreasure = new Location("Secret Treasure", "And you have found the Secret Treasure! I hope this isn't outrageously overpowered and breaks the game.", false, new Treasure(DamageItem.instaKill));
        public static Location shopKH = new Location("Shop", "Do you like hoarding gold? If yes, then why didn't you go to the ice level.", false, new Shop("Bill Gates", new List<Item>() { HealthItem.potion1, HealthItem.potion2 })); //put items in {   }
        public static Location shopOWL = new Location("Shop", "Alright there are no more contractual obligations to fulfill, except for the ice level but that was the other way.", false, new Shop("Saul Goodman", new List<Item>() { HealthItem.potion2, DefenseItem.defensePot1, StrengthItem.strengthPot1}));
        public static Location shopMD = new Location("Shop", "Well I hope that defeating those enemies in Mount Doom was worth it... by the way try going North from the Skeld.", false, new Shop("Sauron", new List<Item>() { HealthItem.potion2, DefenseItem.defensePot1, StrengthItem.strengthPot1 }));
        public static Location shopNK = new Location("Shop", "You can go the other way if you want, but remember that killing God is the main goal.", false, new Shop("Kim Jong Un", new List<Item>() { HealthItem.potion3, DefenseItem.defensePot2, StrengthItem.strengthPot2 }));
        public static Location godsHouse = new Location("God's House", "Who would've thought God had a house. It's not very big but it still feels holy.", false, new Battle(new List<Enemy>() { Enemy.god }));

        public string name;
        public string description;
        public bool noDisplay;
        public Feature feature;

        public Location north, east, south, west;
        public Location(string name, string description, bool noDisplay, Feature feature = null)
        {
            this.name = name;
            this.description = description;
            this.feature = feature;
            this.noDisplay = noDisplay;
        }
        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }

            if (!(east is null))
            {
                this.east = east;
                east.west = this;               
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }
        public void Resolve(List<Player> players)
        {
            Console.WriteLine("You are now located in " + this.name);
            Console.WriteLine(this.description);

            feature?.Resolve(players);

            if (!(this.north is null) && this.north.noDisplay == false)
                Console.WriteLine("North: " + this.north.name);

            if (!(this.east is null) && this.east.noDisplay == false)
                Console.WriteLine("East: " + this.east.name);

            if (!(this.south is null) && this.south.noDisplay == false)
                Console.WriteLine("South: " + this.south.name);

            if (!(this.west is null) && this.west.noDisplay == false)
                Console.WriteLine("West: " + this.west.name);

            Location nextLocation = null;
            while (nextLocation == null)
            {
                string direction = Console.ReadLine().ToLower();

                if (direction == "north")
                    nextLocation = this.north;
                else if (direction == "east")
                    nextLocation = this.east;
                else if (direction == "south")
                    nextLocation = this.south;
                else if (direction == "west")
                    nextLocation = this.west;
                else
                    continue;
            }
            nextLocation.Resolve(players);
        }
    }
}
