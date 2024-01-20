using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class AudioManager : Node2D
{
	
	private static AudioManager audioManager;

    public static AudioManager Audio
    {
        get
        {
            if (audioManager == null)
            {
                audioManager = new AudioManager();
            }
            return audioManager;
        }
	}
	

	static int numberOfPlayers = 8;
	static string busName = "Master";

    static List<AudioStreamPlayer> available = new List<AudioStreamPlayer>();
	static List<string> queue = new List<string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for(int i = 0; i < numberOfPlayers; i++){
			AudioStreamPlayer p = new AudioStreamPlayer();
			AddChild(p);
			available.Add(p);
			p.Finished += () => OnStreamFinished(p);
		}
	}
	private void OnStreamFinished(AudioStreamPlayer p){
		available.Append(p);
	}

	public void Play(StringName sound_path){
		queue.Add(sound_path);
	}

    public override void _Process(double delta)
    {
        if(queue.Count > 0 && available.Count > 0){
			available[0].Stream = (AudioStream)ResourceLoader.Load(queue.First().ToString());
			available[0].Play();
			available.RemoveAt(0);
			queue.RemoveAt(0);
		}
    }
}
