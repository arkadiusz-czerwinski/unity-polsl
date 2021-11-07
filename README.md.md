# Simple unity game for lab 1 from unity

## Authors

- Miłosz Homa
- Arkadiusz Czerwiński

## Game design and implementation

 The purpose of this lab is to create a simple 3d game with basic interactions. Said interactions, in the case of our game, are collisions and counter updates. The counter should update on collision adding one point for each collision with our collectables - pills. If the counter reaches 5 (the number of pills the game will reset and turn darker). The pills present as follows:

 

![First person game view](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled.png)

First person game view

The game starts with our player (cube) on the one side of the "road", while pills are scattered on the whole road to be collected.

![Game level overview](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%201.png)

Game level overview

The player is to steer the box using solely wsad standard controls (w for up. s for down d for right and finally a for left). 

Workflow:

- Since we have not known anything about unity at first we have created models of cube and road, to test simple movements and basic interactions like gravity. Since we don't have experience in game design, we thought of a Pacman-style game to be the most fault-proof concept we can come up with. After the models, we have added our textures according to the tutorial on creating custom single colour textures.
- The next part of the project was to add the movement to the player object via script. All interaction scripts were implemented using MonoBehaviour.

```csharp
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float xAxisForce = 0f;
    public float yAxisForce = 0f;//jump force
    public float zAxisForce = 0f;
    public float rotation = 0;
    public float radRotation = 0;

    void Start()
    {
        Debug.Log("Kapitan Koks 3D");
        Debug.Log("By Whiskey Whale Studios");
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rotation--;
            transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey("d"))
        {
            rotation++;
            transform.Rotate(0, 1, 0);
        }

        if (rotation > 360) { rotation = 1; }
        else if (rotation < 0) { rotation = 359; }
        radRotation = rotation / (2 * Mathf.PI * 10);
        //rotacja jest w radianach

        if (Input.GetKey("w"))
        {
            zAxisForce = Mathf.Cos(radRotation) * 500;
            xAxisForce = Mathf.Sin(radRotation) * 500;
        }
        else if (Input.GetKey("s"))
        {
            zAxisForce = -Mathf.Cos(radRotation) * 500;
            xAxisForce = -Mathf.Sin(radRotation) * 500;
        }
        else
        {
            
            xAxisForce = 0;
            zAxisForce = 0;
        }

        rb.AddForce(xAxisForce * Time.deltaTime, yAxisForce * Time.deltaTime, zAxisForce * Time.deltaTime);
    }
}
```

- The next stage was to create a camera that follows the player. This behaviour was implemented by creating follow player class:

```csharp
public class FollowPlayer : MonoBehaviour
{
    public Transform playerCoordinates;
    public Vector3 offset;
    void Update()
    {
        transform.position = playerCoordinates.position + offset;
    }
}
```

- After all was set we have implemented rotation of the pills for additional visual effects:

```csharp
void Update()
    {
        transform.Rotate(2,0,2);
    }
```

- Finally, we have tried adding the collisions. For the collision detection, we have set the boxcolider to every possible object

![Floor alongside with it's properties](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%202.png)

Floor alongside with it's properties

    As well as the rigid body property for the player, which should have physics.

![Player-cube alongside with it's properties](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%203.png)

Player-cube alongside with it's properties

The collisions were implemented by creating a player collision script (creating Player_collision class)
the most important element of the class is the action on the specific collision with the object described by the tag assigned to the pill:

![Capsule tag](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%204.png)

Capsule tag

```csharp
public float pill_counter = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            pill_counter++;
            Destroy(collision.gameObject);
            if (pill_counter == 5) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
```

## The screens after the finished level

![New level design](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%205.png)

New level design

![The pop-up video on finished level](Simple%20unity%20game%20for%20lab%201%20from%20unity%20a1b01bb8df0243bfbfd083341c492e59/Untitled%206.png)

The pop-up video on finished level

## Version control:

The code tracing for the project was implemented using git, more specifically, the GitHub platform. The link to the repository can be found [here](https://github.com/arkadiusz-czerwinski/unity-polsl).