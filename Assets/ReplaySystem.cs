using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 100;
    private MyKeyFrame[] myKeyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Record();
    }

    void Playback()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = myKeyFrames[frame].position;
        transform.rotation = myKeyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;

        myKeyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

//a structure for storing time, position and rotation
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        this.position = pos;
        this.rotation = rot;
    }
}
