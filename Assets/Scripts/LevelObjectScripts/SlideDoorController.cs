using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorController : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float openCloseTime;
    public float idleTimer = 2f;
    private float initialIdleTimer;
    private bool goingUp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform currentPos = gameObject.GetComponent<Transform>();
        float currentHeight = currentPos.transform.position.y;
        float movePerSecond = (maxHeight - minHeight) / openCloseTime;
        float movePerFrame = movePerSecond * Time.deltaTime;

        

        if (currentHeight > maxHeight)
        {
            StopCoroutine(Idle());
            goingUp = false;
            StartCoroutine(Idle());
        }

        if (currentHeight < minHeight)
        {
            StopCoroutine(Idle());
            goingUp = true;
            StartCoroutine(Idle());
        }

        if (currentHeight <= maxHeight && goingUp)
        {
            transform.position =  transform.position + new Vector3(0f, movePerFrame, 0f);
        }

        
        if(currentHeight >= minHeight && !goingUp)
        {
            transform.position = transform.position + new Vector3(0f, -movePerFrame, 0f);
        }
    }

    IEnumerator Idle()
    {
        Debug.Log("wait start");
        yield return new WaitForSeconds(2);
        Debug.Log("wait finish");
    }
}
