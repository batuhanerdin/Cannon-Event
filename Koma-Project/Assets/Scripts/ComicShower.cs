using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicShower : MonoBehaviour
{
    public Transform[] positions; // 4 farkl� konumu bu dizide saklay�n
    public float switchSpeed = 2f; // Ge�i� h�z�
    public float autoSwitchDelay = 10f; // Otomatik ge�i� s�resi (10 saniye)
    public float fixedZValue = 0f; // Sabit Z de�eri

    private int currentPositionIndex = 0;
    private float lastKeyPressTime;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    
    private void Start()
    {
        // �lk konuma git
        SwitchToPosition(currentPositionIndex);
    }

    private void Update()
    {
        // Her tu�a bas�ld���nda bir sonraki konuma ge�i� yap
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPositionIndex == positions.Length - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            SwitchToNextPosition();
        }

        // Otomatik ge�i� s�resi dolduysa bir sonraki konuma ge�i� yap
        if (Time.time - lastKeyPressTime >= autoSwitchDelay)
        {
            SwitchToNextPosition();
        }

        // Kameray� hedef konuma do�ru yumu�ak bir �ekilde hareket ettir
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * switchSpeed);
        newPosition.z = fixedZValue; // Z de�erini sabitle
        transform.position = newPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * switchSpeed);

        
    }

    private void SwitchToNextPosition()
    {
        // Bir sonraki konuma ge�i� yap ve zaman� s�f�rla
        currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
        SwitchToPosition(currentPositionIndex);
        lastKeyPressTime = Time.time;
    }

    private void SwitchToPosition(int index)
    {
        // Kameray� belirtilen konuma ta��y�n (Lerp ile)
        if (index >= 0 && index < positions.Length)
        {
            targetPosition = positions[index].position;
            targetRotation = positions[index].rotation;
        }
    }

}
