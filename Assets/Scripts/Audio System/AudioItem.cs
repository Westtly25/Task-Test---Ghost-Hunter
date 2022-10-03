using System;
using UnityEngine;

namespace Assets.Scripts.Audio_System
{
    [Serializable]
    public class AudioItem
    {
        [SerializeField] private AudioItemType audioType;
        [SerializeField] private AudioClip audioClip;

        public AudioItemType AudioType => audioType;
        public AudioClip AudioClip => audioClip;
    }
}