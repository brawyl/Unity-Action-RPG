using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePS;
    public Text levelText;
    public Text displayText;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
        displayText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + healthBar.value + "/" + healthBar.maxValue;
        levelText.text = "Lvl: " + thePS.currentLevel;

        if (playerHealth.playerCurrentHealth <= 0)
        {
            displayText.text = "YOU DIED\n\nPress space to restart.";

            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerHealth.gameObject.SetActive(true);
                playerHealth.playerCurrentHealth = playerHealth.playerMaxHealth / 2;
                displayText.text = "";
                SceneManager.LoadScene(0);
            }
        }
    }
}
