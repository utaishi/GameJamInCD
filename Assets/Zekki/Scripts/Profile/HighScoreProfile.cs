using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Zekki.Profile
{
    [CreateAssetMenu(menuName = "Profile/HighScoreProfile", fileName = "HighScoreProfile")]
    public class HighScoreProfile : ScriptableObject
    {
        [SerializeField] float m_HighScoreSec;
        public float HighScoreSec
        {
            get { return m_HighScoreSec; }
            set { m_HighScoreSec = value; }
        }

        public void Initialize()
        {
            m_HighScoreSec = 0f;
        }
    }
}