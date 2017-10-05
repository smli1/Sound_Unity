using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioMixerSnapshot m_gamemode;

    [SerializeField]
    private AudioMixerSnapshot m_menumode;

    public void MenuMode()
    {
        m_menumode.TransitionTo(0.5f);
    }

    public void GameMode()
    {
        m_gamemode.TransitionTo(0.5f);
    }
}
