using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int UNSELLABLE_ITEM_PRICE = -1;

        //ITEMS
        public const int ITEM_ID_RUST_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_SWORD = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        //MONSTERS
        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        //QUESTS
        public const int QUEST_ID_CLEAR_FOREST = 1;
        //LOCATIONS
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_STORE = 3;
        public const int LOCATION_ID_BRIDGE = 4;
        public const int LOCATION_ID_FOREST = 5;
        public const int LOCATION_ID_TAVERN = 6;
        public const int LOCATION_ID_DEEP_FOREST = 7;



        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }
        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUST_SWORD, "Rusty sword", "Rusty swords", 0, 5, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat tail", "Rat tails", 1));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur", 1));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs", 1));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins", 2));
            Items.Add(new Weapon(ITEM_ID_SWORD, "Swrod", "Swords", 3, 10, 15));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing potion", "Healing potions", 5, 3));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs", 1));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks", 1));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer pass", "Adventurer passes", UNSELLABLE_ITEM_PRICE));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Giant Rat", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Venomous Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Massive Spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearForest =
                new Quest(QUEST_ID_CLEAR_FOREST, "Clear the forest of beasts",
                "Kill a giant spider, collect their fangs as proof.", 20, 10);

            clearForest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 4));

            clearForest.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quests.Add(clearForest);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge over a large stream", "A large stone bridge acting as the main entrance into the village.");

            Location store = new Location(LOCATION_ID_STORE, "General Store", "The villlage's lone store, suprisingly abundant with products despite the small size and remote location of the village.");

            Vendor genStoreOwner = new Vendor("General Store Owner");
            genStoreOwner.AddItemToInventory(ItemByID(ITEM_ID_HEALING_POTION), 10);
            genStoreOwner.AddItemToInventory(ItemByID(ITEM_ID_SWORD), 2);

            Vendor bobTheRatCatcher = new Vendor("Bob the Rat-Catcher");
            bobTheRatCatcher.AddItemToInventory(ItemByID(ITEM_ID_PIECE_OF_FUR), 5);
            bobTheRatCatcher.AddItemToInventory(ItemByID(ITEM_ID_RAT_TAIL), 3);

            townSquare.VendorWorkingHere = bobTheRatCatcher;

            Location Tavern = new Location(LOCATION_ID_TAVERN, "Village Tavern", "There are a number of patrons drinking and making merry to bards play. A few other adventurer's are checking to quest board.");
            Tavern.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FOREST);

            Location Forest = new Location(LOCATION_ID_FOREST, "Forest", "A beautiful verdant forest lush with vegitation, you can see the village just across the stream.");
            Forest.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location DeepForest = new Location(LOCATION_ID_DEEP_FOREST, "Deep Forest", "Light barely pierces through the thick canapy off the roads leading through this part of the forest.");
            DeepForest.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);




            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = bridge;
            townSquare.LocationToEast = Tavern;
            townSquare.LocationToWest = store;

            bridge.LocationToNorth = Forest;
            bridge.LocationToSouth = townSquare;

            Tavern.LocationToWest = townSquare;

            Forest.LocationToNorth = DeepForest;
            Forest.LocationToSouth = bridge;

            DeepForest.LocationToSouth = Forest;

            store.LocationToEast = townSquare;
            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(Tavern);
            Locations.Add(Forest);
            Locations.Add(DeepForest);
            Locations.Add(bridge);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}