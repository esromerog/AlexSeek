using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    public bool blasInteraction;
    public bool randyInteraction;
    public bool levanaInteraction;

    public bool hasLoadedTwice;
    
    private void Awake(){

        player = GameObject.Find("hero").GetComponent<Player>();
        DontDestroyOnLoad(gameObject);

        if (instance == null) {

            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);   
        }

        //Sets this to not be destroyed when reloading scene
    }

}
