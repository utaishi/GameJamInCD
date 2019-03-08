using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultChangeScene : MonoBehaviour {
    [SerializeField] private GameObject retryz;
    [SerializeField] private GameObject titlez;
    [SerializeField] private GameObject retryObject;
    [SerializeField] private GameObject titleObject;

    private bool isUp = true;
    private AudioSource cursorSound;
	// Use this for initialization
	void Start () {
        cursorSound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isUp)
            {
                ChengeZekkiPos();
                isUp = true;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isUp)
            {
                ChengeZekkiPos();
                isUp = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimerOnRhythmPart.time = TimerOnRhythmPart.setTime;
            if (isUp)
            {
                retryObject.SetActive(true);
            }
            else
            {
                titleObject.SetActive(true);
            }
        }
	}

    private void ChengeZekkiPos()
    {
        cursorSound.PlayOneShot(cursorSound.clip);
        retryz.SetActive(!retryz.activeSelf);
        titlez.SetActive(!titlez.activeSelf);
    }
}
