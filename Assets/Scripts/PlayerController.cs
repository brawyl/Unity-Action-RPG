using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;

    private SFXManager sfxMan;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;
        lastMove = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            moveInput = new Vector2(moveX, moveY).normalized;

            if (moveInput != Vector2.zero)
            {
                myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
            }
            else
            {
                myRigidBody.velocity = Vector2.zero;
            }

            if (moveX > 0.5f || moveX < -0.5f)
            {
                lastMove = new Vector2(moveX, 0f);
            }
            else if (moveY > 0.5f || moveY < -0.5f)
            {
                lastMove = new Vector2(0f, moveY);
            }

            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidBody.velocity = Vector2.zero;
                sfxMan.playerAttack.Play();
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        anim.SetBool("Attack", attacking);
    }
}
