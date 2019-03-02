using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zekki.Event
{
    public class SceneChangeEvent : EventBase
    {
        [SerializeField] string m_NextScene;

        public override void Execute()
        {
            if (m_NextScene == "") throw new System.Exception("The name of next scene is null.");

            SceneManager.LoadScene(m_NextScene);
        }
    }
}