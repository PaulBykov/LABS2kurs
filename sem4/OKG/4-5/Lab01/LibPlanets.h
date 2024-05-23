#ifndef LIBPLANETS
#define LIBPLANETS 1
const double pi = 3.14159;


struct CSizeD
{
	double cx;
	double cy;
};


struct CRectD
{
	double left;
	double top;
	double right;
	double bottom;
	CRectD() { left = top = right = bottom = 0; };
	CRectD(double l, double t, double r, double b);
	void SetRectD(double l, double t, double r, double b);
	CSizeD SizeD();		// Возвращает размеры(ширина, высота) прямоугольника 
};

CMatrix CreateTranslate2D(double dx, double dy);
CMatrix CreateRotate2D(double fi);
CMatrix SpaceToWindow(CRectD& rs, CRect& rw);
void SetMyMode(CDC& dc, CRectD& RS, CRect& RW);  


class CMlyn
{
	CRect MidCircle;
	CRect Lopast_1;	
	CRect Lopast_2;

	CRect Lopast_1_Orbit;
	CRect Lopast_2_Orbit;

	CMatrix ECoords;
	CMatrix E2Coords;
	CMatrix MCoords;   
	CMatrix VCoords;
	CMatrix V2Coords;
	CMatrix PCoords;

	CRect RW;		   
	CRectD RS;		  

	double wLopast_1;	   // Угловая скорость лопасти относительно центра, град./сек.
	double wLopast_2;

	double fiL1;		   // Угловое положение 1
	double fiL2;		   // Угловое положение 2
	double fiL11;		   // Угловое положение 1
	double fiL21;		   // Угловое положение 2
	double fiV;
	double fiP;

	double dt;		   // Интервал дискретизации, сек.

public:
	CMlyn();
	void SetDT(double dtx) { dt = dtx; };	// Установка интервала дискретизации
	void SetNewCoords();					// Вычисляет новые координаты планет
	void GetRS(CRectD& RSX);				// Возвращает область графика в мировой СК
	CRect GetRW() { return RW; };			// Возвращает область графика в окне	
	void Draw(CDC& dc);						// Рисование без самостоятельного пересчета координат
};


#endif

