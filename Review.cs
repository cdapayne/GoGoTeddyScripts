using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Review : MonoBehaviour {

	//letters
	public AudioClip Letter_A, Letter_B, Letter_C, Letter_D, Letter_E, Letter_F, Letter_G;
	public AudioClip Letter_H,Letter_I,Letter_J,Letter_K,Letter_L,Letter_M,Letter_N;
    public AudioClip Letter_O,Letter_P,Letter_Q,Letter_R,Letter_S,Letter_T,Letter_U;
	public AudioClip Letter_V,Letter_W,Letter_X,Letter_Y,Letter_Z;
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
	int itemNum;
	ArrayList CalledNumbers=new ArrayList();
	public Text mainWord;
	int WordIndex=0;
	string logarraylistview="";
	public int NumberOfWords;
	public AudioSource audioS;
	// Use this for initialization
	void Start () {
		Debug.Log ("review is loaded");
		NextWord ();
	}
	public void NextWord()
	{
		Debug.Log (CalledNumbers.Count);
		if (CalledNumbers.Count >= NumberOfWords) {
			CalledNumbers.Clear();
			logarraylistview="";
		}
		/*if (WordIndex > NumberOfWords) {
			WordIndex=-1;
		}
		WordIndex++;*/
		itemNum = Random.Range (0, NumberOfWords);

		if (!CalledNumbers.Contains (itemNum)) {
			CalledNumbers.Add(itemNum);
			logarraylistview=logarraylistview+","+itemNum.ToString();
			Debug.Log(logarraylistview);
			GetWord (itemNum);
			Debug.Log("got word");
		} else {
			NextWord();
			Debug.Log("try again");
		}

		//GetWord (WordIndex);
	}
	public void RepeatWord()
	{
		GetWord (itemNum);
	}
	public void PreviousWord()
	{
		if (WordIndex < 0) {
			WordIndex=NumberOfWords;
		}
		WordIndex--;
		GetWord (WordIndex);
	}
	void GetWord(int count)
	{
		//Debug.Log (count);
		switch (count) {
		case 0: 	audioS.clip = k0; audioS.Play(); StartCoroutine(SpellWord(k0.name,1,k0)); break;
		case 1: 	audioS.clip = k1; audioS.Play(); StartCoroutine(SpellWord(k1.name,1,k1)); break;
		case 2: 	audioS.clip = k2; audioS.Play(); StartCoroutine(SpellWord(k2.name,1,k2)); break;
		case 3: 	audioS.clip = k3; audioS.Play(); StartCoroutine(SpellWord(k3.name,1,k3)); break;
		case 4: 	audioS.clip = k4; audioS.Play(); StartCoroutine(SpellWord(k4.name,1,k4)); break;
		case 5: 	audioS.clip = k5; audioS.Play(); StartCoroutine(SpellWord(k5.name,1,k5)); break;
		case 6: 	audioS.clip = k6; audioS.Play(); StartCoroutine(SpellWord(k6.name,1,k6)); break;
		case 7: 	audioS.clip = k7; audioS.Play(); StartCoroutine(SpellWord(k7.name,1,k7)); break;
		case 8: 	audioS.clip = k8; audioS.Play(); StartCoroutine(SpellWord(k8.name,1,k8)); break;
		case 9: 	audioS.clip = k9; audioS.Play(); StartCoroutine(SpellWord(k9.name,1,k9)); break;

		case 10: 	audioS.clip = k10; audioS.Play(); StartCoroutine(SpellWord(k10.name,1,k10)); break;
		case 11: 	audioS.clip = k11; audioS.Play(); StartCoroutine(SpellWord(k11.name,1,k11)); break;
		case 12: 	audioS.clip = k12; audioS.Play(); StartCoroutine(SpellWord(k12.name,1,k12)); break;
		case 13: 	audioS.clip = k13; audioS.Play(); StartCoroutine(SpellWord(k13.name,1,k13)); break;
		case 14: 	audioS.clip = k14; audioS.Play(); StartCoroutine(SpellWord(k14.name,1,k14)); break;
		case 15: 	audioS.clip = k15; audioS.Play(); StartCoroutine(SpellWord(k15.name,1,k15)); break;
		case 16: 	audioS.clip = k16; audioS.Play(); StartCoroutine(SpellWord(k16.name,1,k16)); break;
		case 17: 	audioS.clip = k17; audioS.Play(); StartCoroutine(SpellWord(k17.name,1,k17)); break;
		case 18: 	audioS.clip = k18; audioS.Play(); StartCoroutine(SpellWord(k18.name,1,k18)); break;
		case 19: 	audioS.clip = k19; audioS.Play(); StartCoroutine(SpellWord(k19.name,1,k19)); break;

		case 20: 	audioS.clip = k20; audioS.Play(); StartCoroutine(SpellWord(k20.name,1,k20)); break;
		case 21: 	audioS.clip = k21; audioS.Play(); StartCoroutine(SpellWord(k21.name,1,k21)); break;
		case 22: 	audioS.clip = k22; audioS.Play(); StartCoroutine(SpellWord(k22.name,1,k22)); break;
		case 23: 	audioS.clip = k23; audioS.Play(); StartCoroutine(SpellWord(k23.name,1,k23)); break;
		case 24: 	audioS.clip = k24; audioS.Play(); StartCoroutine(SpellWord(k24.name,1,k24)); break;
		case 25: 	audioS.clip = k25; audioS.Play(); StartCoroutine(SpellWord(k25.name,1,k25)); break;
		case 26: 	audioS.clip = k26; audioS.Play(); StartCoroutine(SpellWord(k26.name,1,k26)); break;
		case 27: 	audioS.clip = k27; audioS.Play(); StartCoroutine(SpellWord(k27.name,1,k27)); break;
		case 28: 	audioS.clip = k28; audioS.Play(); StartCoroutine(SpellWord(k28.name,1,k28)); break;
		case 29: 	audioS.clip = k29; audioS.Play(); StartCoroutine(SpellWord(k29.name,1,k29)); break;

		case 30: 	audioS.clip = k30; audioS.Play(); StartCoroutine(SpellWord(k30.name,1,k30)); break;
		case 31: 	audioS.clip = k31; audioS.Play(); StartCoroutine(SpellWord(k31.name,1,k31)); break;
		case 32: 	audioS.clip = k32; audioS.Play(); StartCoroutine(SpellWord(k32.name,1,k32)); break;
		case 33: 	audioS.clip = k33; audioS.Play(); StartCoroutine(SpellWord(k33.name,1,k33)); break;
		case 34: 	audioS.clip = k34; audioS.Play(); StartCoroutine(SpellWord(k34.name,1,k34)); break;
		case 35: 	audioS.clip = k35; audioS.Play(); StartCoroutine(SpellWord(k35.name,1,k35)); break;
		case 36: 	audioS.clip = k36; audioS.Play(); StartCoroutine(SpellWord(k36.name,1,k36)); break;
		case 37: 	audioS.clip = k37; audioS.Play(); StartCoroutine(SpellWord(k37.name,1,k37)); break;
		case 38: 	audioS.clip = k38; audioS.Play(); StartCoroutine(SpellWord(k38.name,1,k38)); break;
		case 39: 	audioS.clip = k39; audioS.Play(); StartCoroutine(SpellWord(k39.name,1,k39)); break;

		case 40: 	audioS.clip = k40; audioS.Play(); StartCoroutine(SpellWord(k40.name,1,k40)); break;
		case 41: 	audioS.clip = k41; audioS.Play(); StartCoroutine(SpellWord(k41.name,1,k41)); break;
		case 42: 	audioS.clip = k42; audioS.Play(); StartCoroutine(SpellWord(k42.name,1,k42)); break;
		case 43: 	audioS.clip = k43; audioS.Play(); StartCoroutine(SpellWord(k43.name,1,k43)); break;
		case 44: 	audioS.clip = k44; audioS.Play(); StartCoroutine(SpellWord(k44.name,1,k44)); break;
		case 45: 	audioS.clip = k45; audioS.Play(); StartCoroutine(SpellWord(k45.name,1,k45)); break;
		case 46: 	audioS.clip = k46; audioS.Play(); StartCoroutine(SpellWord(k46.name,1,k46)); break;
		case 47: 	audioS.clip = k47; audioS.Play(); StartCoroutine(SpellWord(k47.name,1,k47)); break;
		case 48: 	audioS.clip = k48; audioS.Play(); StartCoroutine(SpellWord(k48.name,1,k48)); break;
		case 49: 	audioS.clip = k49; audioS.Play(); StartCoroutine(SpellWord(k49.name,1,k49)); break;

		case 50: 	audioS.clip = k50; audioS.Play(); StartCoroutine(SpellWord(k50.name,1,k50)); break;
		case 51: 	audioS.clip = k51; audioS.Play(); StartCoroutine(SpellWord(k51.name,1,k51)); break;
		case 52: 	audioS.clip = k52; audioS.Play(); StartCoroutine(SpellWord(k52.name,1,k52)); break;
		case 53: 	audioS.clip = k53; audioS.Play(); StartCoroutine(SpellWord(k53.name,1,k53)); break;
		case 54: 	audioS.clip = k54; audioS.Play(); StartCoroutine(SpellWord(k54.name,1,k54)); break;
		case 55: 	audioS.clip = k55; audioS.Play(); StartCoroutine(SpellWord(k55.name,1,k55)); break;
		case 56: 	audioS.clip = k56; audioS.Play(); StartCoroutine(SpellWord(k56.name,1,k56)); break;
		case 57: 	audioS.clip = k57; audioS.Play(); StartCoroutine(SpellWord(k57.name,1,k57)); break;
		case 58: 	audioS.clip = k58; audioS.Play(); StartCoroutine(SpellWord(k58.name,1,k58)); break;
		case 59: 	audioS.clip = k59; audioS.Play(); StartCoroutine(SpellWord(k59.name,1,k59)); break;

		case 60: 	audioS.clip = k60; audioS.Play(); StartCoroutine(SpellWord(k60.name,1,k60)); break;
		case 61: 	audioS.clip = k61; audioS.Play(); StartCoroutine(SpellWord(k61.name,1,k61)); break;
		case 62: 	audioS.clip = k62; audioS.Play(); StartCoroutine(SpellWord(k62.name,1,k62)); break;
		case 63: 	audioS.clip = k63; audioS.Play(); StartCoroutine(SpellWord(k63.name,1,k63)); break;
		case 64: 	audioS.clip = k64; audioS.Play(); StartCoroutine(SpellWord(k64.name,1,k64)); break;
		case 65: 	audioS.clip = k65; audioS.Play(); StartCoroutine(SpellWord(k65.name,1,k65)); break;
		case 66: 	audioS.clip = k66; audioS.Play(); StartCoroutine(SpellWord(k66.name,1,k66)); break;
		case 67: 	audioS.clip = k67; audioS.Play(); StartCoroutine(SpellWord(k67.name,1,k67)); break;
		case 68: 	audioS.clip = k68; audioS.Play(); StartCoroutine(SpellWord(k68.name,1,k68)); break;
		case 69: 	audioS.clip = k69; audioS.Play(); StartCoroutine(SpellWord(k69.name,1,k69)); break;

		case 70: 	audioS.clip = k70; audioS.Play(); StartCoroutine(SpellWord(k70.name,1,k70)); break;
		case 71: 	audioS.clip = k71; audioS.Play(); StartCoroutine(SpellWord(k71.name,1,k71)); break;
		case 72: 	audioS.clip = k72; audioS.Play(); StartCoroutine(SpellWord(k72.name,1,k72)); break;
		case 73: 	audioS.clip = k73; audioS.Play(); StartCoroutine(SpellWord(k73.name,1,k73)); break;
		case 74: 	audioS.clip = k74; audioS.Play(); StartCoroutine(SpellWord(k74.name,1,k74)); break;
		case 75: 	audioS.clip = k75; audioS.Play(); StartCoroutine(SpellWord(k75.name,1,k75)); break;
		case 76: 	audioS.clip = k76; audioS.Play(); StartCoroutine(SpellWord(k76.name,1,k76)); break;
		case 77: 	audioS.clip = k77; audioS.Play(); StartCoroutine(SpellWord(k77.name,1,k77)); break;
		case 78: 	audioS.clip = k78; audioS.Play(); StartCoroutine(SpellWord(k78.name,1,k78)); break;
		case 79: 	audioS.clip = k79; audioS.Play(); StartCoroutine(SpellWord(k79.name,1,k79)); break;

		case 80: 	audioS.clip = k80; audioS.Play(); StartCoroutine(SpellWord(k80.name,1,k80)); break;
		case 81: 	audioS.clip = k81; audioS.Play(); StartCoroutine(SpellWord(k81.name,1,k81)); break;
		case 82: 	audioS.clip = k82; audioS.Play(); StartCoroutine(SpellWord(k82.name,1,k82)); break;
		case 83: 	audioS.clip = k83; audioS.Play(); StartCoroutine(SpellWord(k83.name,1,k83)); break;
		case 84: 	audioS.clip = k84; audioS.Play(); StartCoroutine(SpellWord(k84.name,1,k84)); break;
		case 85: 	audioS.clip = k85; audioS.Play(); StartCoroutine(SpellWord(k85.name,1,k85)); break;
		case 86: 	audioS.clip = k86; audioS.Play(); StartCoroutine(SpellWord(k86.name,1,k86)); break;
		case 87: 	audioS.clip = k87; audioS.Play(); StartCoroutine(SpellWord(k87.name,1,k87)); break;
		case 88: 	audioS.clip = k88; audioS.Play(); StartCoroutine(SpellWord(k88.name,1,k88)); break;
		case 89: 	audioS.clip = k89; audioS.Play(); StartCoroutine(SpellWord(k89.name,1,k89)); break;

	

		}
	}

	IEnumerator SayLetter(AudioClip clip, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		// Now do your thing here
		audioS.clip=clip;
		audioS.Play();
	}
	IEnumerator SpellWord(string Word,float delayTime,AudioClip Aword)
	{	
		mainWord.text = Word;
		yield return new WaitForSeconds(delayTime);
		int pCount = 0;
		Word = Word.ToLower ();
		char[] WordArray = Word.ToCharArray ();
		for (int i=0; i<WordArray.Length; i++) {
			//Debug.Log(WordArray[i]);
			pCount++;
		
			switch(WordArray[i])
			{
			case 'a': StartCoroutine(SayLetter(Letter_A,i)); break;
			case 'b': StartCoroutine(SayLetter(Letter_B,i)); break;
			case 'c': StartCoroutine(SayLetter(Letter_C,i)); break;
			case 'd': StartCoroutine(SayLetter(Letter_D,i)); break;
			case 'e': StartCoroutine(SayLetter(Letter_E,i)); break;
			case 'f': StartCoroutine(SayLetter(Letter_F,i)); break;
			case 'g': StartCoroutine(SayLetter(Letter_G,i)); break;
			case 'h': StartCoroutine(SayLetter(Letter_H,i)); break;
			case 'i': StartCoroutine(SayLetter(Letter_I,i)); break;
			case 'j': StartCoroutine(SayLetter(Letter_J,i)); break;
			case 'k': StartCoroutine(SayLetter(Letter_K,i)); break;
			case 'l': StartCoroutine(SayLetter(Letter_L,i)); break;
			case 'm': StartCoroutine(SayLetter(Letter_M,i)); break;
			case 'n': StartCoroutine(SayLetter(Letter_N,i)); break;
			case 'o': StartCoroutine(SayLetter(Letter_O,i)); break;
			case 'p': StartCoroutine(SayLetter(Letter_P,i)); break;
			case 'q': StartCoroutine(SayLetter(Letter_Q,i)); break;
			case 'r': StartCoroutine(SayLetter(Letter_R,i)); break;
			case 's': StartCoroutine(SayLetter(Letter_S,i)); break;
			case 't': StartCoroutine(SayLetter(Letter_T,i)); break;
			case 'u': StartCoroutine(SayLetter(Letter_U,i)); break;
			case 'v': StartCoroutine(SayLetter(Letter_V,i)); break;
			case 'w': StartCoroutine(SayLetter(Letter_W,i)); break;
			case 'x': StartCoroutine(SayLetter(Letter_X,i)); break;
			case 'y': StartCoroutine(SayLetter(Letter_Y,i)); break;
			case 'z': StartCoroutine(SayLetter(Letter_Z,i)); break;
			}
		}

		StartCoroutine(SayLetter(Aword,pCount));

	}
/*	ArrayList CalculateLengthOfSounds(string TheWord,AudioClip Word)
	{
		ArrayList AudioLengths = new ArrayList ();
		AudioLengths.Add (Word.length);
		char[] WordArray = TheWord.ToCharArray ();
		for (int i=0; i<WordArray.Length; i++) {
			Debug.Log(WordArray[i].ToString().ToLower());
			AudioLengths.Add (LetterLength(WordArray[i].ToString()));
		}

		return AudioLengths;
	}*/
/*	float LetterLength(string let)
	{
		float leng = 0;
		switch (let) {
		case "a":leng = Letter_A.length; break;
		case "w":leng = Letter_W.length; break;
		case "y":leng = Letter_Y.length; break;

		}

		return leng;
	}*/
	
	// Update is called once per frame
	void Update () {
	
	}
}
