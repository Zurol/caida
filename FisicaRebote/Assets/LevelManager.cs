using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject m_prefab;
    GameObject m_spawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_spawned = Instantiate(m_prefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.R))
		{
            OnResetButton();

        }
    }
    public void OnResetButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
