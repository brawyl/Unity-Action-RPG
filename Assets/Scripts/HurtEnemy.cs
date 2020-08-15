using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    private PlayerStats thePS;

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
