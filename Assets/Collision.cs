using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    SpriteRenderer spriteRenderer;
    bool hasPackage;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OUCH!");
        if (other.gameObject.tag == "HidenObject")
        {
            Destroy(other.gameObject, destroyDelay / 5);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (the thing we trigger is the package), then print "package picked up"
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.tag == "Post" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package Delivered!");
            spriteRenderer.color = noPackageColor;
        }
    }


}
