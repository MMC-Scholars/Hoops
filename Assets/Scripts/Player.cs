﻿using UnityEngine;

public class Player : BasePawn {
    private RaycastHit lookingAt;
    private GameObject heldObject;
    private float      holdDistance;
    public float       interactDistance = 10.0f;
    public float       throwStrength    = 10.0f;

    /**
     * Called on each update frame
     */

    public override void BaseUpdate() {
        raycastUpdate();
        if (Input.GetKeyDown(KeyCode.E)) pickUp();
    }

    void FixedUpdate() {}

    void raycastUpdate() {
        if (Physics.Raycast(this.transform.position,
                            this.transform.TransformDirection(Vector3.forward),
                            out lookingAt, interactDistance)) {
            Debug.Log("Looking at: " + lookingAt.collider.gameObject.name);

        } else {
            Debug.Log("Looking at: nothing");
        }
    }
    void pickUp() {
        // If currently holding something, drop it
        if (heldObject != null) {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().useGravity = true;
            heldObject.GetComponent<Rigidbody>().AddForce(
                throwStrength * this.transform.TransformDirection(Vector3.forward),
                ForceMode.Impulse);
            Physics.Simulate(Time.fixedDeltaTime);
            heldObject = null;
        }
        // If looking at a basketball, pick it up
        else if (lookingAt.collider.gameObject.CompareTag("Basketball")) {
            heldObject = lookingAt.collider.gameObject;
            heldObject.GetComponent<Rigidbody>().useGravity      = false;
            heldObject.GetComponent<Rigidbody>().velocity        = Vector3.zero;
            heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            heldObject.transform.SetParent(this.transform);
        }
    }
}
