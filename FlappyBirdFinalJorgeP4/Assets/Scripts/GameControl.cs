using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text scoreText;
    public GameObject gameOvertext;

    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;


    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it 
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destory this one because it is a duplicate.
            Destroy(gameObject);
    }
    void Update()
    {
        //if the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        //The bird cant score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text 
        scoreText.text = "Score:" + score.ToString();
    }

    public void BirdDied()
    {
        //Activate the game over text.
        gameOvertext.SetActive(true);
        //Set the game to be over 
        gameOver = true;
    }
}




  
        
    



