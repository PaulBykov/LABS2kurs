
// ChildView.cpp: реализация класса CChildView
//

#include "stdafx.h"
#include "Lab03.h"
#include "ChildView.h"
#include<algorithm>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{		
}

CChildView::~CChildView()
{
}

// Реализация карты сообщений
BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	// сообщения меню выбора
	ON_COMMAND(ID_TESTS_F1, &CChildView::OnTestsF1)					
	ON_COMMAND(ID_TESTS_F2, &CChildView::OnTestsF2)		
	ON_COMMAND(ID_TESTS_F3, &CChildView::OnTestsF3)					
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
	CPaintDC dc(this); // контекст устройства для рисования

	if (Index == 1)		// режим отображения MM_TEXT
	{
		Graph.Draw(dc, 1, 1);
	}

	if (Index == 2)
	{
		Graph.GetRS(RS);
		SetMyMode(dc, RS, RW);				// Устанавливает режим отображения MM_ANISOTROPIC (можно выбирать Х и У и логич единицу)
		Graph.Draw1(dc, 1, 1);
		dc.SetMapMode(MM_TEXT);				// Устанавливает режим отображения MM_TEXT (напр Х вправо, напр У вниз, логич единица 1 пиксель)
	}
}

double CChildView::MyF1(double x)
{
	return sin(x) / x;
}


double CChildView::MyF2(double x)
{
	return sqrt(abs(x)) * sin(x);
}

double CChildView::MyF3(double x, double radius)
{
	return sqrt(radius * radius - x * x);
}



void CChildView::OnTestsF1()	// MM_TEXT
{
	double Xl = -3 * pi;		// Координата Х левого угла области
	double Xh = -Xl;			// Координата Х правого угла области
	double dX = pi / 36;		// Шаг графика функции
	int N = (Xh - Xl) / dX;		// Количество точек графика

	X.RedimMatrix(N + 1);		// Создаем вектор с N+1 строками для хранения координат точек по Х
	Y.RedimMatrix(N + 1);		// Создаем вектор с N+1 строками для хранения координат точек по Y
	
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;		// Заполняем массивы/векторы значениями
		Y(i) = MyF1(X(i));
	}

	PenLine.Set(PS_SOLID, 1, RGB(255, 0, 0));	// Устанавливаем параметры пера для линий (сплошная линия, толщина 1, цвет красный)
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));	// Устанавливаем параметры пера для осей (сплошная линия, толщина 2, цвет синий)
	RW.SetRect(100, 100, 500, 500);
	
	// Установка параметров прямоугольной области для отображения графика в окне
	Graph.SetParams(X, Y, RW);					// Передаем векторы с координатами точек и область в окне
	Graph.SetPenLine(PenLine);					// Установка параметров пера для линии графика
	Graph.SetPenAxis(PenAxis);					// Установка параметров пера для линий осей 
	Index = 1;									// Помечаем для режима отображения MM_TEXT

	this->Invalidate();
}


void CChildView::OnTestsF2()
{
	double Xl = -4 * pi;
	double Xh = -Xl;
	double dX = pi / 36;
	int N = (Xh - Xl) / dX;
	
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);

	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF2(X(i));
	}
	
	PenLine.Set(PS_DASHDOT, 1, RGB(255, 0, 0));		// Толщина 1, т.к. при более одного пунктир не наблюдается
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 0));
	
	RW.SetRect(100, 100, 500, 500);
	
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	
	Index = 1;
	this->Invalidate();
}


void CChildView::OnTestsF3()
{
	CClientDC dc(this); // Получаем контекст устройства для текущего окна

	dc.SetMapMode(MM_ANISOTROPIC);

	// Определяем размеры прямоугольной области в мировых координатах
	CRectD rectWorld(-10, -10, 10, 10);
	CRect rectWindow(600, 50, 800, 250);

	// Получаем матрицу преобразования координат
	CMatrix M = SpaceToWindow(rectWorld, rectWindow);


	// Находим центр прямоугольной области в мировых координатах
	double worldCenterX = (rectWorld.left + rectWorld.right) / 2;
	double worldCenterY = (rectWorld.top + rectWorld.bottom) / 2;

	
	CRect rectWindowCoords;
	rectWindowCoords.left = static_cast<int>(M(0, 0) * rectWorld.left + M(0, 2));
	rectWindowCoords.top = static_cast<int>(M(1, 1) * rectWorld.top + M(1, 2));
	rectWindowCoords.right = static_cast<int>(M(0, 0) * rectWorld.right + M(0, 2));
	rectWindowCoords.bottom = static_cast<int>(M(1, 1) * rectWorld.bottom + M(1, 2));

	dc.Rectangle(&rectWindowCoords);


	// Преобразуем координаты центра прямоугольника из мировых в оконные
	int windowCenterX = static_cast<int>(M(0, 2)); // Координата X центра
	int windowCenterY = static_cast<int>(M(1, 2)); // Координата Y центра

	// Находим минимальную сторону прямоугольника
	double minSide = min(rectWorld.right - rectWorld.left, rectWorld.bottom - rectWorld.top) / 2.0;

	// Радиус окружности равен половине минимальной стороны прямоугольника
	double radius = static_cast<double>(minSide);


	CPen penCircle(PS_SOLID, 2, RGB(0, 0, 255)); // Синий цвет, толщина 2
	CPen* pOldPen = dc.SelectObject(&penCircle);

	// Преобразуем радиус окружности из мировых в оконные
	double windowRadius = M(0, 0) * radius;

	// Рисуем окружность в центре прямоугольной области
	dc.Ellipse(windowCenterX + windowRadius, windowCenterY + windowRadius, windowCenterX - windowRadius, windowCenterY - windowRadius);

	dc.SelectObject(pOldPen);

	// Вычисляем координаты восьми точек пересечения на окружности в мировых координатах
	POINT points[8];
	for (int i = 0; i < 8; ++i)
	{
		double angle = i * 2 * pi / 8; // Угол для текущей точки
		points[i].x = static_cast<long>(worldCenterX + radius * cos(angle)); // Координата X
		points[i].y = static_cast<long>(worldCenterY + radius * sin(angle)); // Координата Y
	}

	CPen penOctagon(PS_SOLID, 3, RGB(255, 0, 0)); // Красный цвет, толщина 3
	pOldPen = dc.SelectObject(&penOctagon);

	// Рисуем восьмиугольник, соединяя точки на окружности
	for (int i = 0; i < 7; ++i)
	{
		POINT startPt, endPt;
		startPt.x = static_cast<int>(M(0, 0) * points[i].x + M(0, 2));
		startPt.y = static_cast<int>(M(1, 1) * points[i].y + M(1, 2));
		endPt.x = static_cast<int>(M(0, 0) * points[i + 1].x + M(0, 2));
		endPt.y = static_cast<int>(M(1, 1) * points[i + 1].y + M(1, 2));
		dc.MoveTo(startPt);
		dc.LineTo(endPt);
	}
	// Соединяем последнюю точку с первой, чтобы закончить восьмиугольник
	POINT startPt, endPt;
	startPt.x = static_cast<int>(M(0, 0) * points[7].x + M(0, 2));
	startPt.y = static_cast<int>(M(1, 1) * points[7].y + M(1, 2));
	endPt.x = static_cast<int>(M(0, 0) * points[0].x + M(0, 2));
	endPt.y = static_cast<int>(M(1, 1) * points[0].y + M(1, 2));
	dc.MoveTo(startPt);
	dc.LineTo(endPt);

	dc.SelectObject(pOldPen);
}






