using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenSceneLogicManager : MonoBehaviour
{
    private LevelManager levelManager;
    private ResetStove resetStove;
    private LevelTextManager levelTextManager;
    private KitchenEmergencies kitchenEmergencies;  
    private bool gameOver = false;
    private float gameOverTimer = 0f;
    private float gameOverDelay = 3f; // 2 second delay before changing scene


    // Start is called before the first frame update
    void Start()
    {
        // Assuming you have references to other managers/components
        levelManager = GetComponent<LevelManager>();
        resetStove = GetComponent<ResetStove>();
        levelTextManager = GetComponent<LevelTextManager>();
        kitchenEmergencies = GetComponent<KitchenEmergencies>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        CheckLevelComplete();
    }

    private void CheckGameOver()
    {
        // Check if the game is over
        if (!gameOver && GlobalState.IsGameOver())
        {
            // levelObjectManager.ResetLevel();
            levelManager.ResetLevel();
            resetStove.ResetStoveObjects();
            KitchenSceneState.ResetLevel3();
            KitchenSceneState.ResetLevel4();
            gameOver = true; // Set game over flag
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            gameOverTimer = 0f; // Reset timer
        }

        // If game over flag is set, wait for the delay before changing scene
        if (gameOver)
        {
            gameOverTimer += Time.deltaTime;
            if (gameOverTimer >= gameOverDelay)
            {
                gameOver = false; // Reset game over flag
                // Load game over scene after the delay
                SceneManager.LoadScene("DeathIsOnlyTheBeginning");
            }
        }
    }

    private void CheckLevelComplete()
    {
        // Check if the level is complete
        if (GlobalState.GetLevel() == 3 &&  KitchenSceneState.Level3Complete())
        {
            Debug.Log("level 3 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            kitchenEmergencies.ExtinguishOilFire();
        }
        if (GlobalState.GetLevel() == 4 && KitchenSceneState.Level4Complete()) 
        {
            Debug.Log("level 4 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            kitchenEmergencies.ExtinguishOvenFire();
        }
    }
}
