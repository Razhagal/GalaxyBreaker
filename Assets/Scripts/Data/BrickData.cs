using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brick", menuName = "Level/Brick")]
public class BrickData : ScriptableObject
{
    public int maxBrickStrength;
    public Sprite[] brickSprites;
}