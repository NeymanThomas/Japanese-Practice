/// <summary>
/// Simple Sound Class to store some values and properties we want
/// our sound clips to contain or have control over.
/// </summary>

using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
