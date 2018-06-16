using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName="Objects/Bullet")]
public class bullet : ScriptableObject {

	public Sprite sprite;
	public float speed;
	public int damage;
	public float rate;
}
