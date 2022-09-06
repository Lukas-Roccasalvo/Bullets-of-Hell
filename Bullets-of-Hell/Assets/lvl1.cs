using UnityEngine;

public class lvl1 : MonoBehaviour
{
    //hallo
    public int checkpointGoal;
    public float timeLimit;
    [SerializeField] GameObject endScreen;
    
    

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level1"))
            PlayerPrefs.SetInt("Level1", 0b000);
        print(PlayerPrefs.GetInt("Level1")+" ");
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
                            if (Singelton.getInstance().health >= 3 || ((PlayerPrefs.GetInt("Level1", 0b000) & 0b100) == 0b100))
                            {
                                tt.gameObject.SetActive(true);
                                PlayerPrefs.SetInt("Level1", PlayerPrefs.GetInt("Level1") | 0b100);
                            }
                            break;
                        case 1:
                            if (!Singelton.getInstance().usedAbility || ((PlayerPrefs.GetInt("Level1", 0b000) & 0b010) == 0b010))
                            {
                                tt.gameObject.SetActive(true);
                                PlayerPrefs.SetInt("Level1", PlayerPrefs.GetInt("Level1") | 0b010);
                            }
                            break;
                        case 2:
                            if (Singelton.getInstance().softTime < timeLimit || ((PlayerPrefs.GetInt("Level1", 0b000) & 0b001) == 0b001))
                            {
                                tt.gameObject.SetActive(true);
                                PlayerPrefs.SetInt("Level1", PlayerPrefs.GetInt("Level1") | 0b001);
                            }
                            break;
                        default:
                            break;
                    }
                }
     
            break;
            }
            
            PlayerPrefs.Save();

        }
    }
}


