using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zekki.Event
{
    public abstract class EventBase : MonoBehaviour
    {
        [SerializeField] bool m_ExecuteOnAwake = true;

        private void Awake()
        {
            if (m_ExecuteOnAwake) Execute();
        }

        public abstract void Execute();
    }
}