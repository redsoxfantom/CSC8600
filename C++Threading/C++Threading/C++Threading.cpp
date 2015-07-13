// C++Threading.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

DWORD WINAPI ThreadFunction(LPVOID params);
void ParallelForLoop(int numIters);

typedef struct tData
{
	int val;
} myTData, *pTData;

int _tmain(int argc, _TCHAR* argv[])
{
	pTData data = (pTData)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(myTData));
	data->val = 100;

	HANDLE myThread = CreateThread(NULL, 0, ThreadFunction, data, 0, NULL);
	WaitForSingleObject(myThread,INFINITE);

	printf("Main Thread Running\n");

	ParallelForLoop(100);

	getc(stdin);
	return 0;
}

DWORD WINAPI ThreadFunction(LPVOID params)
{
	pTData data = (pTData)params;
	printf("Child Thread Called With Params: %d\n",data->val);

	return 0;
}

DWORD WINAPI ForThreadFunction(LPVOID params)
{
	pTData iterationData = (pTData)params;
	DWORD threadId = GetCurrentThreadId();
	for (int i = 0; i < iterationData->val; i++)
	{
		printf("Thread %d running iteration %d\n",threadId,i);
	}
}

void ParallelForLoop(int numIters)
{
	// Get the number of processors in the system
	LPSYSTEM_INFO sysInfo = (LPSYSTEM_INFO)HeapAlloc(GetProcessHeap(),HEAP_ZERO_MEMORY,sizeof(_SYSTEM_INFO));
	GetSystemInfo(sysInfo);
	DWORD numProc = sysInfo->dwNumberOfProcessors;
	// Calculate how much work each processor will be responsible for
	int range = numIters / numProc;
	int remainder = numIters % numProc;
	// Info logging
	printf("Running for loop using %d logical processors. Each processor will handle a range of %d. The final processor will handle a range of %d\n", numProc,range,remainder+range);
}