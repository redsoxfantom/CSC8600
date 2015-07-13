// C++Threading.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int _tmain(int argc, _TCHAR* argv[])
{
	printf("Enter example function to run:\n");
	printf("1) Basic Thread\n");
	printf("2) For Loop Threading\n");
	char in = getc(stdin);

	if (in == '1')
	{
		BasicThread();
	}
	else
	{
		ParallelForLoop(100);
	}

	system("PAUSE");
	return 0;
}
