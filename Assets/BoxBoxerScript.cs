using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBoxerScript : MonoBehaviour
{
    public GameObject box;
    public float spawnrate;
    private float cooldown;

    void Start()
    {
        cooldown = spawnrate;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(box, transform.position, Quaternion.identity);
            cooldown = spawnrate;
        }

    }
}
