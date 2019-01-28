#pragma once
#include "stdafx.h"
#include "car.h"
#include "Resource.h"
#include "DAT154_SDK_Ex1.h"
#ifndef FUNCTIONS_H_INCLUDED
#define FUNCTIONS_H_INCLUDED



void DrawTrafficLight(HDC hdc, int x_pos, int y_pos, bool state [] );
void DrawRoads(HDC hdc);
void DrawCar(HDC hdc, Car &car);
void DrawBitMapCar(HDC hdc, HINSTANCE hInst, Car & car);
#endif