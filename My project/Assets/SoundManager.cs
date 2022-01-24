using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        BackgroundStreet,
        FootSteps,
        Desinfection,
        OpenWindow,
        OpenDoor,
        CloseDoor
    }

    public enum Voice
    {
        oro,
        kyle
    }
    

    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public AudioSource audioSource;
    public SoundAudioClip[] soundAudioClipArray;
    public VoiceAudioClip[] voiceAudioClipsArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;

    }
    [System.Serializable]
    public class VoiceAudioClip
    {
        public SoundManager.Voice voice;
        public List<AudioClip> audioClipList;

    }

    // Get AudioClip from Manager
    private AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + "not found!!!");
        return null;
    }
    

    
    // Play 3D sound based on object position
    public void PlaySound(Sound sound)
    {
        if (!audioSource.isPlaying)
        {

            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
            
        }

    }
    
 
    // play Voice Recording
    private AudioClip VoiceGetAudioClip(Voice voice, int num)
    {
        foreach (VoiceAudioClip voiceAudioClip in voiceAudioClipsArray)
        {
            if (voiceAudioClip.voice == voice)
            {
                List<AudioClip> temp = voiceAudioClip.audioClipList;
                return temp[num];
            }
        }
        Debug.LogError("Sound" + voice + "not found!!!");
        return null;
    }
    public void PlayVoice(Voice voice, int num)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = VoiceGetAudioClip(voice, num);
            audioSource.Play(); 
        }


    }
}
