#include "stdafx.h"
#include "Car.h"


Car::Car()
{
}

Car::Car(int xPos, int yPos, int carSpeed) {
	this -> xPos = xPos;
	this->yPos = yPos;
	this->carSpeed = carSpeed;
}


Car::~Car()
{
}
