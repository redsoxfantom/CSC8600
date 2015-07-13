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

	return 0;
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
	int finalRange = range + remainder;

	// Info logging
	printf("Running for loop using %d logical processors. Each processor will handle a range of %d. The final processor will handle a range of %d\n", numProc,range,finalRange);
	printf("Creating Threads...\n");

	// Create an array of handles for the threads
	HANDLE *ThreadArray = (HANDLE*)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(HANDLE)*numProc);
	for (DWORD i = 0; i < numProc; i++)
	{
		// Allocate space for the thread and it's parameter
		HANDLE currThread = *(ThreadArray + i);
		pTData data = (pTData)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(myTData));
		if (i == numProc - 1)
		{
			data->val = finalRange;
		}
		else
		{
			data->val = range;
		}

		// Create and run the thread
		currThread = CreateThread(NULL, 0, ForThreadFunction, data, 0, NULL);
	}

	// Wait for all the child threads to complete
	WaitForMultipleObjects(numProc, ThreadArray, TRUE, INFINITE);
	printf("All for loop threads have completed\n");
}