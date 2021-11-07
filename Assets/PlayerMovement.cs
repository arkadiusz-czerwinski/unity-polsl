using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float xAxisForce = 0f;
    public float yAxisForce = 0f;//jump force
    public float zAxisForce = 0f;

    public float rotation = 0;
    public float radRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Kapitan Koks 3D");
        Debug.Log("By Whiskey Whale Studios");
    }

    // Update is called once per frame
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

        //if (Input.GetKeyDown("j"))
        //{
        //    yAxisForce = 10000;
        //}
        //else yAxisForce = 0;

        rb.AddForce(xAxisForce * Time.deltaTime, yAxisForce * Time.deltaTime, zAxisForce * Time.deltaTime);
    }
}
