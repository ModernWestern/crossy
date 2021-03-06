using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string Player = "Player";

    [SerializeField] private Player player;

    [SerializeField] private PlayerEvents events;

    [SerializeField] private GameSettings gameSettings;

    private int goalCount;

    private void Awake()
    {
        player.Events = events;

        events.OnFinish += () =>
        {
            goalCount++;

            if (goalCount >= gameSettings.goalsAmount)
            {
                events.GameOver(true);

                return;
            }

            player.Animation(true);

            player = Instantiate(player);

            player.Events = events;

            player.name = Player;
        };

        if (this)
        {
            // Avoid player movement after Gameover call
            events.OnGameOver += value => gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.Up();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.Left();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player.Down();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            player.Right();
        }
    }
}