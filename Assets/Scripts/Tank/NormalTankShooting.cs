using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTankShooting : MonoBehaviour
{
    public GameObject m_Shell;
    public Transform[] m_FireTransform;
    public int m_PlayerNumber;
    public float m_fireRate;
    public AudioSource m_FireClip;

    private float m_NextFire;
    private string m_FireButton;
    

    void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;
    }

    void Update()
    {
        if (Input.GetButton(m_FireButton) && Time.time > m_NextFire) 
        {
            m_NextFire = Time.time + m_fireRate;
            for (int i = 0; i < m_FireTransform.Length; i++)
            {
                GameObject Instant= Instantiate(m_Shell, m_FireTransform[i].position, m_FireTransform[i].rotation);
                Instant.GetComponent<NormalBullets>().m_Tag = this.tag;
            }
            m_FireClip.Play();
        }
    }
}
