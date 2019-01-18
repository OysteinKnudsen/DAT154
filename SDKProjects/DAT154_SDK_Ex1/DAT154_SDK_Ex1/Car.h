#pragma once
class Car
{

	enum Direction
	{
		West,
		North
	};

public:
	Car();
	Car(int xPos, int yPos,int width, int height, int carSpeed);
	~Car();

	int xPos;
	int yPos;
	int carSpeed;
	int width;
	int height;
	Direction direction;
};

