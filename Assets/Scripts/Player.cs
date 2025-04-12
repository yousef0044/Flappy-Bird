using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 direction;
    public float gravity = -9.8f;
    
    public float strength = 5f;

    SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    int spriteIndex;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void AnimateSprite()
    {
        spriteIndex ++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Obstacles")
        {
            FindObjectOfType<GameManager>().Game_Over();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().Increase_Score();
        }
    }
        
   
}
