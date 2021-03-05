using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] projectilePrefabs;

    float horizontalInput;
    float speed = 30.0f;
    float xRange = 15;

    void Update()
    {
        // Keep the Player in bounds
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the Player
            int projectileIndex = Random.Range(0, projectilePrefabs.Length);
            Instantiate(projectilePrefabs[projectileIndex], transform.position, projectilePrefabs[projectileIndex].transform.rotation);
        }
    }
}
