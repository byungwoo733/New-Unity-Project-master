using UnityEngine;
using System.Collections;


public class Item
{

	public string name;
	public int price;
	public int eff;
	public int count;

	public Item (string name, int price, int eff, int count)
	{
		this.name = name;
		this.price = price;
		this.eff = eff;
		this.count = count;
	}


}



public class ItemList : MonoBehaviour{

	public Hashtable table = new Hashtable();

	// Use this for initialization
	void Start () {
		//Item food1 = new Item ("f1", 2, 0, 0);


		table.Add ("food1", new Item ("고급간식1", 1, 0, 0));
		table.Add ("food2", new Item ("고급간식2", 2, 0, 0));
		table.Add ("food3", new Item ("고급캔1", 3, 0, 0));


		//Item a = table ["food1"] as Item;
		//print (a.name);

	
		/*
		foreach (Item v in table.Values) 
		{
			//Item i = v as Item;
			print (v.name);
		}

*/
	}

	public Hashtable getTable(){
	
		return table;
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
