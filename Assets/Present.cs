using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public bool Heald;
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
