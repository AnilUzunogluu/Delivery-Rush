using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    [SerializeField] private Driver driverScript;
    public bool _gotPackage;
    public bool _deliveredPackage;
    private SpriteRenderer spriteRenderer;
    private void OnCollisionEnter2D(Collision2D col)
    {
        driverScript.SlowDown();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !_gotPackage)
        {
            spriteRenderer.color = Color.magenta;
            _gotPackage = true;
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Customer") & _gotPackage)
        {
            spriteRenderer.color = Color.white;
            _gotPackage = false;
            _deliveredPackage = true;
            Destroy(col.gameObject);
        }else if (col.CompareTag("Boost"))
        {
            driverScript.PickUpBoost();
        }
        else return;
    }
}
