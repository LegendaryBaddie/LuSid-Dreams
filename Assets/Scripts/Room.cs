﻿using UnityEngine;
using System.Collections;

public class Room {

	public bool active=false;
   
	const int tileCount = 2;
	public int[] roomPosition= new int[2];   
	public int[,] roomMatrix;
    public bool hasDoor=false;
    double[,] rockMatrix = new double[11,11];
	///connections
	//0 = left
	//1 = top
	//2= right
	//3= bottom
	public int[] connectionsToRooms;
	// Use this for initialization
	public Room(int[]position, int[]connections)
	{
		roomMatrix =new int[11, 11];
		roomPosition[0] = position[0];
		roomPosition[1] = position[1];
		connectionsToRooms = connections;

	


	}
	public void Generate(Seed sRand)
	{

		int xArray = roomMatrix.GetLength(0);
		int yArray = roomMatrix.GetLength(1);
		
		for (int i = 0; i < xArray; i++)
		{
			for (int m = 0; m < yArray; m++)
			{
                
				if(i==5 && m==0 && connectionsToRooms[3] ==1)
				{
					//add door bottom
					roomMatrix[i,m] = 5;

				}
				else if(i==5 && m==10 && connectionsToRooms[1] ==1)
				{
					//add door top
					roomMatrix[i,m] = 2;
				}
				else if(i==0 && m==5 && connectionsToRooms[0] ==1)
				{
					//add door left
					roomMatrix[i,m] = 3;
				}
				else if(i==10 && m==5 && connectionsToRooms[2] ==1)
				{
					//add door right
					roomMatrix[i,m] = 4;
				}
				else
				{
                    
					//if a wall
					if(i==0||i==10||m==10||m==0)
					{
						
						roomMatrix[i,m] = 6;
					}
					else // actually do room generation
					{
                        if(roomPosition[0]==6&&roomPosition[1]==6){roomMatrix[i,m]=8;}
						roomMatrix[i,m] = (int) sRand.Range(0,tileCount-1);
                         
					}
				}
			}
		}
		
	}
	public void rockChance(Seed sRand)
	{
        if(hasDoor){return;}
        if(roomPosition[0]==6 &&roomPosition[1]==6){return;}
        if(sRand.Range(0,100)<33){
		for(int r = 0; r < 11; ++r){
        for(int c = 0; c < 11; ++c){
        
        float rate = 100.0f/(4);
        float firstDisparity = Mathf.Abs(((10)/2)-r)*rate;
        float secondDisparity = Mathf.Abs(((10)/2)-c)*rate;
        double chance = (double)(100-(firstDisparity+secondDisparity));
        if(chance <0)
        {
        rockMatrix[r,c] = 0; 
        }else{
        rockMatrix[r,c] = chance;
        }
        }
        }
        for(int r = 0; r < 10; ++r){
        for(int c = 0; c < 10; ++c){
            if(sRand.Range(0,100)<rockMatrix[r,c])
            {
                roomMatrix[r,c] = 6;
            }
        }}}
    }

}
