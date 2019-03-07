using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Zekki.Buffer
{
    [CreateAssetMenu(menuName = "Buffer/TimeBuffer", fileName = "TimeBuffer")]
    public class TimeBuffer : ScriptableObject
    {
        [SerializeField] float m_BufferedTimeSec;
        public float BufferedTimeSec
        {
            get { return m_BufferedTimeSec; }
            set { m_BufferedTimeSec = value; }
        }

        public void Initialize()
        {
            m_BufferedTimeSec = 0f;
        }

        /// <summary>
        /// バッファに記録されているタイムの分針部分の値を返します。
        /// 小数点以下は切り捨てられます。
        /// </summary>
        /// <returns></returns>
        public int GetBufferedMinute()
        {
            return (int)(m_BufferedTimeSec / 60f);
        }

        /// <summary>
        /// バッファに記録されているタイムの秒針部分の値を返します。
        /// 小数点以下は切り捨てられます。
        /// </summary>
        /// <returns></returns>
        public int GetBufferedSecond()
        {
            return (int)(m_BufferedTimeSec - GetBufferedMinute() * 60f);
        }
    }
}