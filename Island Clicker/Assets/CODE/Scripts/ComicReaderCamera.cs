using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicReaderCamera : MonoBehaviour
{
    float waitforseconds = 3;
    private void Update()
    {
        if (waitforseconds < 0)
        {
            if (transform.position.y > -50)
            {
                transform.Translate(new Vector3(0, -0.05f, 0));
            }
        }
        else waitforseconds -= Time.deltaTime;
        
    }

}
