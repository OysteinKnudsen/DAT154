// DAT154_SDK_Ex1.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "DAT154_SDK_Ex1.h"
#include "Drawing.h"
#include "Car.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
COLORREF color = (RGB(0, 0, 0));
int eastState = 0;
int southState = 2;
bool** states;
int numberOfWestCars = 0;
int numberOfNorthCars = 0;
Car* westCars[50];
Car* northCars[50];
bool lightState1[] = { TRUE, FALSE,FALSE };
bool lightState2[] = { TRUE, TRUE, FALSE };
bool lightState3[] = { FALSE, FALSE, TRUE };
bool lightState4[] = { FALSE, TRUE, FALSE };


// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
void DrawCars(const HDC &hdc);
void AddWestCar();
void AddNorthCar();
void ChangeLightStates();
void UpdateCarPositions();
void InsertCar(const WCHAR[6]);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_DAT154SDKEX1, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

	//Create states for trafficLight

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_DAT154SDKEX1));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_DAT154SDKEX1));
    wcex.hCursor        = LoadCursor(NULL, IDC_CROSS);	//Changed cursor
    wcex.hbrBackground  = (HBRUSH)(COLOR_BACKGROUND+2); //Changed color
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_DAT154SDKEX1);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);
   
   if (!hWnd)
   {
      return FALSE;
   }
   states = new bool*[4];
   states[0] = lightState1;
   states[1] = lightState2;
   states[2] = lightState3;
   states[3] = lightState4;

   SetTimer(hWnd,						// handle to main window 
	   IDT_TRAFFICLIGHTTIMER,		     // timer identifier 
	   5000,							// 10-second interval 
	   (TIMERPROC)NULL);

   SetTimer(hWnd, IDT_CARUPDATETIMER, 10, (TIMERPROC)NULL);

   ShowWindow(hWnd, SW_MAXIMIZE);
   UpdateWindow(hWnd);

   return TRUE;
}


LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)	
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;

    case WM_PAINT:
        {

		// Prepeare for painting
		PAINTSTRUCT ps; 
		HDC hdc = BeginPaint(hWnd, &ps);

		DrawRoads(hdc);
		DrawTrafficLight(hdc, 525, 85, states[eastState]);
		DrawTrafficLight(hdc, 675, 225, states[southState]);
		DrawCars(hdc);

		//End painting session
		EndPaint(hWnd, &ps);

	}

	case WM_TIMER:
		switch (wParam) 
		{
		case IDT_TRAFFICLIGHTTIMER:
			ChangeLightStates();
			InvalidateRect(hWnd, NULL, true);

		case IDT_CARUPDATETIMER:
			if (numberOfWestCars > 0) {
				UpdateCarPositions();
				InvalidateRect(hWnd, NULL, true);
			}
		}

        
    case WM_DESTROY:
		
        break;

	case WM_LBUTTONDOWN:
	{
		if (numberOfWestCars < 50) {
			AddWestCar();
		}
		InvalidateRect(hWnd, 0, FALSE);
	}

	case WM_RBUTTONDOWN: 
	{
		if (numberOfNorthCars < 50) {
			AddNorthCar();
		}
		InvalidateRect(hWnd, 0, FALSE);
	}
	
		
	case WM_MOUSEMOVE:
	{
		WCHAR s[100];
		int x = (short)LOWORD(lParam);
		int y = (short)HIWORD(lParam);
		wsprintf(s, L"Koordiantes (%d, %d)", x, y);
		SetWindowTextW(hWnd, s);
		break;

	}
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
   
    }

    return 0;
}

void DrawCars(const HDC &hdc)
{
	if (numberOfWestCars > 0) {
		for (int i = 0; i < numberOfWestCars; i++) {
			DrawCar(hdc, *westCars[i]);
		}
	}

	if (numberOfNorthCars > 0) {
		for (int i = 0; i < numberOfNorthCars; i++) {
			DrawCar(hdc, *northCars[i]);
		}
	}
}

void AddWestCar()
{
	Car *car = new Car(25, 325, 5);
	westCars[numberOfWestCars] = car;
	numberOfWestCars++;
}

void AddNorthCar()
{
	Car *car = new Car(575, 30, 5);
	northCars[numberOfNorthCars] = car;
	numberOfNorthCars++;
}

void ChangeLightStates()
{
	eastState++;
	southState++;
	if (eastState == 4)
		eastState = 0;
	

	if (southState == 4)
		southState = 0;
}

void UpdateCarPositions() 
{
	//For each car in the cars 
	
	for (int i = 0; i < numberOfWestCars; i++) {
		if (eastState == 2 | eastState == 3 && westCars[i]->xPos > 480 & westCars[i]->xPos < 550)
		{
			break;
		} else 
		westCars[i]->xPos = westCars[i]->xPos + 10;
	}

	for (int i = 0; i < numberOfNorthCars; i++) {
		if (southState == 2 | southState == 3 && northCars[i]->yPos > 200 && northCars[i]->yPos < 250)
		{
			break;
		}
		else
			northCars[i]->yPos = northCars[i]->yPos + 5;
	}

	
	
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
