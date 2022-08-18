using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchTheWord : MonoBehaviour {

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
	public AudioClip dir;
	AudioClip globalCurrentWord;
	public int NumberOfWords;
	ArrayList CalledNumbers=new ArrayList();


	public Text pos1,pos2,pos3;
	public AudioSource audioS;
	string GlobalCorrectAnswer;
	// Use this for initialization
	void Start () {
		int rnd = Random.Range (0, NumberOfWords);
		StartCoroutine(CreateMissingWord (rnd,0));
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CheckForCorrectAnswer(Text Answer)
	{
		if (Answer.text.Equals (GlobalCorrectAnswer)) {
			Debug.Log ("thats correct");
			audioS.clip = GetRandomRight ();
			audioS.Play ();
			

			int rnd = Random.Range (0, NumberOfWords);
			StartCoroutine(CreateMissingWord (rnd,1.5f));
			
		} else {
			Debug.Log("thats wrong");
			audioS.clip = GetRandomWrong ();
			audioS.Play ();
		}
	}

	IEnumerator SayWord(AudioClip clip, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		// Now do your thing here
		audioS.clip=clip;
		audioS.Play();
	}

		IEnumerator CreateMissingWord(int numfloat, float delayTime)
		{
			yield return new WaitForSeconds(delayTime);
		Debug.Log (CalledNumbers.Count);
		if (CalledNumbers.Count >= NumberOfWords) {
			CalledNumbers.Clear();
		}

		if (!CalledNumbers.Contains (numfloat)) {
			CalledNumbers.Add(numfloat);

			audioS.clip = dir;
			audioS.Play ();
			AudioClip AnswerWord = GetWord (numfloat);
			globalCurrentWord = AnswerWord;
			GenerateAnswers (AnswerWord.name);
			StartCoroutine (SayWord (AnswerWord, 1.6f));
			//	Debug.Log(itemNum);
			//	Debug.Log("got word");
		} else {
			StartCoroutine(CreateMissingWord(Random.Range(0,NumberOfWords),0));
			//Debug.Log("try again");
		}
	}
	public void RepeatWord()
	{
		//yield return new WaitForSeconds(delayTime);
		audioS.clip = dir;
		audioS.Play ();
		AudioClip AnswerWord = globalCurrentWord;
		//GenerateAnswers (AnswerWord.name);
		
		
		StartCoroutine (SayWord (AnswerWord, 1.5f));
		//string full_word = GetWord (num);
		/*	char[] word_array = full_word.ToCharArray();
		//Debug.Log (full_word);
		int fullIndex=Random.Range (0, full_word.Length);
		//	Debug.Log (fullIndex);
		string RemoveLeter = word_array [fullIndex].ToString();
		//	Debug.Log (RemoveLeter);
		word_array [fullIndex] = '_';
		string wordwMissing = new string (word_array);
		MainWord.text = wordwMissing;
		//	Debug.Log (wordwMissing);
		GenerateAnswers (RemoveLeter);*/
	}
	void GenerateAnswers(string CorrectWord)
	{
		GlobalCorrectAnswer = CorrectWord;
		int CorrectPos = Random.Range (1, 3);
		//	Debug.Log (CorrectPos);
		
		if (CorrectPos == 1) {
			//		Debug.Log(CorrectLetter);
			pos1.text=CorrectWord;
			AudioClip p2=GetWord(Random.Range(0,NumberOfWords)); pos2.text=p2.name;
			AudioClip p3=GetWord(Random.Range(0,NumberOfWords)); pos3.text=p3.name;
		}
		if (CorrectPos == 2) {
			//		Debug.Log(CorrectLetter);
			pos2.text=CorrectWord;
			AudioClip p1=GetWord(Random.Range(0,NumberOfWords)); pos1.text=p1.name;
			AudioClip p3=GetWord(Random.Range(0,NumberOfWords)); pos3.text=p3.name;
		}
		if (CorrectPos == 3) {
			//		Debug.Log(CorrectLetter);
			pos3.text=CorrectWord;
			AudioClip p1=GetWord(Random.Range(0,NumberOfWords)); pos1.text=p1.name;
			AudioClip p2=GetWord(Random.Range(0,NumberOfWords)); pos2.text=p2.name;
		}
		
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
	AudioClip GetWord(int count)
	{
		//Debug.Log (count);
		switch (count) {
		case 0: 	return k0; break;
		case 1: 	return k1; break;
		case 2: 	return k2; break;
		case 3: 	return k3; break;
		case 4: 	return k4; break;
		case 5: 	return k5; break;
		case 6: 	return k6; break;
		case 7: 	return k7; break;
		case 8: 	return k8; break;
		case 9: 	return k9; break;
			
		case 10: 	return k10; break;
		case 11: 	return k11; break;
		case 12: 	return k12; break;
		case 13: 	return k13; break;
		case 14: 	return k14; break;
		case 15: 	return k15; break;
		case 16: 	return k16; break;
		case 17: 	return k17; break;
		case 18: 	return k18; break;
		case 19: 	return k19; break;
			
		case 20: 	return k20; break;
		case 21: 	return k21; break;
		case 22: 	return k22; break;
		case 23: 	return k23; break;
		case 24: 	return k24; break;
		case 25: 	return k25; break;
		case 26: 	return k26; break;
		case 27: 	return k27; break;
		case 28: 	return k28; break;
		case 29: 	return k29; break;
			
		case 30: 	return k30; break;
		case 31: 	return k31; break;
		case 32: 	return k32; break;
		case 33: 	return k33; break;
		case 34: 	return k34; break;
		case 35: 	return k35; break;
		case 36: 	return k36; break;
		case 37: 	return k37; break;
		case 38: 	return k38; break;
		case 39: 	return k39; break;
			
		case 40: 	return k40; break;
		case 41: 	return k41; break;
		case 42: 	return k42; break;
		case 43: 	return k43; break;
		case 44: 	return k44; break;
		case 45: 	return k45; break;
		case 46: 	return k46; break;
		case 47: 	return k47; break;
		case 48: 	return k48; break;
		case 49: 	return k49; break;

		case 50: 	return k50; break;
		case 51: 	return k51; break;
		case 52: 	return k52; break;
		case 53: 	return k53; break;
		case 54: 	return k54; break;
		case 55: 	return k55; break;
		case 56: 	return k56; break;
		case 57: 	return k57; break;
		case 58: 	return k58; break;
		case 59: 	return k59; break;

		case 60: 	return k60; break;
		case 61: 	return k61; break;
		case 62: 	return k62; break;
		case 63: 	return k63; break;
		case 64: 	return k64; break;
		case 65: 	return k65; break;
		case 66: 	return k66; break;
		case 67: 	return k67; break;
		case 68: 	return k68; break;
		case 69: 	return k69; break;

		case 70: 	return k70; break;
		case 71: 	return k71; break;
		case 72: 	return k72; break;
		case 73: 	return k73; break;
		case 74: 	return k74; break;
		case 75: 	return k75; break;
		case 76: 	return k76; break;
		case 77: 	return k77; break;
		case 78: 	return k78; break;
		case 79: 	return k79; break;

		case 80: 	return k80; break;
		case 81: 	return k81; break;
		case 82: 	return k82; break;
		case 83: 	return k83; break;
		case 84: 	return k84; break;
		case 85: 	return k85; break;
		case 86: 	return k86; break;
		case 87: 	return k87; break;
		case 88: 	return k88; break;
		case 89: 	return k89; break;
			
		}
		return null;
	}
}
