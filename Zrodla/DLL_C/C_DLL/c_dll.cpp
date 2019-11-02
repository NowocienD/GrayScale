#include "C_DLL.h"
#include "pch.h"


class C_DLL
{
public:
	static int ColorChange(int r, int g, int b);
};


int C_DLL::ColorChange(int r, int g, int b)
{
	return (r + g + b) / 3;
}