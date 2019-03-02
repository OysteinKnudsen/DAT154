// FunctionPointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <vector>;
using namespace std;

void HelloWorld(int a) {
	cout << "Hello world, value " << a << "\n";
}

void PrintValue(int value) {
	cout << "Value: " << value << "\n";
}

//Function which takes in a vector of values and a function pointer as parameter
void ForEach(const vector<int>& values, void(*func)(int)) {
	for (int value : values) {
		func(value);
	}
}

int main()
{
	//Declaring a function pointer
	typedef void(*HelloWorldFunction)(int a);

	//Assigning the HelloWorld function to that function pointer
	HelloWorldFunction functionVariableName = HelloWorld;

	functionVariableName(5);
	functionVariableName(10);

	//Vector of values to be iterated over
	vector<int> values = { 1, 5,3,20,15,8 };

	//Passes the printvalue function as parameter
	ForEach(values, PrintValue);

	//Lambda expression instead of a declared function
	ForEach(values, [](int value) {cout << "Value: " << value << "\n"; });
}
