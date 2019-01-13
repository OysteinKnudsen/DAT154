#include "Drawing.h"
#include "stdafx.h"

COLORREF colorRed = RGB(255, 0, 0);
COLORREF colorGreen = RGB(0, 255, 0);
COLORREF colorYellow = RGB(255, 255, 0);
COLORREF colorBlack = RGB(0, 0, 0);

void drawTrafficLight(HDC hdc, int x_pos, int y_pos)
{
	//Create black brush 
	HBRUSH hBrush = CreateSolidBrush(colorBlack);
	HGDIOBJ hOrg = SelectObject(hdc, hBrush);
	int rectLeft = x_pos-20;
	int rectRight = x_pos + 20;
	int rectTop = y_pos - 55;
	int rectBottom = y_pos + 55;
	int lightsLeft = rectLeft + 5;
	int lightsRight = rectRight - 5;
	int distanceBetweenLights = 3;
	int redTop = rectTop + distanceBetweenLights;
	int redBottom = redTop + 30;
	int yellowTop = redBottom + distanceBetweenLights;
	int yellowBottom = yellowTop + 30;
	int greenTop = yellowBottom + distanceBetweenLights;
	int greenBottom = greenTop + 30;
	

	//Draw rectangle
	Rectangle(hdc, rectLeft, rectTop, rectRight, rectBottom);

	//create red brush
	hBrush = CreateSolidBrush(colorRed);
	//Selects red brush and stores original brush in hOrg
	hOrg = SelectObject(hdc, hBrush);

	//Create a red circle
	Ellipse(hdc, lightsLeft, redTop, lightsRight, redBottom);



	//Reset to original brush 
	SelectObject(hdc, hOrg);
	//Delete old red brush 
	DeleteObject(hBrush);


	//Create yellow brush 
	hBrush = CreateSolidBrush(colorYellow);
	//Select yellow brush and store original in hOrg
	hOrg = SelectObject(hdc, hBrush);

	//Draw yellow circle 
	Ellipse(hdc, lightsLeft, yellowTop, lightsRight, yellowBottom);

	//Reset to original brush
	SelectObject(hdc, hOrg);
	DeleteObject(hBrush);

	//Create green brush 
	hBrush = CreateSolidBrush(colorGreen);
	hOrg = SelectObject(hdc, hBrush);

	//Draw green circle
	Ellipse(hdc, lightsLeft, greenTop, lightsRight, greenBottom);


	//Reset to original brush
	SelectObject(hdc, hOrg);
	DeleteObject(hBrush);
	
	int trafficLightWidth = rectRight - rectLeft;

	MoveToEx(hdc, rectLeft + trafficLightWidth/2, rectBottom, 0); 
	LineTo(hdc, rectLeft + trafficLightWidth/2, rectBottom + 100);

	

}
