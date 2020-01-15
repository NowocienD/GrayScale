#include "C_DLL.h"
#include "pch.h"
#include <emmintrin.h>


class C_DLL
{
public:
	static void SingleColorChannel_Red_CPP(unsigned char * r, unsigned char * g, unsigned char * b);
	static void SingleColorChannel_Green_CPP(unsigned char * r, unsigned char * g, unsigned char * b);
	static void SingleColorChannel_Blue_CPP(unsigned char * r, unsigned char * g, unsigned char * b);
	static void Decomposition_max_CPP(unsigned char* r, unsigned char* g, unsigned char* b);
	static void Decomposition_min_CPP(unsigned char* r, unsigned char* g, unsigned char* b);
	static void Desaturation_CPP(unsigned char* r, unsigned char* g, unsigned char* b);
};

void C_DLL::SingleColorChannel_Red_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(g_sse, *r_sse);
	_mm_store_si128(b_sse, *r_sse);
}

void C_DLL::SingleColorChannel_Green_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(r_sse, *g_sse);
	_mm_store_si128(b_sse, *g_sse);
}

void C_DLL::SingleColorChannel_Blue_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(r_sse, *b_sse);
	_mm_store_si128(g_sse, *b_sse);
}

void C_DLL::Decomposition_max_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	g = r;
	b = r;
}

void C_DLL::Decomposition_min_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	g = r;
	b = r;
}

void C_DLL::Desaturation_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	g = r;
	b = r;
}