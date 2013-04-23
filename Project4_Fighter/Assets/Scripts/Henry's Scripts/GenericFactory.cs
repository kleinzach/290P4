using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//A Generic Factory, to be held in the Factory Manager
public class GenericFactory : MonoBehaviour{
	
	public GameObject product = GameObject.CreatePrimitive(PrimitiveType.Cube);
	public float delay = 1;
	private float recycleTimer = 1;
	
	private List<GameObject> aliveList, deadList;
	
	void Start () {
		aliveList = new List<GameObject>();
		deadList = new List<GameObject>();
	}
	
	public GenericFactory(GameObject toProduce, float recycleDelay){
		this.product = toProduce;
		this.delay = recycleDelay;
	}
	
	//Creates and returns the product.
	public GameObject create(){
			
		GameObject newItem;
		if (deadList.Count < 1) {
			newItem = (GameObject)UnityEngine.Object.Instantiate(product, Vector3.zero, Quaternion.identity);
		} else {
			newItem = deadList[0];
			deadList.RemoveAt(0);
			newItem.SetActive(true);
		}
		aliveList.Add(newItem);

		
		return newItem;
	}
	
	/// <summary>
	/// Recycle now dead objects after the specified delay.
	/// </summary>
	/// <param name='delay'>
	/// The Delay between sweeps.
	/// </param>
	/// 

	void Update () {
		recycleTimer -= Time.deltaTime;
		if (recycleTimer < 0) {
			recycleTimer = delay;
			for (int i = aliveList.Count-1; i >= 0; i--) {
				if (!aliveList[i].activeSelf) {
					deadList.Add(aliveList[i]);
					aliveList.RemoveAt(i);
				}
			}
		}
	}
}
