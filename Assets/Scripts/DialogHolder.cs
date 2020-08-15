using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    public string dialog;
    private DialogManager dMan;

    public string[] dialogLines;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogManager>();
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
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogLines;
                    dMan.currentLine = -1;
                    dMan.ShowDialog();
                }

                if (transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
