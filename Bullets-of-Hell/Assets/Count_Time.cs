using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count_Time : MonoBehaviour
{

    TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = Mathf.Round(Time.time) + "s";
    }
}
