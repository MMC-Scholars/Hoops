using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBaseEntity
{
    private RaycastHit lookingAt;
    private GameObject heldObject;
    private float holdDistance;
    public float lookDistance = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycastUpdate();
        
    }

    void FixedUpdate()
    {

    }


    void raycastUpdate()
    {
        if(Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out lookingAt, lookDistance))
        {
            Debug.Log("Looking at: " + lookingAt.collider.gameObject.name);
            
            pickUp();
        }
    }
    void pickUp()
    {
        if (lookingAt.collider.gameObject.CompareTag("Basketball"))
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                heldObject = lookingAt.collider.gameObject;
                holdDistance = lookingAt.distance;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                heldObject = null;
            }
        }

        holdObject();
    }

    void holdObject()
    {
        if(heldObject != null)
        {
            heldObject.transform.position = this.transform.position + holdDistance * this.transform.TransformDirection(Vector3.forward);
        }
    }
}
