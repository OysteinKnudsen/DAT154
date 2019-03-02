#include "pch.h"
#include <iostream>
using namespace std;

#define LOG(X) 

int main()
{
	int var = 8;

	//A pointer is just an address in memory.
	//memory address cannot be 0, means NULL
	int* pointer = 0; 

	cout<< "pointer: " << pointer << "\n";

	//Assigns the pointer the memory address of var. This is done by using the '&' operator.
	pointer = &var;

	cout << "pointer after assigning memory address of var to it: " << *pointer << "\n";


	// Reading/writing to memory
	// Using the '*' as a prefix to the pointer name, we can read/write to that address in memory.
	*pointer = 5;

	cout << "pointer after *pointer = 5 : " << *pointer << "\n";

	//char = 1 byte of memory. Line below asks for 8 bytes of memory. 
	//Returns a pointer to the beginning of that memory block. 

	char* buffer = new char[8];

	cin.get();


    std::cout << "Hello World!\n"; 
}