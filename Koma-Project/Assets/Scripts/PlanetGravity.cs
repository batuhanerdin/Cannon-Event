using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public float gravityForce=5;
    public float orbitDistance=5;
    public float orbitSpeed=5;
    public int cameraDirection=0;

    private CircleCollider2D CircleCollider2D;
    private CircleCollider2D triggerCircleCollider2D;

    private void Start()
    {
        CircleCollider2D = GetComponent<CircleCollider2D>();
        triggerCircleCollider2D = GetComponent<CircleCollider2D>();
        triggerCircleCollider2D.isTrigger = true;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward, orbitSpeed * Time.deltaTime);
        triggerCircleCollider2D.radius = orbitDistance;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;

            if (distance > 0)
            {
                float forceMagnitude = gravityForce / distance;
                Vector2 gravityForceVector = direction.normalized * forceMagnitude;
                other.GetComponent<Rigidbody2D>().AddForce(gravityForceVector);
            }
        }
    }

}
