using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] GameObject spike;
    [SerializeField] float pos;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "spikeSensor")
        {
            spike.transform.position = new Vector2(spike.transform.position.x, spike.transform.position.y + pos);
            spike.GetComponent<AudioSource>().Play();
        }
    }
}
