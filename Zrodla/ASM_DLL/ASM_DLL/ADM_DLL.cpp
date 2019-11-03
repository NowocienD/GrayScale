#include "pch.h"


class ASM_DLL
{
public:
	static int ColorChange2(int r, int g, int b);
};

extern "C" int asmFunc(int a, int b);

int ASM_DLL::ColorChange2(int r, int g, int b)
{
	return 1;//return asmFunc(2, 3);
}