using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Transform ballSpawnPoint;

    private float mousePosX;

    private float leftFieldBorder;
    private float rightFieldBorder;
    private int moveSpeed = 20;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosX = LevelManager.Instance.mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            Vector2 newPos = new Vector2(Mathf.Clamp(mousePosX, leftFieldBorder, rightFieldBorder), transform.position.y);
            transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);
            //transform.position = new Vector2(Mathf.Clamp(mousePosX, leftFieldBorder, rightFieldBorder), transform.position.y);
        }

        // TODO: If player taps/clicks somewhere, the paddle needs to finish the movement to that position in case the tap/click was brief
    }

    public void CalculateFieldBordersRelativeToPadSize()
    {
        Vector2 padSize = GetComponent<SpriteRenderer>().bounds.size;

        leftFieldBorder = LevelManager.Instance.LeftLevelBorderX + (padSize.x / 2);
        rightFieldBorder = LevelManager.Instance.RightLevelBorderX - (padSize.x / 2);
    }

    public void ResetToDefaultPosition()
    {
        transform.position = new Vector3(0f, transform.position.y, 0f);
    }
}
