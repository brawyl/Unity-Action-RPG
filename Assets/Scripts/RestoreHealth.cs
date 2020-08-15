using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{

    public string[] dialogLines;

    private PlayerHealthManager hManager;
    private DialogManager dManager;

    // Start is called before the first frame update
    void Start()
    {
        hManager = FindObjectOfType<PlayerHealthManager>();
        dManager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!dManager.dialogActive)
                {
                    dManager.dialogLines = dialogLines;
                    dManager.currentLine = -1;
                    dManager.ShowDialog();
                }

                hManager.playerCurrentHealth = hManager.playerMaxHealth;
            }
        }
    }

}
