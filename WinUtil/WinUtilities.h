// WinUtilities.h : Declaration of the CWinUtilities

#pragma once
#include "resource.h"       // main symbols


// IWinUtilities
[
	object,
	uuid("D1A001AF-641A-4767-82FA-E40820DD6B6E"),
	dual,	helpstring("IWinUtilities Interface"),
	pointer_default(unique)
]
__interface IWinUtilities : IDispatch
{
    [id(1), helpstring("method SetTransparency")] HRESULT SetTransparency([in] VARIANT hWnd, [in] VARIANT bTransparent, [in] VARIANT ColorRef, [in] VARIANT BlendLevel, [in] VARIANT dwFlags);
};

struct AsyncWindowLong
{
    BOOL     _bTransparent;
    HWND     _hWnd;
    LONG_PTR _NewStyle;
    COLORREF _ColorKey;
    BYTE     _Blend;
    DWORD    _Flags;
};

// CWinUtilities

[
	coclass,
	threading("apartment"),
	vi_progid("WinUtil.WinUtilities"),
	progid("WinUtil.WinUtilities.1"),
	version(1.0),
	uuid("27211BD0-DC68-4186-BEA3-6D1E02A15B66"),
	helpstring("WinUtilities Class")
]
class ATL_NO_VTABLE CWinUtilities : 
	public IWinUtilities
{
public:
	CWinUtilities()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:

    STDMETHOD(SetTransparency)(VARIANT hWnd, VARIANT bTransparent, VARIANT ColorRef, VARIANT BlendLevel, VARIANT dwFlags);

private:

    static
    DWORD
    WINAPI
    EnableTransparencyAsync(
        LPVOID pvAsync );

};

