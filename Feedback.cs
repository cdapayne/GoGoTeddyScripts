using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour {

    public AudioSource voice;

    public Feedback(AudioSource vc)
    {
        voice = vc;
    }
    public IEnumerator PlayCorrectResponse()
    {
        //build for up to six
        int rnd = Random.Range(0, 7);
        int rnd2 = Random.Range(0, 7);
        Debug.Log(rnd);

     
       

        if (rnd.Equals(0))
        {
            AudioClip add = Resources.Load("right/thatsright") as AudioClip;
            voice.clip = add;
            Debug.Log("thastright");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(1))
        {
            AudioClip add = Resources.Load("right/yess") as AudioClip;
            voice.clip = add;
            Debug.Log("yess");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(2))
        {
            AudioClip add = Resources.Load("right/yess") as AudioClip;
            voice.clip = add;
            Debug.Log("yess");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(3))
        {
            AudioClip add = Resources.Load("right/fantastic") as AudioClip;
            voice.clip = add;
            Debug.Log("fantastic");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(4))
        {
            AudioClip add = Resources.Load("right/goodjob") as AudioClip;
            voice.clip = add;
            Debug.Log("goodjob");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(5))
        {
            AudioClip add = Resources.Load("right/yourdoinggreat") as AudioClip;
            voice.clip = add;
            Debug.Log("yourdoinggreat");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(6))
        {
            AudioClip add = Resources.Load("right/sensational") as AudioClip;
            voice.clip = add;
            Debug.Log("sensational");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(7))
        {
            AudioClip add = Resources.Load("right/youdidit") as AudioClip;
            voice.clip = add;
            Debug.Log("youdidit");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(8))
        {
            AudioClip add = Resources.Load("right/greatjob") as AudioClip;
            voice.clip = add;
            Debug.Log("greatjob");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }

        yield return new WaitForSeconds(voice.clip.length);
    }
    public IEnumerator PlayWrongResponse()
    {

        int rnd = Random.Range(0, 3);
        Debug.Log(rnd);

        if (rnd.Equals(0))
        {
            AudioClip add = Resources.Load("awwtryagain") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(1))
        {
            AudioClip add = Resources.Load("maybenexttime") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(2))
        {
            AudioClip add = Resources.Load("yourclose") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }

        yield return new WaitForSeconds(voice.clip.length);
    }

}
