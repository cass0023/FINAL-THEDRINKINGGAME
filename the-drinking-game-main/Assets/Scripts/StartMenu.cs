using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour

{ 
    public Button button;
    public Sprite newButtonImage;
    public void StartGame()
    {
        //changing scene
        SceneManager.LoadScene("SampleScene"); 
    }
    //swithcing from start bone to broken bone 
    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;
    }
}

