using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zekki
{
    public class ChangeSceneUeta : MonoBehaviour
    {
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeNextScene()
        {
            Debug.Log("GotoHelp");
            SceneManager.LoadScene("Help");
        }

        public void ChangeAnyScene(string scene)
        {
            Debug.Log("Goto"+scene);
            SceneManager.LoadScene(scene);
        }
    }
}
