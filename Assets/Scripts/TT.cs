using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TT : MonoBehaviour
{
    public float speed;
    private Quaternion turnRotation;
    private float timer;

    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;

    void Start()
    {
        turnRotation = Quaternion.Euler(new Vector3(0f, Random.Range(-180f, 180f), 0f));
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        { // timer resets at 2, allowing .5 s to do the rotating
            turnRotation = Quaternion.Euler(new Vector3(0f, Random.Range(-180f, 180f), 0f));
            timer = 0f;

            Rigidbody shellInstanse = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstanse.velocity = Random.Range(15f, 30f) * m_FireTransform.forward;
            m_ShootingAudio.Play();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, turnRotation, Time.deltaTime * speed);
       
    }
}
