#include "stdafx.h"

DWORD WINAPI ThreadFunction(LPVOID params)
{
	pTData data = (pTData)params;
	printf("Child Thread Called With Params: %d\n", data->val);

	return 0;
}

void BasicThread()
{
	pTData data = (pTData)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(myTData));
	data->val = 100;

	HANDLE myThread = CreateThread(NULL, 0, ThreadFunction, data, 0, NULL);
	WaitForSingleObject(myThread, INFINITE);

	printf("Main Thread Running\n");
}