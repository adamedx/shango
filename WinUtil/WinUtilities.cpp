// WinUtilities.cpp : Implementation of CWinUtilities

#include "stdafx.h"
#include "WinUtilities.h"


// CWinUtilities


STDMETHODIMP CWinUtilities::SetTransparency(VARIANT varhWnd, VARIANT varbTransparent, VARIANT varColorRef, VARIANT varBlendLevel, VARIANT vardwFlags)
{
    HWND hWnd;
    BOOL bTransparent;
    
    hWnd = (HWND) V_UI4( &varhWnd );

    bTransparent = V_BOOL( &varbTransparent );

    LONG_PTR CurrentStyle;
    LONG_PTR OldStyle;
    LONG_PTR NewStyle;
    LONG     Status;
    BOOL     bStatus;
    
    AsyncWindowLong* pAsync = NULL;

    //
    // In the documentation, it is stated that Get / Set WindowLongPtr have very strange
    // error behavior. If these functions fail, the return value is 0, but they 
    // can also return 0 on success when the current value of the longptr is 0.  So
    // the docs say to use GetLastError, but you must also call SetLastError since
    // they do not clear the error on success... very clumsy.
    //

    SetLastError( ERROR_SUCCESS );

    CurrentStyle = GetWindowLongPtr( hWnd, GWL_EXSTYLE );

    Status = GetLastError();

    bStatus = ( ( 0 != CurrentStyle ) || ( ERROR_SUCCESS == Status ) );

    if ( bStatus )
    {
        NewStyle = CurrentStyle;

        if ( bTransparent )
        {
            NewStyle |= WS_EX_LAYERED;
        }
        else
        {
            NewStyle &= ~WS_EX_LAYERED;
        }

        pAsync = new AsyncWindowLong;   
    }

    if ( pAsync )
    {

        pAsync->_hWnd = hWnd;
        pAsync->_NewStyle = NewStyle;
        pAsync->_bTransparent;
        pAsync->_ColorKey = V_UI4( &varColorRef );
        pAsync->_Blend = V_UI1( &varBlendLevel );
        pAsync->_Flags = V_I4( &vardwFlags );
/*
        HANDLE hThread;

        hThread = CreateThread( 
            NULL,
            0,
            EnableTransparencyAsync,
            pAsync,
            0,
            NULL);

        if ( ! hThread )
        {
            bStatus = FALSE;

            Status = GetLastError();
        }
        
        CloseHandle( hThread );

        */
    
        EnableTransparencyAsync( pAsync );        
    }

    HRESULT hr;

    if ( bStatus )
    {
        hr = S_OK;
    }
    else
    {
        delete pAsync;

        hr = HRESULT_FROM_WIN32( Status );
    }

    return hr;
}


DWORD
WINAPI
CWinUtilities::EnableTransparencyAsync(
    LPVOID pvAsync )
{
    AsyncWindowLong* pAsync;

    pAsync = (AsyncWindowLong*) pvAsync;

    SetLastError( ERROR_SUCCESS );

    (void) SetWindowLongPtr( pAsync->_hWnd, GWL_EXSTYLE, pAsync->_NewStyle );

    DWORD Status;

    Status = GetLastError();

    if ( pAsync->_bTransparent )
    {
        SetLastError( ERROR_SUCCESS );

        (void) SetLayeredWindowAttributes(
            pAsync->_hWnd,
            pAsync->_ColorKey,
            pAsync->_Blend,
            pAsync->_Flags);

        Status = GetLastError();    
    }    

    delete pAsync;

    return 0;
}