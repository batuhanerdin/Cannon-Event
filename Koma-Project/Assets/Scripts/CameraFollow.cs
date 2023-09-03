using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 hedefPozisyonu;
    private float hareketHizi = 1.5f; // Hareket h�z� ayar�

    private bool hareketBasladi = false;

    void Update()
    {
        if (hareketBasladi)
        {
            Debug.Log("gidemiyom");
            transform.position = Vector3.Lerp(transform.position, hedefPozisyonu, hareketHizi * Time.deltaTime);

            // Hedefe yakla�t���n� kontrol et
            if (Vector3.Distance(transform.position, hedefPozisyonu) <= 0.05f)
            {
                hareketBasladi = false;
            }
        }
    }

    // GameObject'i hareket ettirmek i�in bu fonksiyonu kullanabilirsiniz
    public void HareketEt(Vector3 hedef)
    {
        if (!hareketBasladi)
        {
            hedefPozisyonu = new Vector3(hedef.x, hedef.y, transform.position.z);
            hareketBasladi = true;
        }
    }
}
