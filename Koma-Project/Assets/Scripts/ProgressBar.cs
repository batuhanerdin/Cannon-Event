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

        // Hareketin y�zdesini hesapla (0 ile 1 aras�nda)
        float journeyPercentage = currentTime * speed / journeyLength;

        // �ki nokta aras�ndaki konumu hesapla ve objeyi ta��
        transform.position = Vector3.Lerp(transform.position, stagePosition[stage].position, journeyPercentage);

        // E�er hareket tamamland�ysa, objeyi B noktas�na sabitle
        if (journeyPercentage >= 1f)
        {
            transform.position = stagePosition[stage].position;
        }
    }
}
