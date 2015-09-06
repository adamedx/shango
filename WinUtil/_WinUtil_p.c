
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the proxy stub code */


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

#if !defined(_M_IA64) && !defined(_M_AMD64)

/* verify that the <rpcproxy.h> version is high enough to compile this file*/
#ifndef __REDQ_RPCPROXY_H_VERSION__
#define __REQUIRED_RPCPROXY_H_VERSION__ 440
#endif


#include "rpcproxy.h"
#ifndef __RPCPROXY_H_VERSION__
#error this stub requires an updated version of <rpcproxy.h>
#endif // __RPCPROXY_H_VERSION__


#include "_WinUtil.h"

#define TYPE_FORMAT_STRING_SIZE   1005                              
#define PROC_FORMAT_STRING_SIZE   23                                
#define TRANSMIT_AS_TABLE_SIZE    0            
#define WIRE_MARSHAL_TABLE_SIZE   1            

typedef struct _MIDL_TYPE_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ TYPE_FORMAT_STRING_SIZE ];
    } MIDL_TYPE_FORMAT_STRING;

typedef struct _MIDL_PROC_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ PROC_FORMAT_STRING_SIZE ];
    } MIDL_PROC_FORMAT_STRING;


static RPC_SYNTAX_IDENTIFIER  _RpcTransferSyntax = 
{{0x8A885D04,0x1CEB,0x11C9,{0x9F,0xE8,0x08,0x00,0x2B,0x10,0x48,0x60}},{2,0}};


extern const MIDL_TYPE_FORMAT_STRING __MIDL_TypeFormatString;
extern const MIDL_PROC_FORMAT_STRING __MIDL_ProcFormatString;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWinUtilities_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWinUtilities_ProxyInfo;


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IWinUtilities_SetTransparency_Proxy( 
    IWinUtilities * This,
    /* [in] */ VARIANT hWnd,
    /* [in] */ VARIANT bTransparent,
    /* [in] */ VARIANT ColorRef,
    /* [in] */ VARIANT BlendLevel,
    /* [in] */ VARIANT dwFlags)
{

    HRESULT _RetVal;
    
    RPC_MESSAGE _RpcMessage;
    
    MIDL_STUB_MESSAGE _StubMsg;
    
    RpcTryExcept
        {
        NdrProxyInitialize(
                      ( void *  )This,
                      ( PRPC_MESSAGE  )&_RpcMessage,
                      ( PMIDL_STUB_MESSAGE  )&_StubMsg,
                      ( PMIDL_STUB_DESC  )&Object_StubDesc,
                      7);
        
        
        
        RpcTryFinally
            {
            
            _StubMsg.BufferLength = 0;
            NdrUserMarshalBufferSize( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                      (unsigned char *)&hWnd,
                                      (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalBufferSize( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                      (unsigned char *)&bTransparent,
                                      (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalBufferSize( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                      (unsigned char *)&ColorRef,
                                      (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalBufferSize( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                      (unsigned char *)&BlendLevel,
                                      (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalBufferSize( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                      (unsigned char *)&dwFlags,
                                      (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrProxyGetBuffer(This, &_StubMsg);
            NdrUserMarshalMarshall( (PMIDL_STUB_MESSAGE)& _StubMsg,
                                    (unsigned char *)&hWnd,
                                    (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalMarshall( (PMIDL_STUB_MESSAGE)& _StubMsg,
                                    (unsigned char *)&bTransparent,
                                    (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalMarshall( (PMIDL_STUB_MESSAGE)& _StubMsg,
                                    (unsigned char *)&ColorRef,
                                    (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalMarshall( (PMIDL_STUB_MESSAGE)& _StubMsg,
                                    (unsigned char *)&BlendLevel,
                                    (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrUserMarshalMarshall( (PMIDL_STUB_MESSAGE)& _StubMsg,
                                    (unsigned char *)&dwFlags,
                                    (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994] );
            
            NdrProxySendReceive(This, &_StubMsg);
            
            _StubMsg.BufferStart = (unsigned char *) _RpcMessage.Buffer; 
            _StubMsg.BufferEnd   = _StubMsg.BufferStart + _RpcMessage.BufferLength;
            
            if ( (_RpcMessage.DataRepresentation & 0X0000FFFFUL) != NDR_LOCAL_DATA_REPRESENTATION )
                NdrConvert( (PMIDL_STUB_MESSAGE) &_StubMsg, (PFORMAT_STRING) &__MIDL_ProcFormatString.Format[0] );
            
            _StubMsg.Buffer = (unsigned char *)(((long)_StubMsg.Buffer + 3) & ~ 0x3);
            
            if(_StubMsg.Buffer + 4 > _StubMsg.BufferEnd)
                {
                RpcRaiseException(RPC_X_BAD_STUB_DATA);
                }
            _RetVal = *(( HRESULT * )_StubMsg.Buffer)++;
            
            }
        RpcFinally
            {
            NdrProxyFreeBuffer(This, &_StubMsg);
            
            }
        RpcEndFinally
        
        }
    RpcExcept(_StubMsg.dwStubPhase != PROXY_SENDRECEIVE)
        {
        _RetVal = NdrProxyErrorHandler(RpcExceptionCode());
        }
    RpcEndExcept
    return _RetVal;
}

void __RPC_STUB IWinUtilities_SetTransparency_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase)
{
    VARIANT BlendLevel;
    VARIANT ColorRef;
    HRESULT _RetVal;
    MIDL_STUB_MESSAGE _StubMsg;
    void *_p_BlendLevel;
    void *_p_ColorRef;
    void *_p_bTransparent;
    void *_p_dwFlags;
    void *_p_hWnd;
    VARIANT bTransparent;
    VARIANT dwFlags;
    VARIANT hWnd;
    
NdrStubInitialize(
                     _pRpcMessage,
                     &_StubMsg,
                     &Object_StubDesc,
                     _pRpcChannelBuffer);
    _p_hWnd = &hWnd;
    MIDL_memset(
               _p_hWnd,
               0,
               sizeof( VARIANT  ));
    _p_bTransparent = &bTransparent;
    MIDL_memset(
               _p_bTransparent,
               0,
               sizeof( VARIANT  ));
    _p_ColorRef = &ColorRef;
    MIDL_memset(
               _p_ColorRef,
               0,
               sizeof( VARIANT  ));
    _p_BlendLevel = &BlendLevel;
    MIDL_memset(
               _p_BlendLevel,
               0,
               sizeof( VARIANT  ));
    _p_dwFlags = &dwFlags;
    MIDL_memset(
               _p_dwFlags,
               0,
               sizeof( VARIANT  ));
    RpcTryFinally
        {
        if ( (_pRpcMessage->DataRepresentation & 0X0000FFFFUL) != NDR_LOCAL_DATA_REPRESENTATION )
            NdrConvert( (PMIDL_STUB_MESSAGE) &_StubMsg, (PFORMAT_STRING) &__MIDL_ProcFormatString.Format[0] );
        
        NdrUserMarshalUnmarshall( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                  (unsigned char * *)&_p_hWnd,
                                  (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994],
                                  (unsigned char)0 );
        
        NdrUserMarshalUnmarshall( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                  (unsigned char * *)&_p_bTransparent,
                                  (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994],
                                  (unsigned char)0 );
        
        NdrUserMarshalUnmarshall( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                  (unsigned char * *)&_p_ColorRef,
                                  (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994],
                                  (unsigned char)0 );
        
        NdrUserMarshalUnmarshall( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                  (unsigned char * *)&_p_BlendLevel,
                                  (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994],
                                  (unsigned char)0 );
        
        NdrUserMarshalUnmarshall( (PMIDL_STUB_MESSAGE) &_StubMsg,
                                  (unsigned char * *)&_p_dwFlags,
                                  (PFORMAT_STRING) &__MIDL_TypeFormatString.Format[994],
                                  (unsigned char)0 );
        
        
        *_pdwStubPhase = STUB_CALL_SERVER;
        _RetVal = (((IWinUtilities*) ((CStdStubBuffer *)This)->pvServerObject)->lpVtbl) -> SetTransparency(
                   (IWinUtilities *) ((CStdStubBuffer *)This)->pvServerObject,
                   hWnd,
                   bTransparent,
                   ColorRef,
                   BlendLevel,
                   dwFlags);
        
        *_pdwStubPhase = STUB_MARSHAL;
        
        _StubMsg.BufferLength = 8;
        NdrStubGetBuffer(This, _pRpcChannelBuffer, &_StubMsg);
        _StubMsg.Buffer = (unsigned char *)(((long)_StubMsg.Buffer + 3) & ~ 0x3);
        *(( HRESULT * )_StubMsg.Buffer)++ = _RetVal;
        
        }
    RpcFinally
        {
        NdrUserMarshalFree( &_StubMsg,
                            (unsigned char *)&hWnd,
                            &__MIDL_TypeFormatString.Format[994] );
        
        NdrUserMarshalFree( &_StubMsg,
                            (unsigned char *)&bTransparent,
                            &__MIDL_TypeFormatString.Format[994] );
        
        NdrUserMarshalFree( &_StubMsg,
                            (unsigned char *)&ColorRef,
                            &__MIDL_TypeFormatString.Format[994] );
        
        NdrUserMarshalFree( &_StubMsg,
                            (unsigned char *)&BlendLevel,
                            &__MIDL_TypeFormatString.Format[994] );
        
        NdrUserMarshalFree( &_StubMsg,
                            (unsigned char *)&dwFlags,
                            &__MIDL_TypeFormatString.Format[994] );
        
        }
    RpcEndFinally
    _pRpcMessage->BufferLength = 
        (unsigned int)(_StubMsg.Buffer - (unsigned char *)_pRpcMessage->Buffer);
    
}


extern const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ];

#if !defined(__RPC_WIN32__)
#error  Invalid build platform for this stub.
#endif

#if !(TARGET_IS_NT40_OR_LATER)
#error You need a Windows NT 4.0 or later to run this stub because it uses these features:
#error   [wire_marshal] or [user_marshal] attribute.
#error However, your C/C++ compilation flags indicate you intend to run this app on earlier systems.
#error This app will die there with the RPC_X_WRONG_STUB_VERSION error.
#endif


static const MIDL_PROC_FORMAT_STRING __MIDL_ProcFormatString =
    {
        0,
        {
			
			0x4d,		/* FC_IN_PARAM */
			0x4,		/* x86 stack size = 4 */
/*  2 */	NdrFcShort( 0x3e2 ),	/* Type Offset=994 */
/*  4 */	
			0x4d,		/* FC_IN_PARAM */
			0x4,		/* x86 stack size = 4 */
/*  6 */	NdrFcShort( 0x3e2 ),	/* Type Offset=994 */
/*  8 */	
			0x4d,		/* FC_IN_PARAM */
			0x4,		/* x86 stack size = 4 */
/* 10 */	NdrFcShort( 0x3e2 ),	/* Type Offset=994 */
/* 12 */	
			0x4d,		/* FC_IN_PARAM */
			0x4,		/* x86 stack size = 4 */
/* 14 */	NdrFcShort( 0x3e2 ),	/* Type Offset=994 */
/* 16 */	
			0x4d,		/* FC_IN_PARAM */
			0x4,		/* x86 stack size = 4 */
/* 18 */	NdrFcShort( 0x3e2 ),	/* Type Offset=994 */
/* 20 */	0x53,		/* FC_RETURN_PARAM_BASETYPE */
			0x8,		/* FC_LONG */

			0x0
        }
    };

static const MIDL_TYPE_FORMAT_STRING __MIDL_TypeFormatString =
    {
        0,
        {
			NdrFcShort( 0x0 ),	/* 0 */
/*  2 */	
			0x12, 0x0,	/* FC_UP */
/*  4 */	NdrFcShort( 0x3ca ),	/* Offset= 970 (974) */
/*  6 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/*  8 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 10 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 12 */	NdrFcShort( 0x2 ),	/* Offset= 2 (14) */
/* 14 */	NdrFcShort( 0x10 ),	/* 16 */
/* 16 */	NdrFcShort( 0x2f ),	/* 47 */
/* 18 */	NdrFcLong( 0x14 ),	/* 20 */
/* 22 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 24 */	NdrFcLong( 0x3 ),	/* 3 */
/* 28 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 30 */	NdrFcLong( 0x11 ),	/* 17 */
/* 34 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 36 */	NdrFcLong( 0x2 ),	/* 2 */
/* 40 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 42 */	NdrFcLong( 0x4 ),	/* 4 */
/* 46 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 48 */	NdrFcLong( 0x5 ),	/* 5 */
/* 52 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 54 */	NdrFcLong( 0xb ),	/* 11 */
/* 58 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 60 */	NdrFcLong( 0xa ),	/* 10 */
/* 64 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 66 */	NdrFcLong( 0x6 ),	/* 6 */
/* 70 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (302) */
/* 72 */	NdrFcLong( 0x7 ),	/* 7 */
/* 76 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 78 */	NdrFcLong( 0x8 ),	/* 8 */
/* 82 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (308) */
/* 84 */	NdrFcLong( 0xd ),	/* 13 */
/* 88 */	NdrFcShort( 0xf4 ),	/* Offset= 244 (332) */
/* 90 */	NdrFcLong( 0x9 ),	/* 9 */
/* 94 */	NdrFcShort( 0x100 ),	/* Offset= 256 (350) */
/* 96 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 100 */	NdrFcShort( 0x10c ),	/* Offset= 268 (368) */
/* 102 */	NdrFcLong( 0x24 ),	/* 36 */
/* 106 */	NdrFcShort( 0x31a ),	/* Offset= 794 (900) */
/* 108 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 112 */	NdrFcShort( 0x314 ),	/* Offset= 788 (900) */
/* 114 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 118 */	NdrFcShort( 0x312 ),	/* Offset= 786 (904) */
/* 120 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 124 */	NdrFcShort( 0x310 ),	/* Offset= 784 (908) */
/* 126 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 130 */	NdrFcShort( 0x30e ),	/* Offset= 782 (912) */
/* 132 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 136 */	NdrFcShort( 0x30c ),	/* Offset= 780 (916) */
/* 138 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 142 */	NdrFcShort( 0x30a ),	/* Offset= 778 (920) */
/* 144 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 148 */	NdrFcShort( 0x308 ),	/* Offset= 776 (924) */
/* 150 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 154 */	NdrFcShort( 0x2f2 ),	/* Offset= 754 (908) */
/* 156 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 160 */	NdrFcShort( 0x2f0 ),	/* Offset= 752 (912) */
/* 162 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 166 */	NdrFcShort( 0x2fa ),	/* Offset= 762 (928) */
/* 168 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 172 */	NdrFcShort( 0x2f0 ),	/* Offset= 752 (924) */
/* 174 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 178 */	NdrFcShort( 0x2f2 ),	/* Offset= 754 (932) */
/* 180 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 184 */	NdrFcShort( 0x2f0 ),	/* Offset= 752 (936) */
/* 186 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 190 */	NdrFcShort( 0x2ee ),	/* Offset= 750 (940) */
/* 192 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 196 */	NdrFcShort( 0x2ec ),	/* Offset= 748 (944) */
/* 198 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 202 */	NdrFcShort( 0x2ea ),	/* Offset= 746 (948) */
/* 204 */	NdrFcLong( 0x10 ),	/* 16 */
/* 208 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 210 */	NdrFcLong( 0x12 ),	/* 18 */
/* 214 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 216 */	NdrFcLong( 0x13 ),	/* 19 */
/* 220 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 222 */	NdrFcLong( 0x15 ),	/* 21 */
/* 226 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 228 */	NdrFcLong( 0x16 ),	/* 22 */
/* 232 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 234 */	NdrFcLong( 0x17 ),	/* 23 */
/* 238 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 240 */	NdrFcLong( 0xe ),	/* 14 */
/* 244 */	NdrFcShort( 0x2c8 ),	/* Offset= 712 (956) */
/* 246 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 250 */	NdrFcShort( 0x2cc ),	/* Offset= 716 (966) */
/* 252 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 256 */	NdrFcShort( 0x2ca ),	/* Offset= 714 (970) */
/* 258 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 262 */	NdrFcShort( 0x286 ),	/* Offset= 646 (908) */
/* 264 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 268 */	NdrFcShort( 0x284 ),	/* Offset= 644 (912) */
/* 270 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 274 */	NdrFcShort( 0x282 ),	/* Offset= 642 (916) */
/* 276 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 280 */	NdrFcShort( 0x278 ),	/* Offset= 632 (912) */
/* 282 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 286 */	NdrFcShort( 0x272 ),	/* Offset= 626 (912) */
/* 288 */	NdrFcLong( 0x0 ),	/* 0 */
/* 292 */	NdrFcShort( 0x0 ),	/* Offset= 0 (292) */
/* 294 */	NdrFcLong( 0x1 ),	/* 1 */
/* 298 */	NdrFcShort( 0x0 ),	/* Offset= 0 (298) */
/* 300 */	NdrFcShort( 0xffffffff ),	/* Offset= -1 (299) */
/* 302 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 304 */	NdrFcShort( 0x8 ),	/* 8 */
/* 306 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 308 */	
			0x12, 0x0,	/* FC_UP */
/* 310 */	NdrFcShort( 0xc ),	/* Offset= 12 (322) */
/* 312 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 314 */	NdrFcShort( 0x2 ),	/* 2 */
/* 316 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 318 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 320 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 322 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 324 */	NdrFcShort( 0x8 ),	/* 8 */
/* 326 */	NdrFcShort( 0xfffffff2 ),	/* Offset= -14 (312) */
/* 328 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 330 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 332 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 334 */	NdrFcLong( 0x0 ),	/* 0 */
/* 338 */	NdrFcShort( 0x0 ),	/* 0 */
/* 340 */	NdrFcShort( 0x0 ),	/* 0 */
/* 342 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 344 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 346 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 348 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 350 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 352 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 356 */	NdrFcShort( 0x0 ),	/* 0 */
/* 358 */	NdrFcShort( 0x0 ),	/* 0 */
/* 360 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 362 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 364 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 366 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 368 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 370 */	NdrFcShort( 0x2 ),	/* Offset= 2 (372) */
/* 372 */	
			0x12, 0x0,	/* FC_UP */
/* 374 */	NdrFcShort( 0x1fc ),	/* Offset= 508 (882) */
/* 376 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 378 */	NdrFcShort( 0x18 ),	/* 24 */
/* 380 */	NdrFcShort( 0xa ),	/* 10 */
/* 382 */	NdrFcLong( 0x8 ),	/* 8 */
/* 386 */	NdrFcShort( 0x58 ),	/* Offset= 88 (474) */
/* 388 */	NdrFcLong( 0xd ),	/* 13 */
/* 392 */	NdrFcShort( 0x78 ),	/* Offset= 120 (512) */
/* 394 */	NdrFcLong( 0x9 ),	/* 9 */
/* 398 */	NdrFcShort( 0x94 ),	/* Offset= 148 (546) */
/* 400 */	NdrFcLong( 0xc ),	/* 12 */
/* 404 */	NdrFcShort( 0xbc ),	/* Offset= 188 (592) */
/* 406 */	NdrFcLong( 0x24 ),	/* 36 */
/* 410 */	NdrFcShort( 0x114 ),	/* Offset= 276 (686) */
/* 412 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 416 */	NdrFcShort( 0x130 ),	/* Offset= 304 (720) */
/* 418 */	NdrFcLong( 0x10 ),	/* 16 */
/* 422 */	NdrFcShort( 0x148 ),	/* Offset= 328 (750) */
/* 424 */	NdrFcLong( 0x2 ),	/* 2 */
/* 428 */	NdrFcShort( 0x160 ),	/* Offset= 352 (780) */
/* 430 */	NdrFcLong( 0x3 ),	/* 3 */
/* 434 */	NdrFcShort( 0x178 ),	/* Offset= 376 (810) */
/* 436 */	NdrFcLong( 0x14 ),	/* 20 */
/* 440 */	NdrFcShort( 0x190 ),	/* Offset= 400 (840) */
/* 442 */	NdrFcShort( 0xffffffff ),	/* Offset= -1 (441) */
/* 444 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 446 */	NdrFcShort( 0x4 ),	/* 4 */
/* 448 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 450 */	NdrFcShort( 0x0 ),	/* 0 */
/* 452 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 454 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 456 */	NdrFcShort( 0x4 ),	/* 4 */
/* 458 */	NdrFcShort( 0x0 ),	/* 0 */
/* 460 */	NdrFcShort( 0x1 ),	/* 1 */
/* 462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 466 */	0x12, 0x0,	/* FC_UP */
/* 468 */	NdrFcShort( 0xffffff6e ),	/* Offset= -146 (322) */
/* 470 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 472 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 474 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 476 */	NdrFcShort( 0x8 ),	/* 8 */
/* 478 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 480 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 482 */	NdrFcShort( 0x4 ),	/* 4 */
/* 484 */	NdrFcShort( 0x4 ),	/* 4 */
/* 486 */	0x11, 0x0,	/* FC_RP */
/* 488 */	NdrFcShort( 0xffffffd4 ),	/* Offset= -44 (444) */
/* 490 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 492 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 494 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 496 */	NdrFcShort( 0x0 ),	/* 0 */
/* 498 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 500 */	NdrFcShort( 0x0 ),	/* 0 */
/* 502 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 506 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 508 */	NdrFcShort( 0xffffff50 ),	/* Offset= -176 (332) */
/* 510 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 512 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 514 */	NdrFcShort( 0x8 ),	/* 8 */
/* 516 */	NdrFcShort( 0x0 ),	/* 0 */
/* 518 */	NdrFcShort( 0x6 ),	/* Offset= 6 (524) */
/* 520 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 522 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 524 */	
			0x11, 0x0,	/* FC_RP */
/* 526 */	NdrFcShort( 0xffffffe0 ),	/* Offset= -32 (494) */
/* 528 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 530 */	NdrFcShort( 0x0 ),	/* 0 */
/* 532 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 534 */	NdrFcShort( 0x0 ),	/* 0 */
/* 536 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 540 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 542 */	NdrFcShort( 0xffffff40 ),	/* Offset= -192 (350) */
/* 544 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 546 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 548 */	NdrFcShort( 0x8 ),	/* 8 */
/* 550 */	NdrFcShort( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0x6 ),	/* Offset= 6 (558) */
/* 554 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 556 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 558 */	
			0x11, 0x0,	/* FC_RP */
/* 560 */	NdrFcShort( 0xffffffe0 ),	/* Offset= -32 (528) */
/* 562 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 564 */	NdrFcShort( 0x4 ),	/* 4 */
/* 566 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 568 */	NdrFcShort( 0x0 ),	/* 0 */
/* 570 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 572 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 574 */	NdrFcShort( 0x4 ),	/* 4 */
/* 576 */	NdrFcShort( 0x0 ),	/* 0 */
/* 578 */	NdrFcShort( 0x1 ),	/* 1 */
/* 580 */	NdrFcShort( 0x0 ),	/* 0 */
/* 582 */	NdrFcShort( 0x0 ),	/* 0 */
/* 584 */	0x12, 0x0,	/* FC_UP */
/* 586 */	NdrFcShort( 0x184 ),	/* Offset= 388 (974) */
/* 588 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 590 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 592 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 594 */	NdrFcShort( 0x8 ),	/* 8 */
/* 596 */	NdrFcShort( 0x0 ),	/* 0 */
/* 598 */	NdrFcShort( 0x6 ),	/* Offset= 6 (604) */
/* 600 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 602 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 604 */	
			0x11, 0x0,	/* FC_RP */
/* 606 */	NdrFcShort( 0xffffffd4 ),	/* Offset= -44 (562) */
/* 608 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 610 */	NdrFcLong( 0x2f ),	/* 47 */
/* 614 */	NdrFcShort( 0x0 ),	/* 0 */
/* 616 */	NdrFcShort( 0x0 ),	/* 0 */
/* 618 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 620 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 622 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 624 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 626 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 628 */	NdrFcShort( 0x1 ),	/* 1 */
/* 630 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 632 */	NdrFcShort( 0x4 ),	/* 4 */
/* 634 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 636 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 638 */	NdrFcShort( 0x10 ),	/* 16 */
/* 640 */	NdrFcShort( 0x0 ),	/* 0 */
/* 642 */	NdrFcShort( 0xa ),	/* Offset= 10 (652) */
/* 644 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 646 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 648 */	NdrFcShort( 0xffffffd8 ),	/* Offset= -40 (608) */
/* 650 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 652 */	
			0x12, 0x0,	/* FC_UP */
/* 654 */	NdrFcShort( 0xffffffe4 ),	/* Offset= -28 (626) */
/* 656 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 658 */	NdrFcShort( 0x4 ),	/* 4 */
/* 660 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 662 */	NdrFcShort( 0x0 ),	/* 0 */
/* 664 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 666 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 668 */	NdrFcShort( 0x4 ),	/* 4 */
/* 670 */	NdrFcShort( 0x0 ),	/* 0 */
/* 672 */	NdrFcShort( 0x1 ),	/* 1 */
/* 674 */	NdrFcShort( 0x0 ),	/* 0 */
/* 676 */	NdrFcShort( 0x0 ),	/* 0 */
/* 678 */	0x12, 0x0,	/* FC_UP */
/* 680 */	NdrFcShort( 0xffffffd4 ),	/* Offset= -44 (636) */
/* 682 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 684 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 686 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 688 */	NdrFcShort( 0x8 ),	/* 8 */
/* 690 */	NdrFcShort( 0x0 ),	/* 0 */
/* 692 */	NdrFcShort( 0x6 ),	/* Offset= 6 (698) */
/* 694 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 696 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 698 */	
			0x11, 0x0,	/* FC_RP */
/* 700 */	NdrFcShort( 0xffffffd4 ),	/* Offset= -44 (656) */
/* 702 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 704 */	NdrFcShort( 0x8 ),	/* 8 */
/* 706 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 708 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 710 */	NdrFcShort( 0x10 ),	/* 16 */
/* 712 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 714 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 716 */	0x0,		/* 0 */
			NdrFcShort( 0xfffffff1 ),	/* Offset= -15 (702) */
			0x5b,		/* FC_END */
/* 720 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 722 */	NdrFcShort( 0x18 ),	/* 24 */
/* 724 */	NdrFcShort( 0x0 ),	/* 0 */
/* 726 */	NdrFcShort( 0xa ),	/* Offset= 10 (736) */
/* 728 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 730 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 732 */	NdrFcShort( 0xffffffe8 ),	/* Offset= -24 (708) */
/* 734 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 736 */	
			0x11, 0x0,	/* FC_RP */
/* 738 */	NdrFcShort( 0xffffff0c ),	/* Offset= -244 (494) */
/* 740 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 742 */	NdrFcShort( 0x1 ),	/* 1 */
/* 744 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 746 */	NdrFcShort( 0x0 ),	/* 0 */
/* 748 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 750 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 752 */	NdrFcShort( 0x8 ),	/* 8 */
/* 754 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 756 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 758 */	NdrFcShort( 0x4 ),	/* 4 */
/* 760 */	NdrFcShort( 0x4 ),	/* 4 */
/* 762 */	0x12, 0x0,	/* FC_UP */
/* 764 */	NdrFcShort( 0xffffffe8 ),	/* Offset= -24 (740) */
/* 766 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 768 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 770 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 772 */	NdrFcShort( 0x2 ),	/* 2 */
/* 774 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 780 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 782 */	NdrFcShort( 0x8 ),	/* 8 */
/* 784 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 786 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 788 */	NdrFcShort( 0x4 ),	/* 4 */
/* 790 */	NdrFcShort( 0x4 ),	/* 4 */
/* 792 */	0x12, 0x0,	/* FC_UP */
/* 794 */	NdrFcShort( 0xffffffe8 ),	/* Offset= -24 (770) */
/* 796 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 798 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 800 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 802 */	NdrFcShort( 0x4 ),	/* 4 */
/* 804 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 806 */	NdrFcShort( 0x0 ),	/* 0 */
/* 808 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 810 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 812 */	NdrFcShort( 0x8 ),	/* 8 */
/* 814 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 816 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 818 */	NdrFcShort( 0x4 ),	/* 4 */
/* 820 */	NdrFcShort( 0x4 ),	/* 4 */
/* 822 */	0x12, 0x0,	/* FC_UP */
/* 824 */	NdrFcShort( 0xffffffe8 ),	/* Offset= -24 (800) */
/* 826 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 828 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 830 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 832 */	NdrFcShort( 0x8 ),	/* 8 */
/* 834 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 836 */	NdrFcShort( 0x0 ),	/* 0 */
/* 838 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 840 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 842 */	NdrFcShort( 0x8 ),	/* 8 */
/* 844 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 846 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 848 */	NdrFcShort( 0x4 ),	/* 4 */
/* 850 */	NdrFcShort( 0x4 ),	/* 4 */
/* 852 */	0x12, 0x0,	/* FC_UP */
/* 854 */	NdrFcShort( 0xffffffe8 ),	/* Offset= -24 (830) */
/* 856 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 858 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 860 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 862 */	NdrFcShort( 0x8 ),	/* 8 */
/* 864 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 866 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 868 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 870 */	NdrFcShort( 0x8 ),	/* 8 */
/* 872 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 874 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 876 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 878 */	NdrFcShort( 0xffffffee ),	/* Offset= -18 (860) */
/* 880 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 882 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 884 */	NdrFcShort( 0x28 ),	/* 40 */
/* 886 */	NdrFcShort( 0xffffffee ),	/* Offset= -18 (868) */
/* 888 */	NdrFcShort( 0x0 ),	/* Offset= 0 (888) */
/* 890 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 892 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 894 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 896 */	NdrFcShort( 0xfffffdf8 ),	/* Offset= -520 (376) */
/* 898 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 900 */	
			0x12, 0x0,	/* FC_UP */
/* 902 */	NdrFcShort( 0xfffffef6 ),	/* Offset= -266 (636) */
/* 904 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 906 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 908 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 910 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 912 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 914 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 916 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 918 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 920 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 922 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 924 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 926 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 928 */	
			0x12, 0x0,	/* FC_UP */
/* 930 */	NdrFcShort( 0xfffffd8c ),	/* Offset= -628 (302) */
/* 932 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 934 */	NdrFcShort( 0xfffffd8e ),	/* Offset= -626 (308) */
/* 936 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 938 */	NdrFcShort( 0xfffffda2 ),	/* Offset= -606 (332) */
/* 940 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 942 */	NdrFcShort( 0xfffffdb0 ),	/* Offset= -592 (350) */
/* 944 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 946 */	NdrFcShort( 0xfffffdbe ),	/* Offset= -578 (368) */
/* 948 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 950 */	NdrFcShort( 0x2 ),	/* Offset= 2 (952) */
/* 952 */	
			0x12, 0x0,	/* FC_UP */
/* 954 */	NdrFcShort( 0x14 ),	/* Offset= 20 (974) */
/* 956 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 958 */	NdrFcShort( 0x10 ),	/* 16 */
/* 960 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 962 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 964 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 966 */	
			0x12, 0x0,	/* FC_UP */
/* 968 */	NdrFcShort( 0xfffffff4 ),	/* Offset= -12 (956) */
/* 970 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 972 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 974 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 976 */	NdrFcShort( 0x20 ),	/* 32 */
/* 978 */	NdrFcShort( 0x0 ),	/* 0 */
/* 980 */	NdrFcShort( 0x0 ),	/* Offset= 0 (980) */
/* 982 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 984 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 986 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 988 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 990 */	NdrFcShort( 0xfffffc28 ),	/* Offset= -984 (6) */
/* 992 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 994 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 996 */	NdrFcShort( 0x0 ),	/* 0 */
/* 998 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1000 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0xfffffc18 ),	/* Offset= -1000 (2) */

			0x0
        }
    };

static const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ] = 
        {
            
            {
            VARIANT_UserSize
            ,VARIANT_UserMarshal
            ,VARIANT_UserUnmarshal
            ,VARIANT_UserFree
            }

        };



/* Object interface: IUnknown, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IDispatch, ver. 0.0,
   GUID={0x00020400,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IWinUtilities, ver. 0.0,
   GUID={0xD1A001AF,0x641A,0x4767,{0x82,0xFA,0xE4,0x08,0x20,0xDD,0x6B,0x6E}} */

#pragma code_seg(".orpc")
static const unsigned short IWinUtilities_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IWinUtilities_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWinUtilities_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWinUtilities_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWinUtilities_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWinUtilitiesProxyVtbl = 
{
    &IID_IWinUtilities,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* IDispatch_GetTypeInfoCount_Proxy */ ,
    0 /* IDispatch_GetTypeInfo_Proxy */ ,
    0 /* IDispatch_GetIDsOfNames_Proxy */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    IWinUtilities_SetTransparency_Proxy
};


static const PRPC_STUB_FUNCTION IWinUtilities_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    IWinUtilities_SetTransparency_Stub
};

CInterfaceStubVtbl _IWinUtilitiesStubVtbl =
{
    &IID_IWinUtilities,
    &IWinUtilities_ServerInfo,
    8,
    &IWinUtilities_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};

static const MIDL_STUB_DESC Object_StubDesc = 
    {
    0,
    NdrOleAllocate,
    NdrOleFree,
    0,
    0,
    0,
    0,
    0,
    __MIDL_TypeFormatString.Format,
    1, /* -error bounds_check flag */
    0x20000, /* Ndr library version */
    0,
    0x600015b, /* MIDL Version 6.0.347 */
    0,
    UserMarshalRoutines,
    0,  /* notify & notify_flag routine table */
    0x1, /* MIDL flag */
    0, /* cs routines */
    0,   /* proxy/server info */
    0   /* Reserved5 */
    };

const CInterfaceProxyVtbl * __WinUtil_ProxyVtblList[] = 
{
    ( CInterfaceProxyVtbl *) &_IWinUtilitiesProxyVtbl,
    0
};

const CInterfaceStubVtbl * __WinUtil_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IWinUtilitiesStubVtbl,
    0
};

PCInterfaceName const __WinUtil_InterfaceNamesList[] = 
{
    "IWinUtilities",
    0
};

const IID *  __WinUtil_BaseIIDList[] = 
{
    &IID_IDispatch,
    0
};


#define __WinUtil_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __WinUtil, pIID, n)

int __stdcall __WinUtil_IID_Lookup( const IID * pIID, int * pIndex )
{
    
    if(!__WinUtil_CHECK_IID(0))
        {
        *pIndex = 0;
        return 1;
        }

    return 0;
}

const ExtendedProxyFileInfo _WinUtil_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __WinUtil_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __WinUtil_StubVtblList,
    (const PCInterfaceName * ) & __WinUtil_InterfaceNamesList,
    (const IID ** ) & __WinUtil_BaseIIDList,
    & __WinUtil_IID_Lookup, 
    1,
    1,
    0, /* table of [async_uuid] interfaces */
    0, /* Filler1 */
    0, /* Filler2 */
    0  /* Filler3 */
};


#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

