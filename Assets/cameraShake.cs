using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {
 
 
	public float shakeAmount;
	public float shakeDuration;
 
	//Readonly values...
	float shakePercentage;
	float startAmount;
	float startDuration;
 
	bool isRunning = false;	
 
	public bool smooth;
	public float smoothAmount = 5f;
  
	void ShakeCamera() {
 
		startAmount = shakeAmount;//Set default (start) values
		startDuration = shakeDuration;//Set default (start) values
 
		if (!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}
 
	public void ShakeCamera(float amount, float duration) {
 
		shakeAmount += amount;//Add to the current amount.
		startAmount = shakeAmount;//Reset the start amount, to determine percentage.
		shakeDuration += duration;//Add to the current time.
		startDuration = shakeDuration;//Reset the start time.
 
		if(!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}
 
 
	IEnumerator Shake() {
		isRunning = true;
 
		while (shakeDuration > 0.01f) {
			Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;
			rotationAmount.z = 0;
 
			shakePercentage = shakeDuration / startDuration;
 
			shakeAmount = startAmount * shakePercentage;
			shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);
 
 
			if(smooth)
				transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
			else
				transform.localRotation = Quaternion.Euler (rotationAmount);
 
			yield return null;
		}
		transform.localRotation = Quaternion.identity;
		isRunning = false;
	}
 
}
