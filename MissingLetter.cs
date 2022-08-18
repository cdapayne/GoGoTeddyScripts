using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissingLetter : MonoBehaviour {

	//kindergarten words
	public AudioClip k1,k2,k3,k4,k5,k6,k7,k8,k9,k0;
	public AudioClip k11,k12,k13,k14,k15,k16,k17,k18,k19,k10;
	public AudioClip k21,k22,k23,k24,k25,k26,k27,k28,k29,k20;
	public AudioClip k31,k32,k33,k34,k35,k36,k37,k38,k39,k30;
	public AudioClip k41,k42,k43,k44,k45,k46,k47,k48,k49,k40;
	public AudioClip k51,k52,k53,k54,k55,k56,k57,k58,k59,k50;
	public AudioClip k61,k62,k63,k64,k65,k66,k67,k68,k69,k60;
	public AudioClip k71,k72,k73,k74,k75,k76,k77,k78,k79,k70;
	public AudioClip k81,k82,k83,k84,k85,k86,k87,k88,k89,k80;

	public AudioClip Cong0,Cong1,Cong2,Cong3,Cong4;
	public AudioClip Incor0,Incor1,Incor2,Incor3,Incor4;
	public AudioClip dir,dir1,dir2,dir3;
	public int NumberOfWords;
	ArrayList CalledNumbers=new ArrayList();
	string logarraylistview="";
	public AudioSource audioS;
	string GlobalCorrectAnswer;
	string let2;
	public Text pos1,pos2,pos3,MainWord;
	ArrayList collectionofletters=new ArrayList();
	//fix the duplicate choses

	string[] alphabet=new string[] { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };
	// Use this for initialization
	void Start () {
		StartCoroutine(NextWord(1));
	}

	IEnumerator NextWord(int delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		Debug.Log (CalledNumbers.Count);
		if (CalledNumbers.Count >= NumberOfWords) {
			CalledNumbers.Clear();
			logarraylistview="";
		}
		/*if (WordIndex > NumberOfWords) {
			WordIndex=-1;
		}
		WordIndex++;*/
		int itemNum = Random.Range (0, NumberOfWords);
		
		if (!CalledNumbers.Contains (itemNum)) {
			CalledNumbers.Add(itemNum);
			logarraylistview=logarraylistview+","+itemNum.ToString();
			//Debug.Log(logarraylistview);
			CreateMissingWord (itemNum);
		//	Debug.Log(itemNum);
		//	Debug.Log("got word");
		} else {
			StartCoroutine(NextWord(0));
			//Debug.Log("try again");
		}
		 
		//GetWord (WordIndex);
	}

	public void CreateMissingWord(int num)
	{
		audioS.clip = GetRandomDirection ();
		audioS.Play ();
		string full_word = GetWord (num);
		char[] word_array = full_word.ToCharArray();
		//Debug.Log (full_word);
		int fullIndex=Random.Range (0, full_word.Length);
	//	Debug.Log (fullIndex);
		string RemoveLeter = word_array [fullIndex].ToString();
	//	Debug.Log (RemoveLeter);
		word_array [fullIndex] = '_';
		string wordwMissing = new string (word_array);
		MainWord.text = wordwMissing;
	//	Debug.Log (wordwMissing);
		GenerateAnswers (RemoveLeter);
	}
	void GenerateAnswers(string CorrectLetter)
	{
		GlobalCorrectAnswer = CorrectLetter;
		int CorrectPos = Random.Range (1, 3);
	//	Debug.Log (CorrectPos);

		if (CorrectPos == 1) {
	//		Debug.Log(CorrectLetter);
			pos1.text=CorrectLetter;
			pos2.text=GetUniqueLetter(CorrectLetter);
			pos3.text=GetUniqueLetter(CorrectLetter);
		}
		if (CorrectPos == 2) {
			//		Debug.Log(CorrectLetter);
			pos2.text=CorrectLetter;
			pos3.text=GetUniqueLetter(CorrectLetter);
			pos1.text=GetUniqueLetter(CorrectLetter);
		}
		if (CorrectPos == 3) {
			//		Debug.Log(CorrectLetter);
			pos3.text=CorrectLetter;
			pos1.text=GetUniqueLetter(CorrectLetter);
			pos2.text=GetUniqueLetter(CorrectLetter);
		}

	}
	string GetWord(int count)
	{
		//Debug.Log (count);
		switch (count) {
		case 0: 	return k0.name; break;
		case 1: 	return k1.name; break;
		case 2: 	return k2.name; break;
		case 3: 	return k3.name; break;
		case 4: 	return k4.name; break;
		case 5: 	return k5.name; break;
		case 6: 	return k6.name; break;
		case 7: 	return k7.name; break;
		case 8: 	return k8.name; break;
		case 9: 	return k9.name; break;

		case 10: 	return k10.name; break;
		case 11: 	return k11.name; break;
		case 12: 	return k12.name; break;
		case 13: 	return k13.name; break;
		case 14: 	return k14.name; break;
		case 15: 	return k15.name; break;
		case 16: 	return k16.name; break;
		case 17: 	return k17.name; break;
		case 18: 	return k18.name; break;
		case 19: 	return k19.name; break;

		case 20: 	return k20.name; break;
		case 21: 	return k21.name; break;
		case 22: 	return k22.name; break;
		case 23: 	return k23.name; break;
		case 24: 	return k24.name; break;
		case 25: 	return k25.name; break;
		case 26: 	return k26.name; break;
		case 27: 	return k27.name; break;
		case 28: 	return k28.name; break;
		case 29: 	return k29.name; break;

		case 30: 	return k30.name; break;
		case 31: 	return k31.name; break;
		case 32: 	return k32.name; break;
		case 33: 	return k33.name; break;
		case 34: 	return k34.name; break;
		case 35: 	return k35.name; break;
		case 36: 	return k36.name; break;
		case 37: 	return k37.name; break;
		case 38: 	return k38.name; break;
		case 39: 	return k39.name; break;

		case 40: 	return k40.name; break;
		case 41: 	return k41.name; break;
		case 42: 	return k42.name; break;
		case 43: 	return k43.name; break;
		case 44: 	return k44.name; break;
		case 45: 	return k45.name; break;
		case 46: 	return k46.name; break;
		case 47: 	return k47.name; break;
		case 48: 	return k48.name; break;
		case 49: 	return k49.name; break;

		case 50: 	return k50.name; break;
		case 51: 	return k51.name; break;
		case 52: 	return k52.name; break;
		case 53: 	return k53.name; break;
		case 54: 	return k54.name; break;
		case 55: 	return k55.name; break;
		case 56: 	return k56.name; break;
		case 57: 	return k57.name; break;
		case 58: 	return k58.name; break;
		case 59: 	return k59.name; break;

		case 60: 	return k60.name; break;
		case 61: 	return k61.name; break;
		case 62: 	return k62.name; break;
		case 63: 	return k63.name; break;
		case 64: 	return k64.name; break;
		case 65: 	return k65.name; break;
		case 66: 	return k66.name; break;
		case 67: 	return k67.name; break;
		case 68: 	return k68.name; break;
		case 69: 	return k69.name; break;

		case 70: 	return k70.name; break;
		case 71: 	return k71.name; break;
		case 72: 	return k72.name; break;
		case 73: 	return k73.name; break;
		case 74: 	return k74.name; break;
		case 75: 	return k75.name; break;
		case 76: 	return k76.name; break;
		case 77: 	return k77.name; break;
		case 78: 	return k78.name; break;
		case 79: 	return k79.name; break;

		case 80: 	return k80.name; break;
		case 81: 	return k81.name; break;
		case 82: 	return k82.name; break;
		case 83: 	return k83.name; break;
		case 84: 	return k84.name; break;
		case 85: 	return k85.name; break;
		case 86: 	return k86.name; break;
		case 87: 	return k87.name; break;
		case 88: 	return k88.name; break;
		case 89: 	return k89.name; break;

		}
		return "none";
	}
	public void CheckForCorrectAnswer(Text Answer)
	{
		if (Answer.text.Equals (GlobalCorrectAnswer)) {
			Debug.Log ("thats correct");
			audioS.clip = GetRandomRight ();
			audioS.Play ();

			//update word after answer
			string wor=MainWord.text;
			string newWor=wor.Replace("_",Answer.text);
			MainWord.text=newWor;
			StartCoroutine(NextWord(1));

		} else {
			Debug.Log("thats wrong");
			audioS.clip = GetRandomWrong ();
			audioS.Play ();
		}
	}
	string GetUniqueLetter(string CorrectLetter)
	{
		int letterIndex = Random.Range (0, 25);
		string chosenletter = alphabet [letterIndex];
	
	//		Debug.Log("option 1");
			if (chosenletter.Equals (CorrectLetter)) {
				chosenletter=GetUniqueLetter (CorrectLetter);
			}
		return chosenletter;
	}
	AudioClip GetRandomDirection()
	{
		int directionIndex = Random.Range (1, 4);
	//	Debug.Log (directionIndex);
		AudioClip direc=dir;
		switch (directionIndex) {
		case 1: direc=dir; break;
		case 2: direc=dir1; break;
		case 3: direc=dir2; break;
		case 4: direc=dir3; break;
		}
		return direc;
	}
	AudioClip GetRandomWrong()
	{
		int directionIndex = Random.Range (0, 4);
	//	Debug.Log (directionIndex);
		AudioClip direc=Incor0;
		switch (directionIndex) {
		case 1: direc=Incor0; break;
		case 2: direc=Incor1; break;
		case 3: direc=Incor2; break;
		case 4: direc=Incor3; break;
		case 0: direc=Incor4; break;
		}
		return direc;
	}
	AudioClip GetRandomRight()
	{
		int directionIndex = Random.Range (0, 4);
		Debug.Log (directionIndex);
		AudioClip direc=Cong0;
		switch (directionIndex) {
		case 1: direc=Cong0; break;
		case 2: direc=Cong1; break;
		case 3: direc=Cong2; break;
		case 4: direc=Cong3; break;
		case 0: direc=Cong4; break;
		}
		return direc;
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
