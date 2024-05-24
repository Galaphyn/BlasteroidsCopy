using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int planetHealth = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Meteor")
        {
            planetHealth--;
            if(planetHealth == 0)
            {
                //game over
            }
        }
    }
}
