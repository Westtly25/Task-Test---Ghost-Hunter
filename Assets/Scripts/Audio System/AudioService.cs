using System;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Assets.Scripts.Audio_System
{
    [Serializable]
    public class AudioService : IAudioService, IInitializable
    {
        [SerializeField] private AudioItem[] audioItems;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicAudioSource;
        [SerializeField] private AudioSource sfxAudioSource;

        public void Initialize()
        {
            PlayGameMusic();
        }

        public void PlayAudio(AudioItemType audioType)
        {
            AudioClip audioClip = GetAudioByType(audioType);

            if (audioClip == null) { return; }

            sfxAudioSource.loop = false;
            sfxAudioSource.volume = 1;
            sfxAudioSource.clip = audioClip;
            sfxAudioSource.Play();
        }

        private void PlayGameMusic()
        {
            AudioClip audioClip = GetAudioByType(AudioItemType.Music);

            if (audioClip == null) { return; }

            musicAudioSource.loop = true;
            musicAudioSource.volume = 1;
            musicAudioSource.clip = audioClip;
            musicAudioSource.Play();
        }

        private AudioClip GetAudioByType(AudioItemType audioType)
        {
            if (audioItems == null) { return null; }

            for (int i = 0; i < audioItems.Length; i++)
            {
                if (audioItems[i].AudioType == audioType)
                {
                    return audioItems[i].AudioClip;
                }
            }

            return null;
        }
    }
}