using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickStrength;
    public Sprite[] brickSprites;

    private SpriteRenderer brickRenderer;

    private void Start()
    {
        brickRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        brickRenderer.sprite = brickSprites[brickSprites.Length - brickStrength];
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            brickStrength -= 1;

            if (brickStrength > 0)
            {
                UpdateSprite();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}