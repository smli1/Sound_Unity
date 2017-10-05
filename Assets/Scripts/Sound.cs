using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    private int m_qSamples = 1024;        // array size - number of samples
    private float m_rmsValue;             // sound level - RMS (root mean squared)
    [SerializeField]
    private float m_scaleSample = 2.0f;   // set how much the scale will vary

    private AudioSource m_source;         //audio source

    private float[] m_samples;            //the array - samples we're getting

    private float m_scaleY = 0;           //original scale on y
    private float fov;

    [SerializeField]
    private GameObject e;   // set how much the scale will vary

    [SerializeField]
    private Mesh[] m;
    // Use this for initialization
    void Start()
    {
        m_source = GetComponent<AudioSource>(); //refernce to audio source
        m_samples = new float[m_qSamples];      //initialise the array of samples
        m_scaleY = transform.localScale.y;      //get the original scale of the object
        fov = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound(); //we analyse the sound

        //we scale the object on y based on m_rmsValue
        Vector3 scale = transform.localScale;
        scale.y = m_scaleY + m_scaleSample * m_rmsValue;
        scale.z = m_scaleY - m_scaleSample * m_rmsValue;
        Debug.Log(""+scale.y);
        if(Camera.main)Camera.main.fieldOfView = fov + scale.y * 10 - 1;
        transform.localScale = scale;

        Vector3 pos = new Vector3(0, transform.localScale.y * 0.5f, 0);
        StartCoroutine(getObject(scale.y,scale.y-1));
        transform.position = pos;
       
    }

    /// <summary>
    /// we analyze the sound and we assign a value to m_rmsValue
    /// </summary>
    private void AnalyzeSound()
    {
        m_source.GetOutputData(m_samples, 0); //we get some samples 

        float sum = 0;

        for (int i = 0; i < m_samples.Length; i++)
        {
            sum += m_samples[i] * m_samples[i]; //sum squared samples
        }

        //formula for sound level
        m_rmsValue = Mathf.Sqrt(sum / m_qSamples);
    }

    IEnumerator getObject(float time, float y)
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < (int)(y*100); i++) {
            GameObject g = Instantiate(e, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<MeshFilter>().mesh = m[(int)((y * 10) % 3)];
            g.transform.localScale = new Vector3(y / 2.0f, y / 2.0f, y / 2.0f);
            g.GetComponent<MeshRenderer>().material.color = new Color((int)(y * 10) % 3 == 0 ? y : 0, (int)(y * 10) % 3 == 1 ? y : 0, (int)(y * 10) % 3 == 2 ? y : 0);
        }
    }
}
