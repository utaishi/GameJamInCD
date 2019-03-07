using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Zekki.Save
{
    [CreateAssetMenu(menuName = "Save/SaveHandler", fileName = "SaveHandler")]
    public class SaveHandler : ScriptableObject
    {
        [Header("Required")]
        [SerializeField] Profile.HighScoreProfile m_HighScoreProfile;

        [Header("Settings")]
        [SerializeField] string m_DefaultSaveDirectory = "SaveData";
        [SerializeField] string m_SaveFileName_HighScoreSec = "HighScoreSec";

        /// <summary>
        /// セーブ可能なデータを対象のパスに保存します。
        /// </summary>
        public void Save()
        {
            Debug.Assert(m_HighScoreProfile != null);
            ES2.Save(m_HighScoreProfile.HighScoreSec, m_SaveFileName_HighScoreSec);
#if UNITY_EDITOR
            Debug.Log("Saved.");
#endif
        }

        /// <summary>
        /// 対象のパスにセーブされているデータを復元します。
        /// </summary>
        public void Load()
        {
            Debug.Assert(m_HighScoreProfile != null);
            m_HighScoreProfile.HighScoreSec = ES2.Load<float>(m_SaveFileName_HighScoreSec);
#if UNITY_EDITOR
            Debug.Log("Loaded.");
#endif
        }
    }
}