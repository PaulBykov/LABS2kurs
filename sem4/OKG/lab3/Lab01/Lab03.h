
// Lab03.h: основной файл заголовка для приложения Lab03
//
#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h" ;     // основные символы


// MyPlot2D:
// Сведения о реализации этого класса: Lab03.cpp
//

class MyPlot2D : public CWinApp
{
public:
	MyPlot2D() noexcept;

// Переопределение
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Реализация

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern MyPlot2D theApp;
