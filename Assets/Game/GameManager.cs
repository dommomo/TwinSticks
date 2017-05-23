using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool paused = false;
    private float timeScale, fixedDeltaTime;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        recording = (!CrossPlatformInputManager.GetButton("Fire1"));

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!paused) { PauseGame(); }
            else { ResumeGame(); }
        }
    }

    void PauseGame ()
    {
        this.timeScale = Time.timeScale;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        paused = true;
    }

    void ResumeGame ()
    {
        Time.timeScale = this.timeScale;
        Time.fixedDeltaTime = this.fixedDeltaTime;
        paused = false;
    }

    private void OnApplicationPause(bool pause)
    {
        if (!paused && pause) { PauseGame(); }

        if (paused && !pause) { ResumeGame(); }
    }
}
