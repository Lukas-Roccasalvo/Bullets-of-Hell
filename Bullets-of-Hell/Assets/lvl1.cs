using UnityEngine;

public class lvl1 : MonoBehaviour
{
    //hallo
    public int checkpointGoal;
    public float timeLimit;
    [SerializeField] GameObject endScreen;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Singelton.getInstance().softTime += Time.deltaTime;
        if (Singelton.getInstance().score >= checkpointGoal)
        {
            endScreen.SetActive(true);
            Singelton.getInstance().running = false;
            
            foreach (Transform t in endScreen.transform)
            {
                foreach (Transform tt in t)
                {
                    switch (tt.GetSiblingIndex())
                    {

                        case 0:
                            if (Singelton.getInstance().health >= 3)
                            {
                                tt.gameObject.SetActive(true);
                                counter++;
                            }
                            break;
                        case 1:
                            if (!Singelton.getInstance().usedAbility)
                            {
                                tt.gameObject.SetActive(true);
                                counter++;
                            }
                            break;
                        case 2:
                            if (Singelton.getInstance().softTime < timeLimit)
                            {
                                tt.gameObject.SetActive(true);
                                counter++;
                            }
                            break;
                        default:
                            break;
                    }
                }
     
            break;
            }
            PlayerPrefs.SetInt("Score", counter);
            PlayerPrefs.Save();

        }
    }
}


