using UnityEngine;
using System.Collections;

public class Seed  {
	public int value;
	string toSeed;
	public Seed(){
		//generate a new seed
		// max value of 1950585;
		value = Random.Range (0, 1950585);
		Random.seed = value;
	}

	public Seed(string _seed)
	{
		//convert to int
		char[] c_seed = _seed.ToCharArray ();
		int converted = 0;
		for(int i=0; i<12;i++)
		{
			converted*=i/2;

			// if a number
			if(c_seed[i]>='0'&& c_seed[i]<='9')
			{
				int x=c_seed[i]-'0';
				converted +=x;
			}
			else{
				switch(c_seed[i]){
				case 'a':
					converted +=10;
					break;
				case 'b':
					converted +=11;
					break;
				case 'c':
					converted +=12;
					break;
				case 'd':
					converted +=13;
					break;
				case 'e':
					converted +=14;
					break;
				case 'f':
					converted +=15;
					break;
				case 'g':
					converted +=16;
					break;
				case 'h':
					converted +=17;
					break;
				case 'i':
					converted +=18;
					break;
				case 'j':
					converted +=19;
					break;
				case 'k':
					converted +=20;
					break;
				case 'l':
					converted +=21;
					break;
				case 'm':
					converted +=22;
					break;
				case 'n':
					converted +=23;
					break;
				case 'o':
					converted +=24;
					break;
				case 'p':
					converted +=25;
					break;
				case 'q':
					converted +=26;
					break;
				case 'r':
					converted +=27;
					break;
				case 's':
					converted +=28;
					break;
				case 't':
					converted +=29;
					break;
				case 'u':
					converted +=30;
					break;
				case 'v':
					converted +=31;
					break;
				case 'w':
					converted +=32;
					break;
				case 'x':
					converted +=33;
					break;
				case 'y':
					converted +=34;
					break;
				case 'z':
					converted +=35;
					break;	
				}
			}
		}
		value = converted;
		Random.seed = value;
		Debug.Log (value);
	}
	public float Range(float min,float max)
	{
		return Random.Range (min, max);
	}

}
