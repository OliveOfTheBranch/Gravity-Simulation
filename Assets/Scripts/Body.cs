using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;

    void Awake()
    {
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(Body[] allBodies, float timeStep)
    {
        foreach (Body otherBody in allBodies)
        {
            if(otherBody != this)
            {
                float squareDistance = (otherBody.transform.position - this.transform.position).sqrMagnitude;
                Vector3 forceDirection = (otherBody.transform.position - this.transform.position).normalized;

                // Newton's Law of Universal Gravitiation
                Vector3 force = forceDirection * Universe.gravitationalConstant * mass * otherBody.mass / squareDistance;

                Vector3 acceleration = force / mass;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        transform.position += currentVelocity * timeStep;
    }

    
}
