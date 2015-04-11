Shader "Custom/Reveal" {
	Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
		_DefaultCol ("Default Color", Color) = (0.75,0.75,0.75,1)
		_RevealRadius ("Reveal Radius", Float) = 10.0
		_RedPos ("Red Position", vector) = (0,0,0,0)
		_GreenPos ("Green Position", vector) = (0,0,0,0)
		_BluePos ("Blue Position", vector) = (0,0,0,0)
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
			uniform float3 _RedPos;
			uniform float3 _GreenPos;
			uniform float3 _BluePos;			
			uniform float _RevealRadius;
			
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
				fixed4 R = fixed4(1,0,0,1);
				fixed4 G = fixed4(0,1,0,1);
				fixed4 B = fixed4(0,0,1,1);
				fixed4 outputCol = R + G + B;

				float3 redVect = (_RedPos - i.worldPos.xyz);
				float3 greenVect = (_GreenPos - i.worldPos.xyz);
				float3 blueVect = (_BluePos - i.worldPos.xyz);
				
				float redDist = redVect.x * redVect.x + redVect.y * redVect.y + redVect.z * redVect.z;
				float greenDist = greenVect.x * greenVect.x + greenVect.y * greenVect.y + greenVect.z * greenVect.z;
				float blueDist = blueVect.x * blueVect.x + blueVect.y * blueVect.y + blueVect.z * blueVect.z;
				
				if (redDist < _RevealRadius && greenDist < _RevealRadius && blueDist < _RevealRadius) {
					outputCol = R + G + B;
				} else if (redDist < _RevealRadius && greenDist < _RevealRadius) {
					outputCol = R + G;
				} else if (redDist < _RevealRadius && blueDist < _RevealRadius) {
					outputCol = R + B;
				} else if (greenDist < _RevealRadius && blueDist < _RevealRadius) {
					outputCol = G + B;
				} else if (redDist < _RevealRadius) {
					outputCol = R;
				} else if (greenDist < _RevealRadius) {
					outputCol = G;
				} else if (blueDist < _RevealRadius) {
					outputCol = B;
				} else {
					outputCol = _DefaultCol;				
				}
				
				return tex2D(_MainTex, i.uv) * outputCol;
			}
			ENDCG
		}
	} 
}
