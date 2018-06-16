using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour {

	// Use this for initialization
	public void loadScene (int scene)
	{
		SceneManager.LoadScene(scene);
	}
}
