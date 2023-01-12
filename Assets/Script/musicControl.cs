using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musicControl : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource music;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        musicSlider.value = music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.titlePageActive)
        {
            music.volume = musicSlider.value;
        }
    }
}
