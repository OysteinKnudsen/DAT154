#include "pch.h"
#include <iostream>

#define LOG(X) 
int main()
{

	int var = 8;

	//Void pointer, a pointer is just an address in memory, does not need a type.
	//this pointer is not valid, because a memory address cannot be 0, means NULL
	void* typelessPointer = 0; 

	//Assigns the pointer the memory address of var. This is done by using the '&' operator.
	typelessPointer = &var;

	std::cin.get();


    std::cout << "Hello World!\n"; 
}