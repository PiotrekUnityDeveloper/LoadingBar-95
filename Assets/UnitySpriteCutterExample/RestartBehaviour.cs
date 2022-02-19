using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartBehaviour : MonoBehaviour {

	/// <summary>
	/// Simple restart method triggered by UI.Button.
	/// </summary>
	public void RestartScene() {
		//Application.LoadLevel();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
