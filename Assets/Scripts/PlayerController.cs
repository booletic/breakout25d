using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float boundry = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // user-input to move pedal sideways
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.down);

        // limit pedal right movement
        if (transform.position.x > boundry)
        {
            transform.position = new Vector3(boundry, 1, 0);
        }

        // limit pedal left movement
        if (transform.position.x < -boundry)
        {
            transform.position = new Vector3(-boundry, 1, 0);
        }
    }
}
