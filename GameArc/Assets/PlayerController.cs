using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

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
	}
    // CLIENT: Set colour for player to identify it from the SERVER clone
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
