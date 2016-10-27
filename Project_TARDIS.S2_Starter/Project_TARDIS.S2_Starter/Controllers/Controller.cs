using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;

        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // instantiate a Salesperson object
            //
            _gameTraveler = new Traveler();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameUniverse = new Universe();
            _gameTraveler = new Traveler();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;
                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.LookAt:
                        _gameConsoleView.DisplayLookAt();
                        break;
                    case TravelerAction.PickUpItem:
                        int itemID;
                        itemID = _gameConsoleView.DisplayPickUpItem();

                        Item PickedUpItem = new Item();
                        PickedUpItem = _gameUniverse.GetItemtByID(itemID);

                        _gameTraveler.TravelersItems.Add(PickedUpItem);

                        PickedUpItem.SpaceTimeLocationID = 0;

                        break;
                    case TravelerAction.PickUpTreasure:
                        int treasureID;

                        treasureID = _gameConsoleView.DisplayPickUpTreasure();

                        Treasure PickedUpTreasure = new Treasure();
                        PickedUpTreasure = _gameUniverse.GetTreasuretByID(treasureID);

                        _gameTraveler.TravelersTreasures.Add(PickedUpTreasure);

                        PickedUpTreasure.SpaceTimeLocationID = 0;
                        //
                        // TODO write a DisplayPickUpTreasure method in the ConsoleView that lists game treasures in a location and prompts the traveler for an ID that is returned. Then adds the object to the player's treasure by adding them to the traveler's treasure list and setting the object's LocationID to the location of the traveler.
                        //
                        break;
                    case TravelerAction.PutDownItem:
                        int _itemID;

                        _itemID = _gameConsoleView.DisplayPutDownItem();

                        Item PutDownItem = new Item();
                        PutDownItem = _gameUniverse.GetItemtByID(_itemID);
                       
                        _gameTraveler.TravelersItems.Remove(PutDownItem);

                        PutDownItem.SpaceTimeLocationID = _gameTraveler.SpaceTimeLocationID;

                        //
                        // TODO write a DisplayPutDownItem method in the ConsoleView that lists the travelers game items and prompts the traveler for an ID that is returned. Then removes the object from the travel's items by removing it from the traveler's item list and setting the items's LocationID to the location of the traveler.
                        //
                        break;
                    case TravelerAction.PutDownTreasure:
                        int _treasureID;

                        _treasureID = _gameConsoleView.DisplayPutDownTreasure();

                        Treasure PutDownTreasure = new Treasure();
                        PutDownTreasure = _gameUniverse.GetTreasuretByID(_treasureID);

                        _gameTraveler.TravelersTreasures.Remove(PutDownTreasure);

                        PutDownTreasure.SpaceTimeLocationID = _gameTraveler.SpaceTimeLocationID;
                        //
                        // TODO write a DisplayPutDownTreasure method in the ConsoleView that lists the travelers game treasures and prompts the player for an ID that is returned. Then removes the object from the travel's treasure by removing it from the traveler's treasure list and setting the treasures's LocationID to the location of the traveler.
                        //
                        break;
                    case TravelerAction.Travel:
                        _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;
                        break;
                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerInventory:
                        _gameConsoleView.DisplayTravelerItems();
                        break;
                    case TravelerAction.TravelerTreasure:
                        _gameConsoleView.DisplayTravelerTreasure();
                        break;
                    case TravelerAction.ListTARDISDestinations:
                        _gameConsoleView.DisplayListAllTARDISDestinations();
                        break;
                    case TravelerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case TravelerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            _gameConsoleView.DisplayMissionSetupIntro();
            _gameTraveler.Name = _gameConsoleView.DisplayGetTravelersName();
            _gameTraveler.Race = _gameConsoleView.DisplayGetTravelersRace();
            _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;

            // 
            // add initial items to the traveler's inventory
            //
            AddItemToTravelersInventory(3);
            AddItemToTravelersTreasure(1);
        }

        /// <summary>
        /// add a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersInventory(int itemID)
        {
            Item item;

            item = _gameUniverse.GetItemtByID(itemID);
            item.SpaceTimeLocationID = 0;

            _gameTraveler.TravelersItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersTreasure(int itemID)
        {
            Treasure item;

            item = _gameUniverse.GetTreasuretByID(itemID);
            item.SpaceTimeLocationID = 0;

            _gameTraveler.TravelersTreasures.Add(item);
        }

        #endregion
    }
}
