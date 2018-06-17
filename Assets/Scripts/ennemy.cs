using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ennemy {
	public string nameOfTheEnnemy;
	public Sprite sprite;
	public int health;
	public int points;
	public abstract void HowToKill();
}
