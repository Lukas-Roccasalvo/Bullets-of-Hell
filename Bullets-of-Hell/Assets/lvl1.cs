using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1 : MonoBehaviour
{

    public int checkpointGoal;
    [SerializeField] GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Singelton.getInstance().score >= checkpointGoal)
        {
            endScreen.SetActive(true);
            foreach(Transform t in endScreen.transform)
            {
                foreach (Transform tt in t.transform)
                {
                    tt.gameObject.SetActive(Random.value > 0.5f);
                }
                break;
            }
                
            Singelton.getInstance().score = 0;
            Singelton.getInstance().health = 3;
            Singelton.getInstance().running = true;
            
        }
    }
}
