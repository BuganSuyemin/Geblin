using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerTile player;

    private void Start()
    {
        player = GetComponent<PlayerTile>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            player.StartMovement(Direction.UP);
        if (Input.GetKeyDown(KeyCode.D))
            player.StartMovement(Direction.RIGHT);
        if (Input.GetKeyDown(KeyCode.S))
            player.StartMovement(Direction.DOWN);
        if (Input.GetKeyDown(KeyCode.A))
            player.StartMovement(Direction.LEFT);
    }
}
