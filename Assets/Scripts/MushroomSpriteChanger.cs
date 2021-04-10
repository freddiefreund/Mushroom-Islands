using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite standing_left;
    [SerializeField] private Sprite jumping_left;
    [SerializeField] private Sprite smiling_left;
    [SerializeField] private Sprite falling_left;
    
    [SerializeField] private Sprite standing_right;
    [SerializeField] private Sprite jumping_right;
    [SerializeField] private Sprite smiling_right;
    [SerializeField] private Sprite falling_right;

    private SpriteRenderer spriteRenderer;
    private int direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(int dir) // 0 is left, 1 is right
    {
        direction = dir;
    }

    public void SetToFalling()
    {
        
        spriteRenderer.sprite = falling_right;
    }
    public void SetToStanding()
    {
        if (direction == 0)
        {
            spriteRenderer.sprite = standing_left;
        }
        else
        {
            spriteRenderer.sprite = standing_right;
        }
    }

    public void SetToJumping()
    {
        
    }

    public void SetToSmiling()
    {
        
    }
}
