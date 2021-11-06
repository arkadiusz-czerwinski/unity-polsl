using UnityEngine;

public class Player_collision : MonoBehaviour
{
    public float pill_counter = 0;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            pill_counter++;
            Destroy(collision.gameObject);

            if (pill_counter == 5) {
                // Application.Quit();
                Application.LoadLevel(Application.loadedLevel);
                Application.OpenURL("https://www.youtube.com/watch?v=HIPQQ4qnl6Q");
            }
        }
            //Application.LoadLevel(Application.loadedLevel);

            //Application.OpenURL("https://www.youtube.com/watch?v=HIPQQ4qnl6Q");
    }
}
