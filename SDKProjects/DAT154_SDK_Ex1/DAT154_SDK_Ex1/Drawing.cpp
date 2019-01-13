#include "Drawing.h"
#include "stdafx.h"

COLORREF colorRed = RGB(255, 0, 0);
COLORREF colorGreen = RGB(0, 255, 0);
COLORREF colorYellow = RGB(255, 255, 0);
COLORREF colorBlack = RGB(0, 0, 0);
COLORREF colorGray = RGB(169, 169, 169);

void DrawTrafficLight(HDC hdc, int x_pos, int y_pos)
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
void DrawRoads(HDC hdc) {
	HBRUSH hBrush = CreateSolidBrush(colorGray);
	HGDIOBJ hOrg = SelectObject(hdc, hBrush);
	HGDIOBJ hPen;
	HGDIOBJ hPenOld;
	LOGBRUSH lb; 
	lb.lbColor = colorYellow;
	lb.lbStyle = PS_SOLID;
	

	Rectangle(hdc, 0, 250, 1500, 350); //left to right road
	Rectangle(hdc, 550, 0, 650, 1500); //top to bottom road
	hPen = ExtCreatePen(PS_GEOMETRIC | PS_DASH, 15, &lb, 0, NULL);
	hPenOld = SelectObject(hdc, hPen);

	//Create lines for left to right road
	MoveToEx(hdc, 0, 300, 0);
	LineTo(hdc, 1500, 300);

	//Create lines for top to bottom road
	MoveToEx(hdc, 600, 0, 0);
	LineTo(hdc, 600, 1500);


	SelectObject(hdc, hOrg);
	DeleteObject(hOrg);
	SelectObject(hdc, hPenOld);
	DeleteObject(hPen);
}
