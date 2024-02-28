Shader "Custom/BlurMeanFilter"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Size("Filter Size", Range(1, 25)) = 5
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Overlay"
            }

            Pass
            {
                Name "MEAN_FILTER"

                CGPROGRAM
                #pragma vertex vert
                #pragma exclude_renderers gles xbox360 ps3
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _MainTex;
                int _Size;

                fixed4 frag(v2f i) : COLOR
                {
                    fixed4 sum = fixed4(0, 0, 0, 0);

                // Iterate through neighboring pixels
                for (int x = -_Size; x <= _Size; x++)
                {
                    for (int y = -_Size; y <= _Size; y++)
                    {
                        sum += tex2D(_MainTex, i.uv + float2(x, y) / _ScreenParams.xy);
                    }
                }

                // Calculate the average color
                sum /= ((_Size * 2 + 1) * (_Size * 2 + 1));

                return sum;
            }
            ENDCG
        }
        }
}