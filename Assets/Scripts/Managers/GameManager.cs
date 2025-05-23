using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System.Collections.Generic;

namespace RaveSurvival 
{
    public class GameManager : NetworkBehaviour 
    {
        // Singleton instance of the GameManager
        public static GameManager instance = null;

        // List of all players in the game
        public List<Player> players;

        /// <summary>
        /// Unity's Awake method, called when the script instance is being loaded.
        /// Ensures there is only one instance of the GameManager (singleton pattern).
        /// </summary>
        void Awake()
        {
            if (instance == null)
            {
                instance = this; // Assign this instance as the singleton
            }
            else
            {
                Destroy(this.gameObject); // Destroy duplicate instances
            }
        }

        /// <summary>
        /// Populates the list of players by finding all Player objects in the scene.
        /// </summary>
        public void SetPlayerList()
        {
            // Find all Player objects in the scene and add them to the players list
            players = new List<Player>(FindObjectsByType<Player>(FindObjectsSortMode.None));
        }

        /// <summary>
        /// Sets the local camera for each player.
        /// Enables the camera only for the local player.
        /// </summary>
        public void SetLocalCamera()
        {
            foreach (Player player in players)
            {
                // Enable the camera for the local player and disable it for others
                player.gameObject.transform.GetChild(1).GetComponent<Camera>().enabled = isLocalPlayer;
            }
        }
    }
}