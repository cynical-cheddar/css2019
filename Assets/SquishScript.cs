using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishScript : MonoBehaviour
{
    public AudioClip clompSound;
    public float rate = 3f;
    public float dist = 1.5f;
    public float speed = 2f;
    public float recoverySpeed = 2f;
    public bool auto = true;
    private float time = 0;
    private bool squishing = false;
    private bool recovering = false;
    private Vector3 start;
    private Vector3 end;
    private float pos = 0;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = transform.position + (Vector3.down * dist);
        foreach (Transform cTransform in transform.GetComponentsInChildren<Transform>()) {
            //Debug.Log(cTransform.parent.gameObject.name);
            //if (cTransform != transform) cTransform.parent = transform;
        }
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Trigger() {
        squishing = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if (time >= rate && auto) {
            time -= rate;
            squishing = true;
            pos = 0;
            //transform.position = end;
        }

        if (squishing) {
            if (!recovering) pos += Time.deltaTime * speed;
            else pos += Time.deltaTime * recoverySpeed;

            if (!recovering) {
                rigidbody.MovePosition(Vector3.Lerp(start, end, pos));
            }
            else {
                rigidbody.MovePosition(Vector3.Lerp(end, start, pos));
                if(!GetComponent<AudioSource>().isPlaying){
                    GetComponent<AudioSource>().clip = clompSound;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (pos >= dist) {
                if (recovering) squishing = false;
                recovering = !recovering;
                pos = 0;
            }
            
        }
    }
}
