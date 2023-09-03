using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int age = 25;
    public Sprite[] PPhoto=new Sprite[10];
    private int imageCount = 0;
    public Image currentImage;
    public TMP_Text ageText;
    private GameObject currentCamera;
    public RectTransform centerPose;
    public AudioSource hearthAudioSource;
    public AudioClip  hearthAudioClip;
    public AudioClip winSound;
    public GameObject eyesOBJ;

    private bool stopAge = false;
    private void Start()
    {
        currentCamera = gameObject;
        currentImage.sprite = PPhoto[imageCount];
        imageCount++;
        StartCoroutine(AgeIncreaser());
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            age = 99;
        }
    }
    IEnumerator AgeIncreaser()
    {
        while (age<=100&& stopAge==false)
        {
            yield return new WaitForSeconds(3f);
            age++;
            ageText.text = age.ToString();
            if ((age-5)%10==0)
            {
                currentImage.sprite = PPhoto[imageCount];
                imageCount++;
            }
            if (age==100)
            {
                currentImage.transform.parent.transform.position = centerPose.transform.position;
                currentImage.transform.parent.transform.localScale = currentImage.transform.parent.transform.localScale * 3f;
                hearthAudioSource.PlayOneShot(hearthAudioClip);
                Invoke("Firstpic", 1);
            }
        }
    }
    public void Firstpic()
    {
        currentImage.sprite = PPhoto[8];
        Invoke("Secondpic", 3);
    }
    public void Secondpic()
    {
        currentImage.sprite = PPhoto[9];
    }
    public void Win()
    {
        currentImage.transform.parent.transform.position = centerPose.transform.position;
        currentImage.transform.parent.transform.localScale = currentImage.transform.parent.transform.localScale * 3f;
        stopAge = true;
        hearthAudioSource.PlayOneShot(winSound);
        eyesOBJ.SetActive(true);
    }
}
