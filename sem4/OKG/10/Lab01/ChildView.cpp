
// ChildView.cpp: реализация класса CChildView
//

#include "stdafx.h"
#include "Lab08.h"
#include "ChildView.h"
#include "LibLabs3D.h"
#include <string>
#include <fstream>
#include <iostream>

using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView
//COLORREF Color = RGB(255, 0, 0);

CChildView::CChildView()
{		
	Index = 3;
	PView.RedimMatrix(3);
	PSourceLight.RedimMatrix(3);
	Radius = 2;

	Color = RGB(255, 255, 0);
	PView(0) = 15;	PView(1) = 30;  PView(2) = 60;
	PSourceLight(0) = 10;  PSourceLight(1) = 45; PSourceLight(2) = 45;
}

CChildView::~CChildView()
{
}

// Реализация карты сообщений
BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	// сообщения меню выбора

	ON_COMMAND(ID_Sphere_Mirror, &CChildView::OnSphere_Mirror)
	ON_COMMAND(ID_Sphere_Diffuse, &CChildView::OnSphere_Diffuse)
	ON_WM_SIZE()
	ON_COMMAND(ID_SPHERE_32776, &CChildView::SetCameraPosition)
	ON_COMMAND(ID_SPHERE_32777, &CChildView::SetLightSourcePosition)
	ON_COMMAND(ID_SPHERE_32778, &CChildView::SetLightColor)
END_MESSAGE_MAP()



// Обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(nullptr, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), nullptr);

	return TRUE;
}

void CChildView::OnPaint()
{
	CPaintDC dc(this);		// контекст устройства для рисования

	CString ss;

	ss.Format(L"Camera: f=%5.1f,  q=%5.1f", PView(1), PView(2));
	dc.TextOutW(5, 5, ss);
	ss.Format(L"Light      : f=%5.1f,  q=%5.1f", PSourceLight(1), PSourceLight(2));
	dc.TextOutW(5, 30, ss);

	if (Index == 0) {
		dc.Rectangle(WinRect);
		DrawLightSphere(dc, Radius, PView, PSourceLight, WinRect, Color, Index);
	}
		
	if (Index == 1) {
		dc.Rectangle(WinRect);
		DrawLightSphere(dc, Radius, PView, PSourceLight, WinRect, Color, Index);
	}
}

void CChildView::OnSphere_Diffuse()
{
	WinRect.SetRect(100, 50, 300, 250);

	Index = 0;

	Invalidate();
}

void CChildView::OnSphere_Mirror()
{
	WinRect.SetRect(100, 50, 300, 250);

	Index = 1;
	
	Invalidate();
}



void CChildView::OnSize(UINT nType, int cx, int cy)
{
	CWnd::OnSize(nType, cx, cy);				// для динамического изменения окна
	WinRect.SetRect(50, 50, cx - 50, cy - 50);	// параметры окна рисования
}


void CChildView::SetCameraPosition()
{
	std::string line;

	int r = 0;
	int fi = 0;
	int teta = 0;

	std::ifstream in("D:\\Labs\\OKG\\lab_10_1\\x64\\Debug\\camera_position.txt");

	if (in.is_open())
	{
		std::getline(in, line);
		r = stoi(line);

		std::getline(in, line);
		fi = stoi(line);

		std::getline(in, line);
		teta = stoi(line);
	}
	in.close();

	PView(0) = r;
	PView(1) = fi;
	PView(2) = teta;

	Invalidate();
}


void CChildView::SetLightSourcePosition()
{
	std::string line;

	int r = PSourceLight(0);
	int fi = PSourceLight(0);
	int teta = PSourceLight(2);

	std::ifstream in("D:\\Labs\\OKG\\lab_10_1\\x64\\Debug\\ligth_position.txt");

	if (in.is_open())
	{
		std::getline(in, line);
		r = stoi(line);

		std::getline(in, line);
		fi = stoi(line);

		std::getline(in, line);
		teta = stoi(line);
	}
	in.close();

	PSourceLight(0) = r;
	PSourceLight(1) = fi;
	PSourceLight(2) = teta;

	Invalidate();
}


void CChildView::SetLightColor()
{
	std::string line;

	int r = 0;
	int g = 0;
	int b = 0;

	std::ifstream in("D:\\Labs\\OKG\\lab_10_1\\x64\\Debug\\ligth_color.txt");

	if (in.is_open())
	{
		std::getline(in, line);
		r = stoi(line);

		std::getline(in, line);
		g = stoi(line);

		std::getline(in, line);
		b = stoi(line);
	}
	in.close();

	Color = RGB(r, g, b);

	Invalidate();
}
