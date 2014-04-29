using UnityEngine;
using ERosson;

public class DebugOverlayExample : MonoBehaviour {
	// DebugOverlay has no dependency on LoadLevelArgs; we're just using this as an example of some real-ish data we might want to debug
	public LoadLevelArgsExample example;

	void Start () {
		// DebugOverlay examples. It's this easy.
		DebugOverlay.Watch("datetime.now", () => System.DateTime.Now);
		DebugOverlay.Watch("loadCount", () => example.loadCount);
    }
}
