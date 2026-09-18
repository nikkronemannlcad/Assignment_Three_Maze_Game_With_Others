using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float     floorHeight = -10f;

    public float     moveSpeed   = 5f;
    public float     jumpImpulse = 250f;
    public Transform player;
    public Transform spawn;
    public Transform win;

    Rigidbody playerBody;

    bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting rigidbody
        playerBody = GetComponent<Rigidbody>();

        //Setting grounded to true
        grounded   = true;

        //Setting position of player to spawn
        player.position = spawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        //Getting input key and then adding corresponding vector direction to direction vector
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        //Normalizing vector to make sure when moving horizontally the movement speed does not change
        direction = Vector3.Normalize(direction);

        //Checking if the player is grounded using raycast
        grounded = Physics.Raycast(player.position, Vector3.down, 1.01f);

        //Checking if the player pressing the space bar and the player is grounded
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            playerBody.AddForce(jumpImpulse * Vector3.up);
        }

        //Applying movement to play using moveSpeed and delta time if player is grounded
        if (grounded)
        {
            //player.Translate(direction * moveSpeed * Time.deltaTime);
            playerBody.AddForce(direction * moveSpeed * Time.deltaTime);
        }

        //Checking if the player is below the ground and if so repsawn the player
        if (player.position.y < floorHeight)
        {
            Respawn();
        }

        //Checking distance to won position and if so play the win functions
        if (Vector3.Distance(player.position, win.position) <= 1.0f)
        {
            Win();
        }

        Debug.Log("Player Grounded: " + grounded);

    }

    void Win()
    {
        //Enabling win gameobject
        win.gameObject.SetActive(true);
    }   
    
    void Respawn()
    {
        //Setting position of player to spawn
        player.position = spawn.position;

        //Resetting player velocity
        playerBody.isKinematic = true;
        playerBody.isKinematic = false;
    }
}
