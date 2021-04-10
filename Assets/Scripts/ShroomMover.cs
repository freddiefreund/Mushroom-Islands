using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShroomMover : MonoBehaviour
{
    [SerializeField] private float goalXPos;
    private Rigidbody2D rb;
    private float currentXPos;
    private float moveAmountPerSecond;
    private bool arrived = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GenerateGoalXPos();
        StartMoving();
    }

    private void StartMoving()
    {
        currentXPos = transform.position.x;
        if (currentXPos > goalXPos)
        {
            // Move left
            moveAmountPerSecond = -0.5f;
        }
        else
        {
            // Move right
            moveAmountPerSecond = 0.5f;
        }
        StartCoroutine(Move());
    }

    void GenerateGoalXPos()
    {
        while (true)
        {
            goalXPos = Random.Range(-8f,8f);
            float distanceToGoal = Mathf.Abs(transform.position.x - goalXPos);
            if (distanceToGoal > 5)
            {
                break;
            }
        }
    }
    
    void Update()
    {
        currentXPos = transform.position.x;
        float distanceToGoal = Mathf.Abs(currentXPos - goalXPos);
        if (distanceToGoal < 0.5f)
        {
            ArriveAtDestination();
        }
    }

    IEnumerator Move()
    {
        float moveAmountX = moveAmountPerSecond / 20f;
        float startYPos;
        float maxMoveAmountY = 0.4f;
        float moveAmountY;
        Vector3 moveVector = new Vector3(moveAmountX, 0, 0);
        while (!arrived)
        {
            moveAmountY = maxMoveAmountY;
            startYPos = transform.position.y;
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("moveAmountY = " + moveAmountY);
                moveAmountY -= maxMoveAmountY / 10;
                transform.position += moveVector;
                transform.position += new Vector3(0, moveAmountY, 0);
                yield return new WaitForSeconds(0.05f);
            }
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("moveAmountY = " + moveAmountY);
                moveAmountY += maxMoveAmountY / 10;
                if (Mathf.Abs(startYPos - transform.position.y) > 0 + Mathf.Epsilon)
                {
                    transform.position -= new Vector3(0, moveAmountY, 0);
                }
                transform.position += moveVector;
                
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ArriveAtDestination()
    {
        if (!arrived)
        {
            Debug.Log("I arrived!");
            arrived = true;
        }
    }
}
