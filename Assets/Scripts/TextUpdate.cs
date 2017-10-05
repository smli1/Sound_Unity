using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    private Text m_text;

	// Use this for initialization
	void Start ()
    {
        m_text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	public void UpdateText(float _value)
    {
        int sliderVal =(int)( 100f - _value / -80f * 100f);

        m_text.text = sliderVal.ToString() + " %";
	}
}
