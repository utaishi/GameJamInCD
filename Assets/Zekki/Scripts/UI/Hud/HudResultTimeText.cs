using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Zekki.UI.Hud
{
    [RequireComponent(typeof(Text))]
    public class HudResultTimeText : MonoBehaviour
    {
        [Header("Required")]
        [SerializeField] Buffer.TimeBuffer m_TimeBuffer;

        [Header("Settings")]
        [SerializeField] string m_PreText;
        [SerializeField] string m_PostText;

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
            Debug.Assert(m_Text != null);

            if (m_TimeBuffer.GetBufferedMinute() == 0)
            {
                m_Text.text = m_PreText + m_TimeBuffer.GetBufferedSecond().ToString() + "秒" + m_PostText;
            }
            else
            {
                m_Text.text = m_PreText + m_TimeBuffer.GetBufferedMinute().ToString() + "分" + m_TimeBuffer.GetBufferedSecond().ToString() + "秒" + m_PostText;
            }
        }
    }
}