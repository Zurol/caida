using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        m_initialSpeed = 0;
        m_finalHeight = 0;
        m_initialPosition = transform.position.y;
        m_deltaX = Mathf.Abs( (0 - transform.position.y));

        Debug.Log("DX: " + m_deltaX);

        m_initialHeight = m_initialPosition - m_finalHeight;
        m_finalSpeed = Mathf.Sqrt( 2 * m_gravity * m_deltaX );
        Debug.Log("FS: " + m_finalSpeed);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // if falling
        Debug.Log("SP:" + m_finalSpeed + " |||| H: " + m_initialHeight);
        if (m_finalSpeed > 0 && m_initialHeight > 0) {
            Debug.Log("Falling");

            transform.position += new Vector3(0, -1, 0) * m_finalSpeed * Time.fixedDeltaTime;
        } else if (m_finalSpeed < 0)
        {
            Debug.Log("going Up");

            //transform.position += new Vector3(0, 1, 0) * m_finalSpeed * Time.fixedDeltaTime;
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
