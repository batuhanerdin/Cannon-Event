using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class consciousness : MonoBehaviour
{
    public float minForce = 10f;
    public float maxForce = 100f;

    private float currentForce = 0f;
    private bool isApplyingForce = false;
    private bool canJump = false;

    private Rigidbody2D rb;

    public GameObject arrow;
    private SpriteRenderer arrowSpriteRenderer;
    private bool forceChangeDirection = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrowSpriteRenderer=arrow.GetComponent<SpriteRenderer>();
        arrowSpriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&canJump==true)
        {
            currentForce = minForce;
            isApplyingForce = true;
            arrowSpriteRenderer.enabled=true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && canJump==true)
        {
            canJump = false;
            // Debug.Log ile son kuvveti görüntüle
            Debug.Log("Son Kuvvet: " + currentForce);

            // Parent objesinin pozisyonundan kendi pozisyonuna doðru bir vektörle kuvvet uygula
            Vector3 parentTransformPosition = transform.parent.position;
            Vector2 rbPosition = rb.position;
            // Child objeyi parent'tan ayýr
            transform.parent = null;

            Vector2 forceDirection = (rbPosition - (Vector2)parentTransformPosition).normalized;
            rb.AddForce(forceDirection * currentForce*10);

            isApplyingForce = false;
            arrowSpriteRenderer.enabled = false;
        }

        if (isApplyingForce)
        {
            // Kuvvet deðiþkenini artýr
            Debug.Log("Su anki Kuvvet: " + currentForce);
            
            arrow.transform.localScale = Vector3.one*currentForce/50;
            
            if (forceChangeDirection==true)
            {
                currentForce = Mathf.Clamp(currentForce + Time.deltaTime * 50f, minForce, maxForce);
                arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x, arrow.transform.localPosition.y + currentForce / 5000, arrow.transform.localPosition.z);

            }
            else if (forceChangeDirection==false)
            {
                currentForce = Mathf.Max(currentForce -  Time.deltaTime * 50f, minForce);
                arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x, arrow.transform.localPosition.y - currentForce / 5000, arrow.transform.localPosition.z);


            }
            if (currentForce>=maxForce)
            {
                forceChangeDirection = false;
            }
            if (currentForce<=minForce)
            {
               forceChangeDirection = true;
            }
            
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            transform.parent= collision.transform;

            canJump = true;
            rb.velocity = Vector3.zero;
            Vector3 parentTransformPosition = transform.parent.position;
            Vector2 rbPosition = rb.position;

            Vector2 arrowDirection = (rbPosition - (Vector2)parentTransformPosition).normalized;
            Debug.Log(arrowDirection.x + ", " + arrowDirection.y);
            //arrow.transform.Rotate(0,0,arrowDirection);

            float angle = Mathf.Atan2(arrowDirection.y, arrowDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle-90f);
        }
    }
}
