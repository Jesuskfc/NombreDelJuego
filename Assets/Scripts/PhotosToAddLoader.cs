using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class PhotosToAddLoader : MonoBehaviour {

	public Image[] focusedImages;
	public Image[] unfocusedImages;
	public GUIProcessImage[] buttons;
	private List<string> paths;

	// Use this for initialization
	void Start () {
		paths = new List<string> ();
		string[] files = Directory.GetFiles (Application.persistentDataPath);
		for (int i = 0; i < focusedImages.Length; i++) 
		{
			string filePath;
			do 
			{
				filePath = Path.GetFileName (files [Random.Range (0, files.Length)]);
			}
			while (paths.Contains(filePath) || !Path.GetExtension (filePath).Equals (".jpg") && !Path.GetExtension (filePath).Equals (".png") && !Path.GetExtension (filePath).Equals (".jpeg"));
			buttons [i].path = filePath;
			Sprite spr1 = new Sprite ();
			byte[] imgRead = System.IO.File.ReadAllBytes (Application.persistentDataPath+"/"+filePath);
			Texture2D tempText1 = new Texture2D (1, 1);
			tempText1.LoadImage (imgRead);
			spr1 = Sprite.Create (tempText1, new Rect (0, 0, tempText1.width,tempText1.height), new Vector2 (0, 0));
			focusedImages [i].sprite = spr1;
			Sprite spr2 = new Sprite ();
			spr2 = Sprite.Create (tempText1.ToGrayscale(), new Rect (0, 0, tempText1.width,tempText1.height), new Vector2 (0, 0));
			unfocusedImages [i].sprite = spr2;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
