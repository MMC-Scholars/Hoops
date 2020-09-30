using UnityEngine;

public class Player : BasePawn {
    private RaycastHit lookingAt;
    private GameObject heldObject;
    private float      throwStrength    = 0.0f;
    public float       interactDistance = 10.0f;
    public float       maxThrow         = 10.0f;
    public float       throwModifier    = 1.0f;

    /**
     * Called on each update frame to update input
     */

    public override void BaseUpdateInput() {
        if (BaseInput.isTriggerPressed()) pickUp();
        if (heldObject) throwObject();
    }

    /**
     * Called on each update frame
     */

    public override void BaseUpdate() { raycastUpdate(); }

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
        if (lookingAt.normal != Vector3.zero && lookingAt.collider.gameObject.CompareTag("Basketball")) {
            heldObject = lookingAt.collider.gameObject;
            heldObject.GetComponent<Rigidbody>().useGravity      = false;
            heldObject.GetComponent<Rigidbody>().velocity        = Vector3.zero;
            heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            heldObject.transform.SetParent(this.transform);
        }
    }
    void throwObject() {

        if(Input.GetKey(KeyCode.Mouse1)){
            throwStrength += throwModifier * Time.deltaTime;
            if(throwStrength > maxThrow) throwStrength = maxThrow;
        } 
        else if (Input.GetKeyUp(KeyCode.Mouse1)){
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().AddForce(
            throwStrength * this.transform.TransformDirection(Vector3.forward),
            ForceMode.Impulse);
        heldObject    = null;
        throwStrength = 0.0f;
        }
    }
}
