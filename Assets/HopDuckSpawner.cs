using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopDuckSpawner : MonoBehaviour
{
    public GameObject Duck;

    public float SpawnRate;
    public float CurrentPoint;
    
    public float PresentSpawnRate;
    public float CurrentPresentPoint;

    public AudioClip Drop;
    public AudioSource AudioLocation;
    public GameObject Present;
    // Update is called once per frame
    void Update()
    {
        CurrentPresentPoint += Time.deltaTime;
        CurrentPoint += Time.deltaTime;
        if(CurrentPoint >= SpawnRate)
        {
            CurrentPoint = 0;
            Instantiate(Duck).transform.position = this.transform.position;
        }
        if(Input.GetMouseButton(0))
        {
            
            if (CurrentPresentPoint >= PresentSpawnRate)
            {
                CurrentPresentPoint = 0;
                float X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                float Y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                GameObject p = Instantiate(Present);
                p.transform.position = new Vector3(X, Y, 0);
                AudioLocation.PlayOneShot(Drop);

            }

        }
    }
}
