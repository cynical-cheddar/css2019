    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerScript : MonoBehaviour
{
    private Rigidbody rb;
    private float distanceToGround;
    private Camera camera;

    public bool grounded;
    public float speed;
    public float jump;
    
    public bool jumpable;
    public float jumpangle;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInChildren<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.3f, 0);
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    bool canJump()
    {
        return (Input.GetKey("space") && (rb.gameObject.transform.rotation.eulerAngles.x < jumpangle || rb.gameObject.transform.rotation.eulerAngles.x > 360-jumpangle) && (rb.gameObject.transform.rotation.eulerAngles.z < jumpangle || rb.gameObject.transform.rotation.eulerAngles.z > 360-jumpangle));
    }
    

    // Update is called once per frame
    void Update()
    {

       // if(grounded)
      //  {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 forward = camera.transform.forward;
            Vector3 right = camera.transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            if (canJump())
            {
                rb.AddForce(rb.gameObject.transform.up * jump);

            }
            Vector3 movement = forward * moveVertical + right * moveHorizontal;
            rb.AddForce(movement * speed);
      //  }
        
    }
}
