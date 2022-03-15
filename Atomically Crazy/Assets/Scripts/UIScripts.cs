using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIScripts : MonoBehaviour
{
    public GameObject myEventSystem;

    //UI Screens Variables
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public GameObject hudScreen;

    //Pause Function Variables
    public GameObject playerObject;
    public GameObject pauseFirstSelect;
    public bool canPause;
    public bool isPaused;

    //Health Variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    //Plasma Variables
    public bool drain = false;
    public int duration = 0;
    public int maxPlasma = 100;
    public int currentPlasma;
    public float plasmaDrainAmount = 2f;
    public HealthBar plasmaBar;


    //Score Variables
    public static int scoreValue = 0;
    public static int highScoreValue = 20;
    public TMP_Text score;
    public TMP_Text deathHighscore;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        canPause = true;

        //health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //plasma
        currentPlasma = 0;
        plasmaBar.SetMaxPlasma(maxPlasma, currentPlasma);
    }

    // Update is called once per frame
    void Update()
    {
        //Pause and death
        if (Input.GetKeyDown("escape"))
        {
            if (canPause == true)
            {
                switch (isPaused)
                {
                    case true:
                        //ResumeGame(); Debug.Log("Game should be resumed");
                        break;
                    case false:
                        PauseGame(); 
                        break;
                }
            }
        }
        else if (currentHealth <= 0)
        {
            DeathMenuActivate();
        }

        ///HUD///


        //sets the score text to the score value
        score.text = "" + scoreValue;

        if (currentPlasma == maxPlasma)
        {
            duration = 100;
            drain = true;
        }

        if (duration > 0 && drain == true)
        {
            duration -= 1;
            currentPlasma = duration;
            plasmaBar.SetPlasma(currentPlasma);
        }
        else if (duration <= 0 && drain == true)
        {
            drain = false;
            currentPlasma = 0;
            plasmaBar.SetPlasma(currentPlasma);
        }

    }


    ////////////////////////// HUD Functions ///////////////////////////////

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

    }

    public void GainPlasma(int plasma)
    {
        currentPlasma += plasma;

        plasmaBar.SetPlasma(currentPlasma);
    }

    public void IncreaseScore()
    {
        scoreValue += 1;
    }


    ////////////////////////////// UI Functions ///////////////////////////////

    public void PauseGame()
    {
        //Freezes time and activates pause menu
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        hudScreen.SetActive(false);
        Cursor.visible = true;

        //Disables player input until game is resumed - CHANGE PLAYERDELETEAFTER TO PLAYER
        playerObject.GetComponent<Player>().enabled = false;

    }

    public void ResumeGame()
    {
        //unFreezes time and deActivates the pause menu
        pauseScreen.SetActive(false);
        hudScreen.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
        canPause = true;
        Cursor.visible = false;

        //reEnables player input - CHANGE PLAYERDELETEAFTER TO PLAYER
        playerObject.GetComponent<Player>().enabled = true;
    }


    public void DeathMenuActivate() //This should activate when the player dies
    {
        Cursor.visible = true;
        //Freezes time and activates pause menu
        deathScreen.SetActive(true);
        Time.timeScale = 0;
        canPause = false;
        hudScreen.SetActive(false);

        //changing high score
        switch (scoreValue >= highScoreValue)
        {
            case true:
                highScoreValue = scoreValue;
                deathHighscore.text = "Top High Score: " + highScoreValue;
                break;
            case false:
                deathHighscore.text = "Top High Score: " + highScoreValue;
                break;
        }


        //Disables player input until game is resumed - CHANGE PLAYERDELETEAFTER TO PLAYER
        playerObject.GetComponent<Player>().enabled = false;
    }


    ////////////////////////////// Buttons ///////////////////////////////////

    //Use this in "On Click" to load a level - THE LEVEL HAS TO BE IN SCENE MANAGER
    public void ButtonLoad(string worldName)
    {
        SceneManager.LoadScene(worldName);
        Cursor.visible = true;

    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
