using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Transform ballSpawnPoint;

    private float mousePosX;

    private float leftFieldBorder;
    private float rightFieldBorder;

    private bool isMoving = false;
    private Vector2 movePos;
    private int moveSpeed = 20;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            mousePosX = LevelManager.Instance.mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            movePos = new Vector2(Mathf.Clamp(mousePosX, leftFieldBorder, rightFieldBorder), transform.position.y);
        }

        if (isMoving)
        {
            if (Vector2.Distance(transform.position, movePos) > 0.01f)
            {
                transform.position = Vector2.Lerp(transform.position, movePos, Time.deltaTime * moveSpeed);
            }
            else
            {
                isMoving = false;
                transform.position = movePos;
            }
        }
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
