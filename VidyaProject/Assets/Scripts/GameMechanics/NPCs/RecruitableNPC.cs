using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitableNPC : Recruitable
{
    private Rigidbody2D myRigidbody;
    private Transform myTransform;
    private Animator anim;
    private bool isMoving;

    private Vector3 directionVector;
    public float speed;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;

    public Collider2D boundary;


    
    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update(); // Does the Update of the base class (Rectruitable) 
        if(isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
                //ChooseDifferentDirection();
            }
            if (!playerInRange)
            {
                Move();
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
                if (!playerInRange)
                {
                    ChooseDifferentDirection();
                }
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (boundary.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4); // Four possible directions
        switch(direction)
        {
            case 0:
                // UP
                directionVector = Vector3.up;
                break;
            case 1:
                // RIGHT
                directionVector = Vector3.right;
                break;
            case 2:
                // LEFT
                directionVector = Vector3.left;
                break;
            case 3:
                //DOWN
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)                                                    
    {
        ChooseDifferentDirection();
    }
}
