using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MeteorControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float bound = -8f;

    private int hp = 3;

    GameControl gameControl;
    void Start()
    {
        gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y < bound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            hp--;
            Destroy(collision.gameObject);
            if (hp <= 0) 
            {
                gameControl.updateScore();
                Destroy(gameObject);
            }
        }
        
        if (collision.tag == "Player")
        {
            gameControl.updatePlayerHP();
            if (gameControl.player <= 0) 
            {
                Destroy(collision.gameObject);
                Time.timeScale = 0;
            }
            Destroy(gameObject);
        }


        if (collision.tag == "Planet")
        {
            gameControl.updatePlanetHP();
            if (gameControl.planet <= 0)
            {
                Destroy(collision.gameObject);
                Time.timeScale = 0;
            }
            Destroy(gameObject);
        }
    }
}
