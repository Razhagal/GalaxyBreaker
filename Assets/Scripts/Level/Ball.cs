using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float MinBallSpeed = 3f;
    private const float MaxBallSpeed = 15f;

    private Rigidbody2D rBody;
    private Paddle playerPaddle;

    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float speedIncrement = 1f;

    private bool isFlying = false;
    private Vector2 stickyPos; // Used for spawn position and if the paddle has Sticky power-up

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        playerPaddle = LevelManager.Instance.playerPaddle;

        float spawnY = playerPaddle.ballSpawnPoint.position.y + this.GetComponent<SpriteRenderer>().bounds.extents.y + Physics2D.defaultContactOffset;
        stickyPos = new Vector2(playerPaddle.ballSpawnPoint.position.x + 0.1f, spawnY);
        transform.position = stickyPos;

        isFlying = false;
    }

    private void Update()
    {
        if (!isFlying)
        {
            // TODO: Update with proper position if the ball is stuck to paddle
            transform.position = new Vector2(playerPaddle.transform.position.x + 0.1f, transform.position.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
    }

    private void LaunchBall()
    {
        isFlying = true;

        rBody.velocity = (transform.position - playerPaddle.transform.position).normalized * startSpeed;

        //rBody.velocity = new Vector2(Random.Range(-6f, 6f), Random.Range(1f, 7f));
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Debug.DrawLine(transform.position, collider.transform.position, Color.red, 2f);
            Vector2 newDirection = transform.position - collider.transform.position;

            if (newDirection.y < 0.15f)
            {
                newDirection = new Vector2(newDirection.x, 0.15f);
            }

            rBody.velocity = newDirection.normalized * Mathf.Clamp(rBody.velocity.magnitude + speedIncrement, MinBallSpeed, MaxBallSpeed);
        }
    }
}