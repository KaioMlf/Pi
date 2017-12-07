using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    private  PlayerMotor tempor;
    GameObject ThePlayer;

    public AudioClip goodItemSound;



	// Use this for initialization
	void Start () {
        
        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        tempor = ThePlayer.GetComponent<PlayerMotor>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(goodItemSound);
            StartCoroutine("WaitForIt");
            tempor.timer += 5.0f;
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Waited");
        Destroy(this.gameObject);
    }
}
