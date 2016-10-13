using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the Ship class manages all of the game elements
    /// </summary>
    public class Ship
    {
        #region ***** define all lists to be maintained by the Ship object *****

        //
        // list of all decks
        //
        public List<Deck> Deck { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default Ship constructor
        //
        public Ship()
        {
            //
            // instantiate the lists of decks and game objects
            //
            this.Deck = new List<Deck>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();

            //
            // add all of the decks and game objects to their lists
            // 
            IntializeShipDeck();
            IntializeShipItems();
            IntializeShipTreasures();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a Deck object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextSpaceTimeLocationID()
        {
            int MaxID = 0;

            foreach (Deck STLocation in Deck)
            {
                if (STLocation.DeckID > MaxID)
                {
                    MaxID = STLocation.DeckID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a Deck object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public Deck GetSpaceTimeLocationByID(int ID)
        {
            Deck spt = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (Deck location in Deck)
            {
                if (location.DeckID == ID)
                {
                    spt = location;
                }
            }

            //
            // the specified ID was not found in the Ship
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the Ship
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasuretByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the Ship
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemtsBySpaceTimeLocationID(int ID)
        {
            // TODO validate DeckID

            List<Item> itemsInSpaceTimeLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.SpaceTimeLocationID == ID)
                {
                    itemsInSpaceTimeLocation.Add(item);
                }
            }

            return itemsInSpaceTimeLocation;
        }

        /// get a list of treasures using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuressBySpaceTimeLocationID(int ID)
        {
            // TODO validate DeckID

            List<Treasure> treasuresInSpaceTimeLocation = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.SpaceTimeLocationID == ID)
                {
                    treasuresInSpaceTimeLocation.Add(treasure);
                }
            }

            return treasuresInSpaceTimeLocation;
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the Ship with all of the decks
        /// </summary>
        private void IntializeShipDeck()
        {
            Deck.Add(new Deck
            {
                Name = "TARDIS Base",
                DeckID = 1,
                Description = "The Norlon Corporation's secret laboratory located deep underground, " +
                              " beneath a nondescript 7-11 on the south-side of Toledo, OH.",
                Accessable = true
            });

            Deck.Add(new Deck
            {
                Name = "Xantoria Market",
                DeckID = 2,
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                Accessable = true
            });

            Deck.Add(new Deck
            {
                Name = "Felandrian Plains",
                DeckID = 3,
                Description = "The Felandrian Plains are a common destination for tourist. " +
                  "Located just north of the equatorial line on the planet of Corlon, they" +
                  "provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessable = true
            });
        }

        /// <summary>
        /// initialize the Ship with all of the items
        /// </summary>
        private void IntializeShipItems()
        {
            Items.Add(new Item
            {
                Name = "Key",
                GameObjectID = 1,
                Description = "A gold encrusted chest with strange markings lay next to a strange blue rock.",
                SpaceTimeLocationID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Tricorder",
                GameObjectID = 2,
                Description = "A diagnostic tool carried by all Starfleet personnel.",
                SpaceTimeLocationID = 2,
                HasValue = true,
                Value = 1000,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Gold Dot",
                GameObjectID = 3,
                Description = "An insignia representing your rank in Starfleet.",
                SpaceTimeLocationID = 0,
                HasValue = true,
                Value = 500,
                CanAddToInventory = true
            });
        }

        /// <summary>
        /// initialize the Ship with all of the treasures
        /// </summary>
        private void IntializeShipTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Trantorian Ruby",
                TreasureType = Treasure.Type.Ruby,
                GameObjectID = 1,
                Description = "A deep red ruby the size of an egg.",
                SpaceTimeLocationID = 2,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Lodestone",
                TreasureType = Treasure.Type.Lodestone,
                GameObjectID = 2,
                Description = "A deep red ruby the size of an egg.",
                SpaceTimeLocationID = 3,
                HasValue = true,
                Value = 15,
                CanAddToInventory = true
            });
        }

        #endregion

    }
}

