using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RaraGames
{
    public class GameLoop : MonoBehaviour {

        //
        // Game STATE
        // INITIALIZING: The state of the game when game is not started yet.
        // PLAYING: The state of the game when all actors are ready to act in the game
        // PAUSED: The state of the game when the game is paused.
        // GAME_OVER: The state of the game when the game is over.
       enum CURRENT_GAME_STATE
       {
            INITIALIZING,
            PLAYING,
            PAUSED,
            GAME_OVER
       }

       [SerializeField]
       public Button playerButton;

       private CURRENT_GAME_STATE currentGameState = CURRENT_GAME_STATE.INITIALIZING;
        // Managers
        public SpawnManager spawnManager;

        // Maintaining list of actors in the game
        private void Start() {
            // Changing game state after play
            playerButton.onClick.AddListener(() => {
                currentGameState = CURRENT_GAME_STATE.PLAYING;
                spawnManager.UpdateGameState(true);
            });
        }
    }
}
