using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickData brickData;

    private SpriteRenderer brickRenderer;
    private int currentStrength = 1;

    private void Start()
    {
        InitBrick();
    }

    [ContextMenu("Initalize Brick")]
    private void InitBrick()
    {
        brickRenderer = GetComponent<SpriteRenderer>();
        currentStrength = brickData.maxBrickStrength;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        brickRenderer.sprite = brickData.brickSprites[brickData.brickSprites.Length - currentStrength];
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            currentStrength -= 1;

            if (currentStrength > 0)
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