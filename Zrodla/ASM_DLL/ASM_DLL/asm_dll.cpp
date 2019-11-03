#include "ASM_DLL.h"
#include "pch.h"


class ASM_DLL
{
public:
	static int ColorChange(int r, int g, int b);
};


int ASM_DLL::ColorChange(int r, int g, int b)
{
	__asm
	{
		mov eax, r
		add eax, g
		add eax, b
	}
}