using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{

    public int m_delayFrame;
    int m_delayCounter = 0;
    float m_gravity = 9.8f;
    
    float m_initialSpeed;
    float m_finalSpeed;

    float m_deltaX;


    float m_initialPosition;
    float m_finalPosition;

    float m_initialHeight;
    float m_finalHeight;

    bool is_falling;

    public GameObject m_print;
    GameObject m_spawned;

    public float m_energyLoss;
    public int m_bounces;

    // Start is called before the first frame update
    void Start()
    {
        m_initialSpeed = 0;
        m_finalHeight = 0;
        is_falling = true;
        m_initialPosition = transform.position.y;
        m_deltaX = Mathf.Abs( (0 - transform.position.y));

        Debug.Log("DX: " + m_deltaX);

        m_initialHeight = m_initialPosition - m_finalHeight;
        m_finalSpeed = Mathf.Sqrt( 2 * m_gravity * m_deltaX );
        Debug.Log("FS: " + m_finalSpeed);
        m_spawned = Instantiate(m_print, transform.position, Quaternion.identity);

        if (m_spawned.GetComponentInChildren<TextMeshProUGUI>()) {
            m_spawned.GetComponentInChildren<TextMeshProUGUI>().text = "H: " + transform.position.y.ToString("#.00") + "  || V=" + m_finalSpeed.ToString("#.00") + " m/s";
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // if falling
        
        if (m_finalSpeed > 0 && transform.position.y > 0 && is_falling) {
            Debug.Log("Falling");

            transform.position += new Vector3(0, -1, 0) * m_finalSpeed * Time.fixedDeltaTime;

            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
                is_falling = false;
                m_finalHeight = ( (m_finalSpeed * m_energyLoss) * (m_finalSpeed * m_energyLoss)) / ( 2 * m_gravity);
                m_finalSpeed = Mathf.Sqrt( 2 * m_gravity * m_finalHeight );
            }
        } else if (m_finalSpeed > 0 && transform.position.y < m_finalHeight && !is_falling)
        {
            Debug.Log("SP:" + m_finalSpeed + " |||| H: " + m_initialHeight);
            //transform.position = new Vector3(transform.position.x, 0, 0);

            transform.position += new Vector3(0, 1, 0) * m_finalSpeed * Time.fixedDeltaTime;

            if (transform.position.y >= m_finalHeight) {
                is_falling = true;
                m_spawned = Instantiate(m_print, transform.position, Quaternion.identity);
                m_finalHeight = ((m_finalSpeed * m_energyLoss) * (m_finalSpeed * m_energyLoss)) / (2 * m_gravity);

                if (m_spawned.GetComponentInChildren<TextMeshProUGUI>())
                {
                    m_spawned.GetComponentInChildren<TextMeshProUGUI>().text = "H: " + transform.position.y.ToString("#.00") + "  || V=" + m_finalSpeed.ToString("#.00") + " m/s";
                }
            }
        }
  

        /*
        if (transform.position.y > 0)
        {
            if (m_delayFrame < m_delayCounter)
            {
                transform.position += new Vector3(0, 1, 0) * m_finalSpeed * Time.fixedDeltaTime;
                m_delayCounter = 0;
            }
            else
            {
                m_delayCounter++;
            }
        }
        else {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }*/

        //Debug.Log("T" + Time.realtimeSinceStartup + "||||  SP:" + m_finalSpeed);
        
	}

	public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        
        //m_initialSpeed = m_finalSpeed;
        //m_finalSpeed = - ( m_initialSpeed * m_initialSpeed) / 2 * m_gravity;
    }
}
