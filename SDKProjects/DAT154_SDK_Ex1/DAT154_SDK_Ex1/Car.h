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
	Car(int xPos, int yPos, int carSpeed);
	~Car();

	int xPos;
	int yPos;
	int carSpeed;
	Direction direction;
};

