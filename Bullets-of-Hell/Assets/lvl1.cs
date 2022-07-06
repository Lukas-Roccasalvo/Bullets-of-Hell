using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1 : MonoBehaviour
{

    public int checkpointGoal;
    public float timeLimit;
    [SerializeField] GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Singelton.getInstance().softTime += Time.deltaTime;
        if(Singelton.getInstance().score >= checkpointGoal)
        {
            endScreen.SetActive(true);
            foreach(Transform t in endScreen.transform)
            {
                foreach (Transform tt in t.transform)
                {
                    switch (tt.GetSiblingIndex())
                    {
                        case 0:
                            if(Singelton.getInstance().health >= 3)
                            {
                                tt.gameObject.SetActive(true);
                            }
                            break;
                        case 1:
                            if(!Singelton.getInstance().usedAbility) {
                                tt.gameObject.SetActive(true);
                            }
                            break;
                        case 2:
                            if (Singelton.getInstance().softTime < timeLimit)
                            {
                                tt.gameObject.SetActive(true);
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            }

            
        }
    }
}
