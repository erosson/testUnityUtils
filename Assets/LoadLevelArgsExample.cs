using UnityEngine;
using ERosson;

// Args passed via loadlevel. You can use any class or struct.
class ExampleArgs {
	public int loadCount = 0;
}

public class LoadLevelArgsExample : MonoBehaviour {
	public AudioClip clip;
	// initial value is not used, the default LoadLevelArgs overwrites it
	public int loadCount = -999;

	void Start () {
		// LoadLevelArgs.Pop requires a default value, so levels can always be run from the editor safely for testing.
		// By default, that's the zero-arg constructor of the type you pass here. Pop(defaultValue) also works.
		var param = LoadLevelArgs.Pop<ExampleArgs>();
		loadCount = param.loadCount;
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		// A button, to force a reload of the same level.
		if (GUILayout.Button("load count: " + loadCount + ". Reload level")) {
			var args = new ExampleArgs();
			args.loadCount = loadCount + 1;
			// Our audio survives the level change
			Audio.PlayClip(clip);
			LoadLevelArgs.LoadLevel(Application.loadedLevelName, args);
		}
		if (GUILayout.Button("force game over")) {
			LoadLevelArgs.LoadLevel("GameOver", "Game over!!\n\nloadcount: "+loadCount);
		}
		GUILayout.EndArea();
	}
}
