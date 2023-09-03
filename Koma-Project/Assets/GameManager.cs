using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int age = 25;
    public Sprite[] PPhoto=new Sprite[8];
    private int imageCount = 0;
    public Image currentImage;
    public TMP_Text ageText;
    private void Start()
    {
        currentImage.sprite = PPhoto[imageCount];
        imageCount++;
        StartCoroutine(AgeIncreaser());
        
    }
    IEnumerator AgeIncreaser()
    {

        while (age<=100)
        {
            yield return new WaitForSeconds(2f);
            age++;
            ageText.text = age.ToString();
            if ((age-5)%10==0)
            {
                currentImage.sprite = PPhoto[imageCount];
                imageCount++;
            }
        }

    }
}
