using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1 : MonoBehaviour
{

    public int checkpointGoal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Singelton.getInstance().score >= checkpointGoal)
        {
            //todo end screen
            Singelton.getInstance().score = 0;
            Singelton.getInstance().health = 3;
            Singelton.getInstance().running = true;
            SceneManager.LoadScene(1);
        }
    }
}
