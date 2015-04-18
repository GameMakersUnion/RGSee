Shader "Custom/Hue" {
	Properties {
		_MainTex ("Main Texture1", 2D) = "white" {}
		_DefaultCol ("Default Color", Color) = (1,1,1,1)
		
		_OneCol ("Player One Color", Color) = (1,1,1,1)
		_TwoCol ("Player Two Color", Color) = (1,1,1,1)
		_ThreeCol ("Player Three Color", Color) = (1,1,1,1)
		
		_OneRad ("Player One Radius", Float) = 1
		_TwoRad ("Player Two Radius", Float) = 1
		_ThreeRad ("Player Three Radius", Float) = 1
		
		_OnePos ("Player One Position", vector) = (0,0,0,0)
		_TwoPos ("Player Two Position", vector) = (0,0,0,0)
		_ThreePos ("Player Three Position", vector) = (0,0,0,0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass {
			CGPROGRAM
			#pragma exclude_renderers xbox360 ps3 flash
			#pragma vertex VS_MAIN
			#pragma fragment FS_MAIN
			
			#include "UnityCG.cginc"
			
			// User defined variables
			uniform float3 _OnePos;
			uniform float3 _TwoPos;
			uniform float3 _ThreePos;
			
			uniform float _OneRad;
			uniform float _TwoRad;
			uniform float _ThreeRad;		
			
			uniform fixed4 _OneCol;
			uniform fixed4 _TwoCol;
			uniform fixed4 _ThreeCol;
			
			uniform fixed4 _DefaultCol;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			
			// Base input structs
			struct FS_INPUT {
				float4 pos 			: SV_POSITION;
				float4 worldPos 	: TEXCOORD2;
				half2 uv 			: TEXCOORD0;
			};
			
			// VERTEX SHADER
			FS_INPUT VS_MAIN (appdata_base i) {
				FS_INPUT o;
				o.pos = mul (UNITY_MATRIX_MVP, i.vertex);
				o.worldPos = mul(_Object2World, i.vertex);
				o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);
				return o;
			}
			// FRAGMENT SHADER
			fixed4 FS_MAIN (FS_INPUT i) : COLOR {
				fixed4 outputCol = _OneCol + _TwoCol + _ThreeCol;

				float oneDist = length(_OnePos - i.worldPos.xyz);
				float twoDist = length(_TwoPos - i.worldPos.xyz);
				float threeDist = length(_ThreePos - i.worldPos.xyz);
				
				if (oneDist < _OneRad && twoDist < _TwoRad && threeDist < _ThreeRad) {
					outputCol = _OneCol + _TwoCol + _ThreeCol;
				} else if (oneDist < _OneRad && twoDist < _TwoRad) {
					outputCol = _OneCol + _TwoCol;
				} else if (oneDist < _OneRad && threeDist < _ThreeRad) {
					outputCol = _OneCol + _ThreeCol;
				} else if (twoDist < _TwoRad && threeDist < _ThreeRad) {
					outputCol = _TwoCol + _ThreeCol;
				} else if (oneDist < _OneRad) {
					outputCol = _OneCol;
				} else if (twoDist < _TwoRad) {
					outputCol = _TwoCol;
				} else if (threeDist < _ThreeRad) {
					outputCol = _ThreeCol;
				} else {
					outputCol = _DefaultCol;				
				}
				
				return tex2D(_MainTex, i.uv) * outputCol;
			}
			ENDCG
		}
	} 
}
