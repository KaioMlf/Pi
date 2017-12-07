using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadFood : MonoBehaviour {

    private PlayerMotor timer;
    GameObject player;
    public AudioClip badItemSound;


    public Score scoreScript;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = player.GetComponent<PlayerMotor>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(badItemSound);
            timer.timer -=5.0f;
            StartCoroutine("WaitForIt");
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Waited");
        Destroy(this.gameObject);
    }
}
