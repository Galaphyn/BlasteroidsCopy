using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float bound = -8f;

    private int hp = 3;
    void Start()
    {
        
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
                ScoreControl score = GameObject.Find("ScoreKeeper").GetComponent<ScoreControl>();
                score.updateScore();
                Destroy(gameObject);
            }
        }    
    }
}
