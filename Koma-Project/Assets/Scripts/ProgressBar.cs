using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public static int stage = 0;
    public Transform[] stagePosition=new Transform[6];

    public float speed = 5f;

    private float journeyLength;
    private float startTime;

    private void Update()
    {
        goToNextStage();
    }
    public void goToNextStage()
    {
        float currentTime = Time.time - startTime;

        // Hareketin yüzdesini hesapla (0 ile 1 arasýnda)
        float journeyPercentage = currentTime * speed / journeyLength;

        // Ýki nokta arasýndaki konumu hesapla ve objeyi taþý
        transform.position = Vector3.Lerp(transform.position, stagePosition[stage].position, journeyPercentage);

        // Eðer hareket tamamlandýysa, objeyi B noktasýna sabitle
        if (journeyPercentage >= 1f)
        {
            transform.position = stagePosition[stage].position;
        }
    }
}
