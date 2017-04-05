using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    // REFERENCE BULLET PREFAB
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
	void Update ()
    {
        // CLIENT: Priority
        if (!isLocalPlayer)
        {
            return;
        }
        // Player movement using WASD, ARROW Keys or Controller.
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        // BULLET
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
	}

    // FIRE BULLET
    void Fire()
    {
        // CREATE: Bullet from Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // VELOCITY
        bullet.GetComponent < Rigidbody>().velocity = bullet.transform.forward * 6;

        // DESTROY BULLET
        Destroy(bullet, 2.0f);
    }
    
    // CLIENT: Set colour for player to identify it from the SERVER clone
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
