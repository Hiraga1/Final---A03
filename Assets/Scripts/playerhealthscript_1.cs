using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    //Variables
    public int playerWetLevel;
    public int playerMaxWetLevel = 100;
    
    public int enemiesSoaked;
    public List<GameObject> enemies;
    public int totalEnemies;
    //References
    public WetBarScript wetBar;
    
    public GameObject questTrigger6;
    public GameObject questWindow;
    public GameObject WetBarUI;
    public Throwing throwing;

    public bool unforgettableMemory;
    public bool apexStudent;

    // Start is called before the first frame update
    void Start()
    {
        playerWetLevel = 0;
        wetBar.SetWetValue(playerWetLevel);
        
        WetBarUI.SetActive(true);
        
    }

    // Update is called once per frame
    public void TakeDamage(int wetlevel)
    {
        playerWetLevel += wetlevel;

        wetBar.SetWetValue(playerWetLevel);
    }
    void Update()
    {
        if (playerWetLevel == playerMaxWetLevel && !unforgettableMemory)
        {
            Debug.Log("Game Over");
            unforgettableMemory = true;
        }

        

        if (enemiesSoaked == enemies.Count)
        {
            apexStudent = true;
        }
    }
    
}
