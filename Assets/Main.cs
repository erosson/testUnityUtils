using UnityEngine;
using System.Collections;
using ERosson;

class MainParam {
	public int loadCount = 0;
}

public class Main : MonoBehaviour {
	// initial value is not used, the default LoadLevelArgs overwrites it
	public int loadCount = -999;

	void Start () {
		// LoadLevelArgs.Pop requires a default value, so levels can always be run from the editor safely for testing
		var param = LoadLevelArgs.Pop<MainParam>();
		loadCount = param.loadCount;
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		if (GUILayout.Button("load count: " + loadCount + ". Reload level")) {
			var param = new MainParam();
			param.loadCount = loadCount + 1;
			LoadLevelArgs.LoadLevel(Application.loadedLevelName, param);
		}
		GUILayout.EndArea();
	}
}
