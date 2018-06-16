using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName="Objects/Building")]
public class building : ScriptableObject {

	public string nameOfTheBuilding;
	public int points;
	public Sprite destroyed;
	public Sprite alive;
	
}
