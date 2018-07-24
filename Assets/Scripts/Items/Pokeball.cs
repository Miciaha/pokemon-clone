using UnityEngine;
using System.Collections;

public class Pokeball : MonoBehaviour {

    public int ID { get; set; }
    public string Name { get; set; }
    public float CaptureRate { get; set; }
    public string Description { get; set; }



    /* Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    */

    public Pokeball(int id, string name, float captureRate, string description) {
        ID = id;
        Name = name;
        CaptureRate = captureRate;
        Description = description;
    }

}
