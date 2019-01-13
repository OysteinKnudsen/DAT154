#include <Windows.h>

//constants such that we don't have to work with ID values.
#define FILE_MENU_NEW 1 
#define FILE_MENU_OPEN 2 
#define FILE_MENU_EXIT 3 


LRESULT CALLBACK WndProcc(HWND, UINT, WPARAM, LPARAM);
void AddMenu(HWND); 
HMENU hMenu; //Handler for the menu; 



int WINAPI WinMain(
	HINSTANCE hInst, // Used to create when creating windows. Instance of our application. 
	HINSTANCE hPrevInstance, // Ignore for now
	LPSTR args, // String --> a typedef for characters. Commandline arguments
	int ncmndshow // Passed in from the commandline, tells us how to display our window. 
)

{	
	//Creating a window class 
	WNDCLASSW wc = { 0 };									// A structure, assigning 0 to all elements temporarily. 

	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;				//Colors the background
	wc.hCursor = LoadCursor ( NULL, IDC_ARROW );			//Sets cursor to arrow
	wc.hInstance = hInst;									//Sets the instance variable from parameter
	wc.lpszClassName = L"myWindowClass";					//The L prefix is to cast the string into correct type
	wc.lpfnWndProc = WndProcc;						//The procedure which takes care of all the messages (Pointer to a function)


															//Register window class such that it can be used to create windows
	if (!RegisterClassW(&wc))								//returns true of false, based on success of registration
		return -1;											//exit program if registration fails
	
	//Create the window, identified by the window name, parameters for position, width height etc
	CreateWindowW(L"myWindowClass", L"My Window", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 100, 100, 500, 500, NULL, NULL, NULL, NULL);


	
	//THE MESSAGE LOOP 

	MSG msg;
	while (GetMessage(&msg, NULL, NULL, NULL))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}


	return 0; 
}

	LRESULT CALLBACK WndProcc(HWND hWnd, UINT msg, WPARAM wp, LPARAM lp)
	{
		switch (msg) //Handles different types of messages
		{

		case WM_COMMAND:

			switch (wp) 
			{
			case FILE_MENU_EXIT:
				DestroyWindow(hWnd);
				break; 

			case FILE_MENU_NEW: 
				MessageBeep(MB_ICONINFORMATION);
				break; 

			case FILE_MENU_OPEN:
				MessageBeep(MB_ERR_INVALID_CHARS);
				break;	
			}
		
		
		case WM_CREATE: 
			AddMenu(hWnd);
			break; 

		case WM_DESTROY:
			PostQuitMessage(0);
			break;

		case WM_PAINT:
			
		default:
			return DefWindowProcW(hWnd, msg, wp, lp);
		}

	}

	void AddMenu(HWND hWnd)												//Function for adding menus to the window
	{
		hMenu = CreateMenu();											//Assigns a menu to the menuhandler.		
		HMENU hFileMenu = CreateMenu();									//Creates a file dropdown
		HMENU hSubMenu = CreateMenu();									//Create submenu 

		AppendMenu(hFileMenu, MF_STRING, FILE_MENU_NEW, L"New");		//Appends to file menu 
		AppendMenu(hFileMenu, MF_POPUP, (UINT_PTR)hSubMenu, L"Open Submenu");	//Appends "Open" to file menu. Opens submenu when clicked. 
		AppendMenu(hFileMenu, MF_SEPARATOR, NULL, NULL);				//Appends seperator to file menu
		AppendMenu(hFileMenu, MF_STRING, FILE_MENU_EXIT, L"Exit");		//Appends exit to file menu 

		AppendMenu(hSubMenu, MF_STRING, NULL, L"Submenu Item");			//Submenu item which will be opened by the "open" menu


		AppendMenu(hMenu, MF_POPUP, (UINT_PTR)hFileMenu, L"File");		//Appends file menu to main menu
		AppendMenu(hMenu, MF_STRING, 2, L"Help");						//Appends help to main menu 


		SetMenu(hWnd, hMenu);											//Adds the menu using the windowhandler and menuhandler. 
	}


