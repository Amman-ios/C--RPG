using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int XP { get; set; }
        public int LVL
        {
            get { return ((XP / 100) + 1); }
        }
        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quest { get; set; }

        public Player(int currentHP, int maxHP, int gold, int xp) : base(currentHP, maxHP)
        {
            Gold = gold;
            XP = xp;
            Inventory = new List<InventoryItem>();
            Quest = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemReqToEnter == null)
            {
                //There is no required item, so return true
                return true;
            }
            //check if required item is in player inventory
            return Inventory.Exists(ii => ii.Details.ID == location.ItemReqToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quest)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quest)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsComplete;
                }
            }
            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            //See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                //check each inventory item to see if they have the correct quantity
                if(!Inventory.Exists(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                {
                    return false;
                }
            }
            //If we got here, then the player must have all the required items to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if(item != null)
                {
                    //subtracts the required quantity of the quest item from the inventory
                    item.Quantity -= qci.Quantity;
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            if(item == null)
            {
                //they don't have the item so add it at a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                //they had the item so increase the quantity by 1
                item.Quantity++;
            }
        }

        public void MarkQuestCompleted(Quest quest)
        {
            //find the quest in player quest list
            PlayerQuest playerQuest = Quest.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if(playerQuest != null)
            {
                playerQuest.IsComplete = true;
            }
        }
        public string ToXmlString()
        {
            XmlDocument playerData = new XmlDocument();

            // Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            // Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            // Create the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(this.CurrentHP.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(this.MaxHP.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(this.XP.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            // Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (InventoryItem item in this.Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);

                inventoryItems.AppendChild(inventoryItem);
            }

            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (PlayerQuest quest in this.Quest)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsComplete.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);

                playerQuests.AppendChild(playerQuest);
            }

            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}