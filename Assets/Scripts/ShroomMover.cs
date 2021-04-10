using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShroomMover : MonoBehaviour
{
    [SerializeField] private float goalXPos;
    [SerializeField] private float jumpTime;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float currentXPos;
    private float moveAmountPerSecond;
    private bool arrived = false;
    public MushroomKiller killer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Color color= spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
        StartCoroutine(FadeIn());
        StartMoving();
        killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<MushroomKiller>();
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

    void Update()
    {
        currentXPos = transform.position.x;
        float distanceToGoal = Mathf.Abs(currentXPos - goalXPos);
        if (distanceToGoal < 0.5f)
        {
            ArriveAtDestination();
        }
    }

    private float currentTime;
    IEnumerator Move()
    {
        SetJumpTimer();
        float moveAmountX = moveAmountPerSecond / 20f;
        float maxMoveAmountY = 0.4f;
        Vector3 moveVector = new Vector3(moveAmountX, 0, 0);
        while (!arrived && IsGrounded())
        {
            if (Time.time >= currentTime)
            {
                currentTime += jumpTime;
                rb.velocity = new Vector3(0, 5, 0);
                for (int i = 0; i < 10; i++)
                {
                    transform.position += moveVector;
                    yield return new WaitForSeconds(0.04f);
                }
                for (int i = 0; i < 10; i++)
                {
                    transform.position += moveVector;
                    yield return new WaitForSeconds(0.035f);
                }
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
    
    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 pos1;
        Vector2 pos2;
        if (moveAmountPerSecond > 0)
        {
            // Shroom is moving right
            pos1 = position; 
            pos1.x -= 0.5f;
        }
        else
        {
            // Shroom is moving left
            pos2 = position;
            pos2.x += 0.5f;
        }
        Vector2 direction = Vector2.down;
        float distance = 3.0f;
    
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }

    IEnumerator FadeIn()
    {
        Color color = spriteRenderer.color;
        for (int i = 0; i < 10; i++)
        {
            color.a += 0.1f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        for (int i = 0; i < 10; i++)
        {
            color.a -= 0.1f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        MushroomSpawner.RemoveShroom();
        Destroy(gameObject);
    }

    private void SetJumpTimer()
    {
        float unrounded = Time.time / jumpTime;
        float rounded = Mathf.Round(unrounded);
        if (rounded < unrounded)
            rounded += 1;
        currentTime = jumpTime * rounded;
    }

    public void Die()
    {
        StartCoroutine(FadeOut());
    }

    private void ArriveAtDestination()
    {
        if (!arrived)
        {
            Debug.Log("I arrived!");
            arrived = true;
            StartCoroutine(FadeOut());
            killer.SavedCount++;
            killer.UpdateUI();
        }
    }

    public void SetDestination(float val)
    {
        goalXPos = val;
    }
}
