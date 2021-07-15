using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullets : MonoBehaviour
{

    public float m_speed;
    public int m_damage;
    public float m_lifeTime;

    [HideInInspector]
    public string m_Tag;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * m_speed;
        Destroy(this.gameObject, m_lifeTime);
    }

    private void FixedUpdate()
    {
        //transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
    void OnCollisionEnter(Collision other)
    {

        if (m_Tag!=null && other.gameObject.CompareTag(m_Tag))
            return;

        TankHealth TankHealth = other.gameObject.GetComponent<TankHealth>();
        if (TankHealth)
        {
            TankHealth.TakeDamage(m_damage);
        }
        
        Destroy(gameObject);
    }
}
