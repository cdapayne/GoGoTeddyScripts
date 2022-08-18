using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellTheWord : MonoBehaviour {

	public Text MainWord;
	public Text l1,l2,l3,l4,l5,l6,l7,l8,l9,l10;
/*	public Text l11,l12,l13,l14,l15,l16,l17,l18,l19,l20;
	public Text l21,l22,l23,l24,l25,l26,l27,l28,l29,l30;
	public Text l31,l32,l33,l34,l35,l36,l37,l38,l39,l40;
	public Text l41,l42,l43,l44,l45,l46,l47,l48,l49,l50;
	public Text l51,l52,l53,l54,l55,l56,l57,l58,l59,l60;
	public Text l61,l62,l63,l64,l65,l66,l67,l68,l69,l70;
	public Text l71,l72,l73,l74,l75,l76,l77,l78,l79,l80;
	public Text l81,l82,l83,l84,l85,l86,l87,l88,l89,l90;*/

	string GlobalWord="";
	string GlobalAnswer="";
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

	ArrayList CalledNumbers=new ArrayList();
	ArrayList tenspots = new ArrayList ();
	ArrayList tenletters = new ArrayList ();
	AudioClip globalCurrentWord;
	public int NumberOfWords;
	public AudioSource audioS;
	// Use this for initialization
	void Start () {
		int rnd = Random.Range (0, NumberOfWords);
		StartCoroutine(CreateSpellingWord (rnd,0));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RepeatWord()
	{
		//yield return new WaitForSeconds(delayTime);
		audioS.clip = GetRandomDirection ();
		audioS.Play ();
		AudioClip AnswerWord = globalCurrentWord;
		//GenerateAnswers (AnswerWord.name);
		
		
		StartCoroutine (SayWord (AnswerWord, 2.4f));
	}
	IEnumerator CreateSpellingWord(int numfloat, float delayTime)
	{
		yield return new WaitForSeconds (delayTime);
		Debug.Log (CalledNumbers.Count);
		if (CalledNumbers.Count >= NumberOfWords) {
			CalledNumbers.Clear ();
		}
		
		if (!CalledNumbers.Contains (numfloat)) {
			CalledNumbers.Add (numfloat);
			
			audioS.clip = GetRandomDirection();
			audioS.Play ();
			AudioClip AnswerWord = GetWord (numfloat);
			globalCurrentWord = AnswerWord;
			GlobalAnswer=AnswerWord.name;
			GenerateAnswers (AnswerWord.name);
			StartCoroutine (SayWord (AnswerWord, 2.4f));
			//	Debug.Log(itemNum);
			//	Debug.Log("got word");
		} else {
			StartCoroutine (CreateSpellingWord (Random.Range (0, NumberOfWords), 0));
			//Debug.Log("try again");
		}
	}
	void GenerateAnswers(string name)
	{
		FilltenSpots ();
		FillInWord (name);
		OrganizeAllTheLetters ();
	}
	public void OrganizeAllTheLetters()
	{
		int p1 = int.Parse (tenspots[0].ToString());
		int p2 = int.Parse (tenspots[1].ToString());
		int p3 = int.Parse (tenspots[2].ToString());
		int p4 = int.Parse (tenspots[3].ToString());
		int p5 = int.Parse (tenspots[4].ToString());
		int p6 = int.Parse (tenspots[5].ToString());
		int p7 = int.Parse (tenspots[6].ToString());
		int p8 = int.Parse (tenspots[7].ToString());
		int p9 = int.Parse (tenspots[8].ToString());
		int p10 = int.Parse (tenspots[9].ToString());

		PlaceLetterLocation (p1);
		PlaceLetterLocation (p2);
		PlaceLetterLocation (p3);
		PlaceLetterLocation (p4);
		PlaceLetterLocation (p5);
		PlaceLetterLocation (p6);
		PlaceLetterLocation (p7);
		PlaceLetterLocation (p8);
		PlaceLetterLocation (p9);
		PlaceLetterLocation (p10);

	}
	public void PlaceLetterLocation(int a)
	{
		switch (a) {
		case 0: l1.text=tenletters[0].ToString(); break;
		case 1: l2.text=tenletters[1].ToString(); break;
		case 2: l3.text=tenletters[2].ToString(); break;
		case 3: l4.text=tenletters[3].ToString(); break;
		case 4: l5.text=tenletters[4].ToString(); break;
		case 5: l6.text=tenletters[5].ToString(); break;
		case 6: l7.text=tenletters[6].ToString(); break;
		case 7: l8.text=tenletters[7].ToString(); break;
		case 8: l9.text=tenletters[8].ToString(); break;
		case 9: l10.text=tenletters[9].ToString(); break;
		default: l1.text="b"; break;
		}
	}
	public void FillInWord(string name)
	{
		char[] namechar = name.ToCharArray ();
		for (int i=0; i<name.Length; i++) {
			int spot=int.Parse(tenspots[i].ToString());
			tenletters[spot]=namechar[i].ToString();
		}
	}

	IEnumerator SayWord(AudioClip clip, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		// Now do your thing here
		audioS.clip=clip;
		audioS.Play();
	}
	public string getLetter(int index)
	{
		switch (index) {
		case 0: return "A"; break;
		case 1: return "B"; break;
		case 2: return "C"; break;
		case 3: return "D"; break;
		case 4: return "E"; break;
		case 5: return "F"; break;
		case 6: return "G"; break;
		case 7: return "H"; break;
		case 8: return "I"; break;
		case 9: return "J"; break;
		case 10: return "K"; break;
		case 11: return "L"; break;
		case 12: return "M"; break;
		case 13: return "N"; break;
		case 14: return "O"; break;
		case 15: return "P"; break;
		case 16: return "Q"; break;
		case 17: return "R"; break;
		case 18: return "S"; break;
		case 19: return "T"; break;
		case 20: return "U"; break;
		case 21: return "V"; break;
		case 22: return "W"; break;
		case 23: return "X"; break;
		case 24: return "Y"; break;
		case 25: return "Z"; break;
		default: return "A"; break;
		}
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
			
		}
		return null;
	}
	public void FilltenSpots()
	{
		while (tenspots.Count!=10) {
			int rnd = Random.Range (0, 10);
			if (!tenspots.Contains (rnd)) {
				tenspots.Add (rnd);
				string llk=getLetter(Random.Range(0,26)).ToLower();
				tenletters.Add(llk);
			//	Debug.Log ("added " + tenspots.Count.ToString ()+" = " + rnd.ToString()+"-"+llk);
			} else {
				FilltenSpots ();
			}
		}
	}
	public void AppendWord(Text Letter)
	{
		Debug.Log (Letter.text);
		GlobalWord = GlobalWord + Letter.text;
	//	Debug.Log (GlobalWord);
		MainWord.text = GlobalWord;
		Letter.enabled = false;
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

	AudioClip GetRandomDirection()
	{
		int directionIndex = Random.Range (0, 2);
		//	Debug.Log (directionIndex);
		AudioClip direc=dir;
		switch (directionIndex) {
		case 1: direc=dir; break;
		case 2: direc=dir1; break;
		case 0: direc=dir2; break;
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

	public void clear()
	{
		tenspots.Clear ();
		tenletters.Clear ();
		FilltenSpots ();
		GlobalWord = "";
		MainWord.text = "";
		l1.enabled = true;
		l2.enabled = true;
		l3.enabled = true;
		l4.enabled = true;
		l5.enabled = true;
		l6.enabled = true;
		l7.enabled = true;
		l8.enabled = true;
		l9.enabled = true;
		l10.enabled = true;
	}
	public void submit()
	{
		if (GlobalWord.Equals (GlobalAnswer)) {
			Debug.Log ("correct");
			Debug.Log ("thats correct");
			audioS.clip = GetRandomRight ();
			audioS.Play ();

			clear ();
			StartCoroutine (CreateSpellingWord (Random.Range (0, NumberOfWords), 1));
		} else {
			Debug.Log ("incorrect");
			Debug.Log ("thats correct");
			audioS.clip = GetRandomWrong();
			audioS.Play ();
		}
	}
}
