using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionCanvas;
    void Start()
    {
        menuCanvas.SetActive(true);
        optionCanvas.SetActive(false);
    }
    public void PlayBut()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OptionBut()
    {
        optionCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void BackBut()
    {
        optionCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
    public void ExitBut()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
