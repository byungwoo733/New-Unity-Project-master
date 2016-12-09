using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {


	public GameObject itemObj = null;
	public Hashtable table = null;
	ItemList list;
	public GameObject []mItem;


	// Use this for initialization
	void Start () {
		//Debug.Log ("1111111111111");
		list = GameObject.Find ("ItemList").GetComponent<ItemList> ();
		//mItem1 = GameObject.Find ("Item1");
		table = list.table;

		for (int i = 0; i < 3; i++) 
		{
			Item item = (Item)table ["food" + (i + 1)];
			//mItem[i].GetComponentInChildren<Text> ().text = item.name;
			mItem[i].GetComponentInChildren<Text> ().text = item.name;

			//print(item.name);
//			Item eatItem = table.Contains (i);
//			string eatName = eatItem.name;
//			print(eatName);
//
//			GameObject obj = Instantiate (itemObj);
//
//			obj.transform.SetParent (transform, false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
