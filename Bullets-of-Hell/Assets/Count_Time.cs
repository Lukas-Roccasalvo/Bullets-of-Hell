using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count_Time : MonoBehaviour
{

    TextMeshPro tmp;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Singelton.getInstance().running)
        {
            return;
        }
        time += Time.deltaTime;

        tmp.text = Mathf.Round(time) + "s";
    }
}
