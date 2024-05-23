#include "stdafx.h"

CRectD::CRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}
//------------------------------------------------------------------------------
void CRectD::SetRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}

//------------------------------------------------------------------------------
CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx = fabs(right - left);	// ������ ������������� �������
	cz.cy = fabs(top - bottom);	// ������ ������������� �������
	return cz;
}

//----------------------------------------------------------------------------

CMatrix CreateTranslate2D(double dx, double dy)
// ��������� ������� ��� �������������� ��������� ������� ��� ��� �������� 
// �� dx �� ��� X � �� dy �� ��� Y � ������������� ������� ���������
// --- ��� ---
// ��������� ������� ��� �������������� ��������� ������� ��� �������� ������
// ������� ��������� �� -dx ��� X � �� -dy �� ��� Y ��� ������������� ��������� ������� 
{
	CMatrix TM(3, 3);
	TM(0, 0) = 1; TM(0, 2) = dx;
	TM(1, 1) = 1;  TM(1, 2) = dy;
	TM(2, 2) = 1;
	return TM;
}

//------------------------------------------------------------------------------------
CMatrix CreateRotate2D(double fi)
// ��������� ������� ��� �������������� ��������� ������� ��� ��� ��������
// �� ���� fi (��� fi>0 ������ ������� �������)� ������������� ������� ���������
// --- ��� ---
// ��������� ������� ��� �������������� ��������� ������� ��� �������� ������
// ������� ��������� �� ���� -fi ��� ������������� ��������� ������� 
// fi - ���� � ��������
{
	double fg = fmod(fi, 360.0);
	double ff = (fg / 180.0)*pi; // ������� � �������
	CMatrix RM(3, 3);
	RM(0, 0) = cos(ff); RM(0, 1) = -sin(ff);
	RM(1, 0) = sin(ff);  RM(1, 1) = cos(ff);
	RM(2, 2) = 1;
	return RM;
}


//------------------------------------------------------------------------------

CMatrix SpaceToWindow(CRectD& RS, CRect& RW)
// ���������� ������� ��������� ��������� �� ������� � �������
// RS - ������� � ������� ����������� - double
// RW - ������� � ������� ����������� - int
{
	CMatrix M(3, 3);
	CSize sz = RW.Size();	 // ������ ������� � ����
	int dwx = sz.cx;	     // ������
	int dwy = sz.cy;	     // ������
	CSizeD szd = RS.SizeD(); // ������ ������� � ������� �����������

	double dsx = szd.cx;    // ������ � ������� �����������
	double dsy = szd.cy;    // ������ � ������� �����������

	double kx = (double)dwx / dsx;   // ������� �� x
	double ky = (double)dwy / dsy;   // ������� �� y

	M(0, 0) = kx;  M(0, 1) = 0;    M(0, 2) = (double)RW.left - kx * RS.left;				
	M(1, 0) = 0;   M(1, 1) = -ky;  M(1, 2) = (double)RW.bottom + ky * RS.bottom;		
	M(2, 0) = 0;   M(2, 1) = 0;    M(2, 2) = 1;
	return M;
}

//------------------------------------------------------------------------------

void SetMyMode(CDC& dc, CRectD& RS, CRect& RW) 
// ������������� ����� ����������� MM_ANISOTROPIC � ��� ���������
// dc - ������ �� ����� CDC MFC
// RS -  ������� � ������� ����������� - int
// RW -	 ������� � ������� ����������� - int  
{
	double dsx = RS.right - RS.left;
	double dsy = RS.top - RS.bottom;
	double xsL = RS.left;
	double ysL = RS.bottom;

	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwL = RW.left;
	int ywH = RW.bottom;

	dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt((int)dsx, (int)dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg((int)xsL, (int)ysL);
	dc.SetViewportOrg(xwL, ywH);
}


CMlyn::CMlyn()            //  ����������� �� ���������
{
	double R = 10; 
	double H = 80;
	double fi = 50;

	double speed = 20;
	double RoE = H, RoV = H;

	double d = RoE  + RoV;		    // �������� �������� �������

	RS.SetRectD(-d, d, d, -d);					// ������� ������� � ������� �����������
	RW.SetRect(0, 0, 600, 600);					// ������� � ����
	
	
	MidCircle.SetRect(-R, R, R, -R);
	Lopast_1_Orbit.SetRect(-RoE, RoE, RoE, -RoE);
	Lopast_2_Orbit.SetRect(-RoV, RoV, RoV, -RoV);


	fiL1 = 0+fi/4;			// ������� ��������� 1 ������� �������� 2, ����
	fiL2 = 45+fi/4;			// ������� ��������� 3 � ������� �������� 2, ����

	fiL11 = 0-fi/4;
	fiL21 = 45-fi/4;

	fiV = 45;

	wLopast_1 = -speed;			// ������� �������� 1 � ������� �������� 2, ����/���.
	wLopast_2 = -speed;			// ������� �������� 3 � ������� �������� 2, ����/���.
	

	dt = 0.1;

	ECoords.RedimMatrix(3);
	VCoords.RedimMatrix(3);
	E2Coords.RedimMatrix(3);
	V2Coords.RedimMatrix(3);
}

void CMlyn::SetNewCoords()
//��������� ����� ���������� ����� �������� ������� dt
{
	CMatrix P = CreateRotate2D(fiL2);	

	double RoE = (Lopast_1_Orbit.right - Lopast_1_Orbit.left) / 2;// ������ ����������
	double ff = (fiL1 / 180.0)*pi;								// �������
	double x = RoE * cos(ff);									// x - ��������� ���������� 
	double y = RoE * sin(ff);									// y - ��������� ����������
	ECoords(0) = x;	
	ECoords(1) = y;   
	ECoords(2) = 1;


	fiL1 += wLopast_1 * dt;
	P = CreateRotate2D(fiL1);							// ������� �������� ������ �������

	ECoords = P * ECoords;


	RoE = (Lopast_1_Orbit.right - Lopast_1_Orbit.left) / 2;// ������ ����������
	ff = (fiL11 / 180.0) * pi;							
	x = RoE * cos(ff);									// x - ��������� ����������
	y = RoE * sin(ff);									// y - ��������� ����������
	E2Coords(0) = x;	
	E2Coords(1) = y;   
	E2Coords(2) = 1;
	
	fiL11 += wLopast_1 * dt;
	P = CreateRotate2D(fiL11);							// ������� �������� ������ �������

	E2Coords = P * E2Coords;
	


	// RED ONES
	double RoV = (Lopast_2_Orbit.right - Lopast_2_Orbit.left) / 2;
	ff = (fiL2 / 180.0)*pi;
	x = RoV * cos(ff);
	y = RoV * sin(ff);
	VCoords(0) = x;
	VCoords(1) = y;
	VCoords(2) = 1;


	RoV = (Lopast_2_Orbit.right - Lopast_2_Orbit.left) / 2;
	ff = (fiL21 / 180.0) * pi;
	x = RoV * cos(ff);
	y = RoV * sin(ff);
	V2Coords(0) = x;
	V2Coords(1) = y;
	V2Coords(2) = 1;


	fiL2 += wLopast_2 * dt;
	P = CreateRotate2D(fiL2);
	VCoords = P * VCoords;

	fiL21 += wLopast_2 * dt;
	P = CreateRotate2D(fiL21);
	V2Coords = P * V2Coords;
}

void CMlyn::Draw(CDC& dc)
{

	CBrush SBrush, EBrush, MBrush, VBrush, *pOldBrush;
	CBrush PBrush;
	CRect R;

	SBrush.CreateSolidBrush(RGB(0, 255, 0));
	EBrush.CreateSolidBrush(RGB(0, 0, 255));

	VBrush.CreateSolidBrush(RGB(255,0,0));
	
	
	int d = Lopast_1.right;
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);

	double RoE = (Lopast_1_Orbit.right - Lopast_1_Orbit.left) / 2;

	double ff = d;

	int Lxr = ECoords(0);
	int Lyr = ECoords(1);

	int Lxl = E2Coords(0);
	int Lyl = E2Coords(1);

	dc.SelectObject(&EBrush);

	CPoint p1(Lxr, Lyr);
	CPoint p2(Lxl, Lyl);
	CPoint p3(0,0);

	CBrush* oldBrush = dc.SelectObject(&EBrush);
	dc.Polygon(&p2, 3);

	CPoint p4(-Lxr , -Lyr);
	CPoint p5(-Lxl , -Lyl);
	CPoint p6(0,0);

	dc.Polygon(&p5, 3);

	{
		dc.SelectObject(&VBrush);
		int Lxr = VCoords(0);
		int Lyr = VCoords(1);

		int Lxl = V2Coords(0);
		int Lyl = V2Coords(1);

		dc.SelectObject(&VBrush);

		CPoint p1(Lxr, Lyr);
		CPoint p2(Lxl, Lyl);
		CPoint p3(0, 0);

		CBrush* oldBrush = dc.SelectObject(&VBrush);
		dc.Polygon(&p2, 3);

		CPoint p4(-Lxr, -Lyr);
		CPoint p5(-Lxl, -Lyl);
		CPoint p6(0, 0);

		dc.Polygon(&p5, 3);

	}

	d = Lopast_2.right;
	R.SetRect(VCoords(0) - d, VCoords(1) + d, VCoords(0) + d, VCoords(1) - d);

	pOldBrush = dc.SelectObject(&SBrush);	// ���� ������
	dc.Ellipse(MidCircle);  // �����

	dc.SelectObject(pOldBrush);				//��������������� �������� �� pOldBrush 
}


void CMlyn::GetRS(CRectD& RSX)
// RS - ���������, ���� ������������ ��������� ������� �������
{
	RSX.left = RS.left;
	RSX.top = RS.top;
	RSX.right = RS.right;
	RSX.bottom = RS.bottom;
}







