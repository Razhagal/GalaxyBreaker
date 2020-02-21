using UnityEngine;

public class BottomLevelBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            // A ball dropped out of the field;
            LevelManager.Instance.OnBallFallout(collider.gameObject);
        }
    }
}