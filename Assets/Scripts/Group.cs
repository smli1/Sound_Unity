using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Group : MonoBehaviour
{
    private CanvasGroup m_group;

    public AudioMixer audioMixer;

    private SoundManager m_soundManager;
    // Use this for initialization
    void Start ()
    {
        m_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        m_group = GetComponent<CanvasGroup>();

        m_group.alpha = 0;
	}

    public void SetAmbientVolume(float _volume)
    {
        audioMixer.SetFloat("AmbientVolume", _volume);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(m_group.alpha == 0)
            {
                m_group.alpha = 1;
                m_soundManager.MenuMode();
            }
            else
            {
                m_group.alpha = 0;
                m_soundManager.GameMode();
            }
        }
	}
}
