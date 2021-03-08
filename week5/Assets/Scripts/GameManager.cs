using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton
    public Text pupText;
    public Text scoreText;
    public Text timerText;

    public GameObject gameOverPanel;

    public float timeElapsed = 0;
    
    int currentLevel = 0;
    
    private int _score = 0;

    public int Score
    {
        get
        {
            return _score;
        } 
        set
        {
            _score = value;
        }
    }

    private int _pupCount = 3;

    public int PupCount
    {
        get
        {
            return _pupCount;
        }

        set
        {
            _pupCount = value;
        }
    }

    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        scoreText.text = "Score: " + _score;
        pupText.text = "Pups: " + _pupCount;
        timerText.text = (30 - (int)timeElapsed).ToString();

        if (timeElapsed >= 30)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
