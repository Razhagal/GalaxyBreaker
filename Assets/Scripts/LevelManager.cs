using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Level grid should be 10x13  75px x 37.5px per brick
    public static LevelManager Instance;

    public Transform bordersParent;
    public Transform leftBorder;
    public Transform rightBorder;

    public Paddle playerPaddle;

    public GameObject ballPrefab;

    [HideInInspector] public Camera mainCamera;

    public float LeftLevelBorderX { get; private set; }
    public float RightLevelBorderX { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CalculateLevelScale();

        mainCamera = Camera.main;

        SetupLevelBorders();
        InitializeLevel();
    }

    private void SetupLevelBorders()
    {
        LeftLevelBorderX = leftBorder.position.x + leftBorder.GetComponent<SpriteRenderer>().bounds.extents.x;
        RightLevelBorderX = rightBorder.position.x - rightBorder.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void InitializeLevel()
    {
        InitializiePlayer();
        InitializeBall();
    }

    private void InitializiePlayer()
    {
        playerPaddle.CalculateFieldBordersRelativeToPadSize();
    }

    private void InitializeBall()
    {
        GameObject.Instantiate(ballPrefab);
    }

    public void OnBallFallout(GameObject ballObj)
    {
        Destroy(ballObj);

        playerPaddle.ResetToDefaultPosition();
        InitializeBall();
    }

    [ContextMenu("Recalculate Scale")]
    private void CalculateLevelScale()
    {
        //#if UNITY_EDITOR
        //        transform.localScale = new Vector3((float)Camera.main.pixelWidth / Camera.main.pixelHeight, 1f, 1f);
        //#else
        bordersParent.localScale = new Vector3((float)Screen.width / Screen.height, 1f, 1f);
        //#endif

    }
}
