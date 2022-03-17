using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMake : MonoBehaviour
{
    public GameObject Ground;
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
            GameObject newVine = Instantiate(Ground);
            newVine.transform.position = new Vector3(3.38f, Random.Range(-1.5f, -0.54f) ,0);
            timer = 0;
            Destroy(newVine, 11);
        }
        
    }
}
