using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Transform ballSpawnPoint;

    private float mousePosX;

    private float leftFieldBorder;
    private float rightFieldBorder;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosX = LevelManager.Instance.mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = new Vector2(Mathf.Clamp(mousePosX, leftFieldBorder, rightFieldBorder), transform.position.y);
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
