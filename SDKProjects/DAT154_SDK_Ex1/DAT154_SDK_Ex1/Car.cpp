#include "stdafx.h"
#include "Car.h"


Car::Car()
{
}

Car::Car(int xPos, int yPos, int width, int height, int carSpeed) {
	this -> xPos = xPos;
	this->yPos = yPos;
	this->carSpeed = carSpeed;
	this->width = width;
	this->height = height;
}



Car::~Car()
{
}
