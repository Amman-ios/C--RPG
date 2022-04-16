using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace RPG
{
    public partial class RPG : Form
    {
        private Player _player;
        public RPG()
        {
            InitializeComponent();

            //Base Player Information
            _player = new Player(10,10,20,0,1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUST_SWORD), 1));

            lblHitPoints.Text = _player.CurrentHP.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.XP.ToString();
            lblLevel.Text = _player.LVL.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        //Player Movement
        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void MoveTo(Location newLocation)
        {
            //Check if the area needs an Item to enter
            if(newLocation.ItemReqToEnter !=null)
            {
                bool playerHasRequiredItem = false;
                //checks each inventory item
                foreach (InventoryItem ii in _player.Inventory)
                {
                    //compare the inventory items checked with the locations required item id
                    if (ii.Details.ID == newLocation.ItemReqToEnter.ID) 
                    {
                        playerHasRequiredItem = true;
                        break;
                    }
                }
                if (!playerHasRequiredItem)
                {
                    //Message for when the Required item isn't found in player's inventory
                    rtbMessages.Text += "You must have a " +
                        newLocation.ItemReqToEnter.Name +
                        " to enter this location." + Environment.NewLine;
                    return;
                }
            }
            _player.CurrentLocation = newLocation;
            //Show and hide avaible movement options
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnWest.Visible = (newLocation.LocationToWest != null);
            //Display location name and desc
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;
            //Full heals the player
            _player.CurrentHP = _player.MaxHP;
            //Updates HP in UI
            lblHitPoints.Text = _player.CurrentHP.ToString();
            
            //check for available quests in locaiton
            if(newLocation.QuestAvailableHere != null)
            {
                bool playerAlreadyHasQuest = false;
                bool playerAlreadyCompletedQuest = false;
               
                foreach(PlayerQuest playerQuest in _player.Quest)
                {
                    if(playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                    {
                        playerAlreadyHasQuest = true;
                        if (playerQuest.IsComplete)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }
                }
                //Check if they have the quest
                if (playerAlreadyHasQuest)
                {
                    //if not completed
                    if (!playerAlreadyCompletedQuest)
                    {
                        //do they have the req. items to complete it 
                        bool playerHasAllItemsToCompleteQuest = true;
                        foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool foundItemInPlayersInventory = false;
                            //check each inventory item for quest item an quantity
                            foreach(InventoryItem ii in _player.Inventory)
                            {
                                if(ii.Details.ID == qci.Details.ID)
                                {
                                    foundItemInPlayersInventory = true;
                                    //check if they have the correct quantity of the req. item
                                    if(ii.Quantity < qci.Quantity)
                                    {
                                        playerHasAllItemsToCompleteQuest = false;
                                        break;
                                    }
                                    break;
                                }
                            }
                            //player has all req. items to complete the quest
                            if (playerHasAllItemsToCompleteQuest)
                            {
                                rtbMessages.Text += Environment.NewLine;
                                rtbMessages.Text += "You complete the " +
                                    newLocation.QuestAvailableHere.Name + " quest." +
                                    Environment.NewLine;

                                //remove quest items on quest completion
                                foreach (QuestCompletionItem qci in
                                    newLocation.QuestAvailableHere.QuestCompletionItems)
                                {
                                    ii.Quantity -= qci.Quantity;
                                    break;
                                }
                                //Give quest rewards
                                rtbMessages.Text += "You receive: " + Environment.NewLine;
                                rtbMessages.Text += newLocation.QuestAvailableHere.RewardXP.ToString() + " experience points" + Environment.NewLine;
                                rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                                rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name.ToString() + Environment.NewLine;

                                _player.XP += newLocation.QuestAvailableHere.RewardXP;
                                _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                                //Add reward item to player inventory
                                bool addedItemToPlayerInventory = false;
                                foreach (InventoryItem ii in _player.Inventory)
                                {
                                    if (ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                                    {
                                        //they already the item, so increase the quantity by 1
                                        ii.Quantity++;
                                        addedItemToPlayerInventory = true;
                                        break;
                                    }
                                }
                                //they didn't have the item, so add it with a quantity of 1
                                if (!addedItemToPlayerInventory)
                                {
                                    _player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
                                }
                                //mark the quest as completed
                                foreach (PlayerQuest pq in _player.Quest)
                                {
                                    if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                                    {
                                        pq.IsComplete = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //The player doesn't have the quest

                    //Messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    //Add the quest to player's quest list
                    _player.Quest.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }
           //Does  the location have a monster
           if(newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "Youy see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                //Make a new monster from the world list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDMG,
                    standardMonster.RewardXP  , standardMonster.RewardGold, standardMonster.CurrentHP, standardMonster.MaxHP);

                foreach(LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUsePotion.Visible = true;
                btnUseWeapon.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
                btnUseWeapon.Visible = false;
            }

            //refresh inventory list
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";
            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
            //Refresh player quest list
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.Quest)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }

            // Refresh player's weapons combobox
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }

            // Refresh player's potions combobox
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }

        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }

        private void HitPointsMarker_Click(object sender, EventArgs e)
        {

        }
    }
}
