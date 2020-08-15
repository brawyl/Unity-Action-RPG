using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();

        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);

            thePlayerStats.AddExperience(expToGive);
            theQM.enemyKilled = enemyQuestName;
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
