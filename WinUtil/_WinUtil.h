
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Sat Mar 16 19:06:26 2002
 */
/* Compiler settings for _WinUtil.idl:
    Os, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef ___WinUtil_h__
#define ___WinUtil_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IWinUtilities_FWD_DEFINED__
#define __IWinUtilities_FWD_DEFINED__
typedef interface IWinUtilities IWinUtilities;
#endif 	/* __IWinUtilities_FWD_DEFINED__ */


#ifndef __CWinUtilities_FWD_DEFINED__
#define __CWinUtilities_FWD_DEFINED__

#ifdef __cplusplus
typedef class CWinUtilities CWinUtilities;
#else
typedef struct CWinUtilities CWinUtilities;
#endif /* __cplusplus */

#endif 	/* __CWinUtilities_FWD_DEFINED__ */


/* header files for imported files */
#include "prsht.h"
#include "mshtml.h"
#include "mshtmhst.h"
#include "exdisp.h"
#include "objsafe.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IWinUtilities_INTERFACE_DEFINED__
#define __IWinUtilities_INTERFACE_DEFINED__

/* interface IWinUtilities */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWinUtilities;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D1A001AF-641A-4767-82FA-E40820DD6B6E")
    IWinUtilities : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SetTransparency( 
            /* [in] */ VARIANT hWnd,
            /* [in] */ VARIANT bTransparent,
            /* [in] */ VARIANT ColorRef,
            /* [in] */ VARIANT BlendLevel,
            /* [in] */ VARIANT dwFlags) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWinUtilitiesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWinUtilities * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWinUtilities * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWinUtilities * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWinUtilities * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWinUtilities * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWinUtilities * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWinUtilities * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SetTransparency )( 
            IWinUtilities * This,
            /* [in] */ VARIANT hWnd,
            /* [in] */ VARIANT bTransparent,
            /* [in] */ VARIANT ColorRef,
            /* [in] */ VARIANT BlendLevel,
            /* [in] */ VARIANT dwFlags);
        
        END_INTERFACE
    } IWinUtilitiesVtbl;

    interface IWinUtilities
    {
        CONST_VTBL struct IWinUtilitiesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWinUtilities_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWinUtilities_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWinUtilities_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWinUtilities_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWinUtilities_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWinUtilities_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWinUtilities_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWinUtilities_SetTransparency(This,hWnd,bTransparent,ColorRef,BlendLevel,dwFlags)	\
    (This)->lpVtbl -> SetTransparency(This,hWnd,bTransparent,ColorRef,BlendLevel,dwFlags)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IWinUtilities_SetTransparency_Proxy( 
    IWinUtilities * This,
    /* [in] */ VARIANT hWnd,
    /* [in] */ VARIANT bTransparent,
    /* [in] */ VARIANT ColorRef,
    /* [in] */ VARIANT BlendLevel,
    /* [in] */ VARIANT dwFlags);


void __RPC_STUB IWinUtilities_SetTransparency_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWinUtilities_INTERFACE_DEFINED__ */



#ifndef __WinUtil_LIBRARY_DEFINED__
#define __WinUtil_LIBRARY_DEFINED__

/* library WinUtil */
/* [helpstring][uuid][version] */ 


EXTERN_C const IID LIBID_WinUtil;

EXTERN_C const CLSID CLSID_CWinUtilities;

#ifdef __cplusplus

class DECLSPEC_UUID("27211BD0-DC68-4186-BEA3-6D1E02A15B66")
CWinUtilities;
#endif
#endif /* __WinUtil_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  VARIANT_UserSize(     unsigned long *, unsigned long            , VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserMarshal(  unsigned long *, unsigned char *, VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserUnmarshal(unsigned long *, unsigned char *, VARIANT * ); 
void                      __RPC_USER  VARIANT_UserFree(     unsigned long *, VARIANT * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


