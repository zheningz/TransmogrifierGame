﻿Shader "Custom/SphereScanner"
{
	Properties
	{
		_Color("Color", Color) = (0,0,0,0)
		_Width("Width", Range(0,0.5)) = 0.2
		_RimAlpha("Rim Alpha", Range(0,1)) = 0
	}

	SubShader
	{
		Blend One One
		ZWrite Off
		Cull Off

		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			CGPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 scrPos:TEXCOORD2;
				float4 vertex : SV_POSITION;
				float depth : DEPTH;
			};

			float _RimAlpha;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.scrPos = ComputeScreenPos(o.vertex);

				o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;

				return o;
			}

			sampler2D _CameraDepthTexture;

			fixed4 _Color;
			float _Width;

			fixed4 frag(v2f i) : SV_Target
			{
				//get depth
				float screenDepth = Linear01Depth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
				float diff = screenDepth - i.depth;

				//intersection
				float intersect = 1 - smoothstep(0, _ProjectionParams.w * _Width, diff);

				//color lerp
				fixed4 glowColor = diff > 0 ? _Color : fixed4(0, 0, 0, 0);

				fixed4 col = glowColor * intersect * _RimAlpha;

				return col;
			}
		ENDCG
		}
	}
}