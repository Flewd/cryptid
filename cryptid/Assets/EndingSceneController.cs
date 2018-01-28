using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingSceneController : MonoBehaviour {

    [SerializeField]
    Sprite[] images;

    [SerializeField]
    Image ImageFrame;

    int indexOfImage = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            indexOfImage += 1;
        }

        if(indexOfImage >= images.Length)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            ImageFrame.sprite = images[indexOfImage];
        }
        


    }
}
