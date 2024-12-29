using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HopDuck : MonoBehaviour
{
    public float speed;

    public float SpeedVariation;

    public Rigidbody2D rb2d;
    public GameObject Presnt;
    public GameObject Presnt2;
    public GameObject Presnt3;

    public AudioClip Catch;
    public AudioSource AudioLocation;

    public int PresentsWanted;
    public TextMesh text;
    public void Start()
    {
        AudioLocation = FindObjectOfType<AudioSource>();
        speed += UnityEngine.Random.Range(-SpeedVariation, SpeedVariation);
        PresentsWanted = UnityEngine.Random.Range(1,4);
        text.text = PresentsWanted.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(-speed, 0);
        if (Presnt != null)
        {
            Presnt.transform.position = this.gameObject.transform.position + new Vector3(0, 0.5f, 0);
        }
        if (Presnt2 != null)
        {
            Presnt2.transform.position = this.gameObject.transform.position + new Vector3(0, 1, 0);
        } 
        if (Presnt3 != null)
        {
            Presnt3.transform.position = this.gameObject.transform.position + new Vector3(0, 1.5f, 0);
        }
        if(transform.position.x <= -10)
        {
            if (Presnt == null && PresentsWanted == 1)
            {
                SceneManager.LoadScene(0);
            } 
            if (Presnt2 == null && PresentsWanted == 2)
            {
                SceneManager.LoadScene(0);
            }   
            if (Presnt3 == null && PresentsWanted == 3)
            {
                SceneManager.LoadScene(0);
            }
            FindObjectOfType<Score>().CurrentScore += 1;
            Destroy(this.gameObject);
        }
    }
    public IEnumerator DropPause()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Present>().Heald == true)
        {
            return;
        }
        if (Presnt == null)
        {
            Presnt = collision.gameObject;
            Presnt.GetComponent<Present>().Heald = true;
            collision.gameObject.layer = 0;
            AudioLocation.PlayOneShot(Catch);
        } 
        else if (Presnt2 == null && PresentsWanted > 1)
        {
            Presnt2 = collision.gameObject;
            Presnt2.GetComponent<Present>().Heald = true;
            AudioLocation.PlayOneShot(Catch);
            collision.gameObject.layer = 0;
        } 
        else if (Presnt3 == null && PresentsWanted > 2)
        {
            Presnt3 = collision.gameObject;
            Presnt3.GetComponent<Present>().Heald = true;
            collision.gameObject.layer = 0;
            AudioLocation.PlayOneShot(Catch);
        }
        else
        {
            StartCoroutine(DropPause());
            if(Presnt != null)
            {
                Presnt.GetComponent<Rigidbody2D>().velocity = new Vector2(0,9);
                Presnt.GetComponent<Present>().Heald = false;
                Presnt.layer = 10;
                Presnt = null;
            }
            if(Presnt2 != null)
            {
                Presnt2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
                Presnt2.GetComponent<Present>().Heald = false;
                Presnt2.layer = 10;
                Presnt2 = null;
            }
            if(Presnt3 != null)
            {
                Presnt3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 11);
                Presnt3.GetComponent<Present>().Heald = false;
                Presnt3.layer = 10;
                Presnt3 = null;
            }         
            Destroy(collision.gameObject);
        }

    }

}
