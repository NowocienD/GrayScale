#include "C_DLL.h"
#include "pch.h"
#include <emmintrin.h>
#include <smmintrin.h>
#include  <mmintrin.h>


class C_DLL
{
public:
	static void SingleColorChannel_Red_CPP(unsigned char * r, unsigned char * g, unsigned char * b);
	static void SingleColorChannel_Green_CPP(unsigned char * r, unsigned char * g, unsigned char * b);
	static void SingleColorChannel_Blue_CPP(unsigned char* r, unsigned char* g, unsigned char* b);
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

void C_DLL::SingleColorChannel_Blue_CPP(unsigned char* r, unsigned char* g, unsigned char* b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(g_sse, *b_sse);
	_mm_store_si128(r_sse, *b_sse);
}

void C_DLL::Decomposition_max_CPP(unsigned char* r, unsigned char* g, unsigned char* b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(r_sse, _mm_max_epu8(_mm_loadu_si128(r_sse), _mm_max_epu8(_mm_loadu_si128(g_sse), _mm_loadu_si128(b_sse))));
	_mm_store_si128(b_sse, *r_sse);
	_mm_store_si128(g_sse, *r_sse);
}

void C_DLL::Decomposition_min_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	_mm_store_si128(r_sse, _mm_min_epi8(_mm_loadu_si128(r_sse), _mm_min_epi8(_mm_loadu_si128(g_sse), _mm_loadu_si128(b_sse))));
	_mm_store_si128(b_sse, *r_sse);
	_mm_store_si128(g_sse, *r_sse);
}

void C_DLL::Desaturation_CPP(unsigned char * r, unsigned char * g, unsigned char * b)
{
	__m128i* r_sse = (__m128i*)r;
	__m128i* g_sse = (__m128i*)g;
	__m128i* b_sse = (__m128i*)b;

	__m128i* min = r_sse;
	__m128i* max = r_sse;

	_mm_store_si128(min, _mm_min_epu8(_mm_loadu_si128(r_sse), _mm_min_epu8(_mm_loadu_si128(g_sse), _mm_loadu_si128(b_sse))));
	_mm_store_si128(max, _mm_max_epu16(_mm_loadu_si128(r_sse), _mm_max_epu16(_mm_loadu_si128(g_sse), _mm_loadu_si128(b_sse))));

	_mm_srli_epi16(*min, 1);
	_mm_srli_epi16(*max, 1);

	_mm_store_si128(r_sse, _mm_adds_epu8(*min, *max));
	_mm_store_si128(b_sse, *r_sse);
	_mm_store_si128(g_sse, *r_sse);

}