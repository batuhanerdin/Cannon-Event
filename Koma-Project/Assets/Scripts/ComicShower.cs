using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicShower : MonoBehaviour
{
    public Transform[] positions; // 4 farklı konumu bu dizide saklayın
    public float switchSpeed = 2f; // Geçiş hızı
    public float autoSwitchDelay = 10f; // Otomatik geçiş süresi (10 saniye)
    public float fixedZValue = 0f; // Sabit Z değeri

    private int currentPositionIndex = 0;
    private float lastKeyPressTime;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    
    private void Start()
    {
        // İlk konuma git
        SwitchToPosition(currentPositionIndex);
    }

    private void Update()
    {
        // Her tuşa basıldığında bir sonraki konuma geçiş yap
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPositionIndex == positions.Length - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            SwitchToNextPosition();
        }

        // Otomatik geçiş süresi dolduysa bir sonraki konuma geçiş yap
        if (Time.time - lastKeyPressTime >= autoSwitchDelay)
        {
            SwitchToNextPosition();
        }

        // Kamerayı hedef konuma doğru yumuşak bir şekilde hareket ettir
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * switchSpeed);
        newPosition.z = fixedZValue; // Z değerini sabitle
        transform.position = newPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * switchSpeed);

        
    }

    private void SwitchToNextPosition()
    {
        // Bir sonraki konuma geçiş yap ve zamanı sıfırla
        currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
        SwitchToPosition(currentPositionIndex);
        lastKeyPressTime = Time.time;
    }

    private void SwitchToPosition(int index)
    {
        // Kamerayı belirtilen konuma taşıyın (Lerp ile)
        if (index >= 0 && index < positions.Length)
        {
            targetPosition = positions[index].position;
            targetRotation = positions[index].rotation;
        }
    }

}
