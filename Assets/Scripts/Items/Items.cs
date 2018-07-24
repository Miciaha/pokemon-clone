using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {
    public int ID { get; set; }
    public string Name { get; set; }
    public string NamePlural { get; set; }

	/* Use this for initialization
	void Start () {
	
	}
	*/

	// Update is called once per frame
	void Update () {
	
	}

    public Items(int id, string name, string namePlural)
    {
        ID = id;
        Name = name;
        NamePlural = NamePlural;
    }
}
