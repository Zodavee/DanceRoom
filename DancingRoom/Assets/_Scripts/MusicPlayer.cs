 /*Made By Vexe,  Edited by Andre Azevedo 
  */
 
 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using UnityEngine.UI;
 public class MusicPlayer : MonoBehaviour
 {

     public enum SeekDirection { Forward, Backward }
	
	 public Text uiName;
     public AudioSource source;
     public List<AudioClip> clips = new List<AudioClip>();
 
     [SerializeField] [HideInInspector] private int currentIndex = 0;
 
     private FileInfo[] soundFiles;
     private List<string> validExtensions = new List<string> { ".ogg", ".wav" }; // Don't forget the "." i.e. "ogg" won't work - cause Path.GetExtension(filePath) will return .ext, not just ext.
     private string absolutePath = "./Songs"; // relative path to where the app is running - change this to "./music" in your case
 
     void Start()
     { 
         if (source == null) source = gameObject.AddComponent<AudioSource>();
			System.IO.Directory.CreateDirectory("./Songs");
         ReloadSounds();
     }
 
   
	public void Prev(){
		 Seek(SeekDirection.Backward);
	}
	public void Nxt(){
		 Seek(SeekDirection.Forward);
	}
     void Seek(SeekDirection d)
     {
         if (d == SeekDirection.Forward)
             currentIndex = (currentIndex + 1) % clips.Count;
         else {
             currentIndex--;
             if (currentIndex < 0) currentIndex = clips.Count - 1;
         }
     }
 
     public void PlayCurrent()
     {

         source.clip = clips[currentIndex];
		 
		 if(!source.isPlaying){
         	source.Play();
		 }else {
			 source.Stop();
		 }
		 uiName.text = source.clip.name;
     }
 
     public void ReloadSounds()
     {
         clips.Clear();
         // get all valid files
         var info = new DirectoryInfo(absolutePath);
		 Debug.Log(info);
         soundFiles = info.GetFiles()
             .Where(f => IsValidFileType(f.Name))
             .ToArray();
 
         // and load them
         foreach (var s in soundFiles)
             StartCoroutine(LoadFile(s.FullName));
     }
 
     bool IsValidFileType(string fileName)
     {
         return validExtensions.Contains(Path.GetExtension(fileName));
     }
 
     IEnumerator LoadFile(string path)
     {
         WWW www = new WWW("file://" + path);
         print("loading " + path);
 
         AudioClip clip = www.GetAudioClip(false);
         while(!clip.isReadyToPlay)
             yield return www;
 
         print("done loading");
         clip.name = Path.GetFileName(path);
         clips.Add(clip);
     }
 }