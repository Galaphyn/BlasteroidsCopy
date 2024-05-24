using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5f;

    public float cooldown = 0.25f;
    private float cooldownTimer;
    public float projSpeed = 10f;
    public GameObject projectile;

    public int numberOfProjectiles = 40;
    public float spacing = .5f;
    public float specialCooldown = 10f;
    private float specialTimer;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;

        if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer < Time.time)
        {
            ShootLaser(direction);
            cooldownTimer = Time.time + cooldown;
        }

        if (Input.GetKey(KeyCode.Space) && specialTimer < Time.time)
        {
            //ShootSpecial();
            StartCoroutine(ShootSpecial());
            specialTimer = Time.time + specialCooldown;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    private void ShootLaser(Vector2 direction)
    {
        //Instantiate and move projectile
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().velocity = direction.normalized * projSpeed;

        //Calculate angle of velocity to rotate laser
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        proj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private IEnumerator ShootSpecial()
    {
        float multiCooldown = 0.5f;

        Vector3 startPosition = new Vector3(-spacing * (numberOfProjectiles - 1) / 2, -Camera.main.orthographicSize, 0);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < numberOfProjectiles; j++)
            {
                Vector3 spawnPosition = startPosition + new Vector3(j * spacing, 0, 0);
                GameObject proj = Instantiate(projectile, spawnPosition, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().velocity = Vector2.up * projSpeed;
            }
            yield return new WaitForSeconds(multiCooldown); // Wait for the cooldown before the next iteration
        }
    }

    private void Restart()
    {
        // Reload the current scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    /*
    private void ShootSpecial()
    {
        float multiCooldown = 0.5f;
        float multiTimer = 0;

        Vector3 startPosition = new Vector3(-spacing * (numberOfProjectiles - 1) / 2, -Camera.main.orthographicSize, 0);
        for (int i = 0; i < 3; i++)
        {
            if (multiTimer < Time.time)
            {
                for (int j = 0; j < numberOfProjectiles; j++)
                {
                    Vector3 spawnPosition = startPosition + new Vector3(j * spacing, 0, 0);
                    GameObject proj = Instantiate(projectile, spawnPosition, Quaternion.identity);
                    proj.GetComponent<Rigidbody2D>().velocity = Vector2.up * projSpeed;
                }
                multiTimer = multiCooldown + Time.time;
            }
 
        }
    }
    */
}

