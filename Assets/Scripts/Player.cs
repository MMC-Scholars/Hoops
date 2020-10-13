﻿using UnityEngine;

public class Player : BasePawn
{
    private GameObject heldObject;
    private float cooldown = 2.0f;
    private bool isThrowing = false;

    public float throwStrength = 0.0f;
    public float interactDistance = 10.0f;
    public float maxThrow = 10.0f;
    public float throwModifier = 1.0f;
    public float reloadTime = 2.0f;
    /**
     * Called on each update frame to update input
     */

    public override void BaseUpdateInput()
    {
        isThrowing = (BaseInput.isTriggerPressed() || (isThrowing && !BaseInput.isTriggerReleased()));
        if (heldObject)
        {
            if (isThrowing) startThrow();
            if (BaseInput.isTriggerReleased()) throwObject();
        }
    }

    /**
     * Called on each update frame
     */

    public override void BaseUpdate()
    {
        if (!heldObject) pickUp();
    }
    void pickUp()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            heldObject = this.GetComponent<BasketballPool>().getObject();
            heldObject.SetActive(true);
            heldObject.GetComponent<Rigidbody>().useGravity = false;
            heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            heldObject.transform.SetParent(this.transform);
            heldObject.transform.SetPositionAndRotation(this.transform.TransformDirection(Vector3.forward) * interactDistance, Quaternion.identity);
            cooldown = reloadTime;
        }
    }
    void startThrow()
    {
        throwStrength += throwModifier * Time.deltaTime;
        if (throwStrength > maxThrow) throwStrength = maxThrow;
    }
    void throwObject()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().AddForce(
            throwStrength * this.transform.TransformDirection(Vector3.forward),
            ForceMode.Impulse);
        heldObject = null;
        throwStrength = 0.0f;
        isThrowing = false;
    }
}
