using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;
    private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();

        playerSprite = GetComponent<SpriteRenderer>();
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            sfxMan.playerDead.Play();
            gameObject.SetActive(false);
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * 0.67f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.1f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
        sfxMan.playerHurt.Play();
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
