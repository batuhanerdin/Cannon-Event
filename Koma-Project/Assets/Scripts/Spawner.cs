using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs; // 3 prefabý bu dizi içinde saklar
    public float range = 10f; // X ekseni boyunca menzil
    public Color lineColor = Color.cyan; // Çizgi rengi
    private GameObject gameObject;

    private void OnDrawGizmos()
    {
        // Menzil çizgisini çiz
        Gizmos.color = lineColor;
        Gizmos.DrawLine(transform.position + Vector3.left * range / 2f, transform.position + Vector3.right * range / 2f);
    }

    private IEnumerator Start()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogError("Prefablar tanýmlanmamýþ.");
            yield break;
        }

        // Sonsuz bir döngü içinde prefablarý yarat
        while (true)
        {
            // Rastgele bir prefab seç
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject selectedPrefab = prefabs[randomIndex];

            // Rastgele bir X konumu seç
            float randomX = transform.position.x + Random.Range(-range / 2f, range / 2f);

            // Prefabý seçilen X konumunda instantiate et
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            gameObject=Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
            // 2 saniye bekle
            yield return new WaitForSeconds(5f);
        }
    }
}