using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMake : MonoBehaviour
{
    public GameObject Background;
    public float timeDiff;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            GameObject newVine = Instantiate(Background);
            newVine.transform.position = new Vector3(6, -0.02f, 0);
            timer = 0;
            Destroy(newVine, 6);
        }        
    }
}
