Shader "ColorLerp/Colored"
{
	Properties
	{
		_Color ("Main Color", color) = (1,1,1,1)
		_SpecularColor ("Specular Color", color) = (1,1,1,1)
		_SpcularPower ("Specular", Range(0, 20)) = 0.8
		_RimColor ("Rim Color", color) = (1,1,1,1)
		_RimPower ("Rim Specular", Range(0, 20)) = 0.8
}
	SubShader
	{
		Tags { "RenderType"="Opaque" "LightMode"="ForwardBase"}
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
			#include "AutoLight.cginc"
			
			struct appdata
			{
				float4 vertex : POSITION;
				fixed3 normal : NORMAL;
			};

			struct v2f
			{
				
				float2 uv : TEXCOORD0;
				SHADOW_COORDS(1)
				float4 pos : SV_POSITION;
				fixed4 ambient : TEXCOORD3;
				fixed2 lighting : TEXCOORD2;
				fixed3 worldNormal : TEXCOORD4;
				fixed3 viewDir : TEXCOORD5;
				fixed3 worldPos : TEXCOORD7;
				UNITY_FOG_COORDS(6)
				

			};

			fixed4 _Color;
			fixed4 _RimColor;
			fixed4 _SpecularColor;
			fixed _ColorRange;
			fixed _SpcularPower;
			fixed _RimPower;

			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.lighting.x = max(0, dot(o.worldNormal, _WorldSpaceLightPos0.xyz));
				o.ambient = fixed4(ShadeSH9(half4(o.worldNormal,1)),1);
				o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos));
				fixed3 H = normalize(o.viewDir + _WorldSpaceLightPos0.xyz);
				o.lighting.y = pow(max(dot(o.worldNormal, H), 0), _SpcularPower);
				UNITY_TRANSFER_FOG(o,o.pos);
				TRANSFER_SHADOW(o)
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed shadow = SHADOW_ATTENUATION(i);

				fixed4 allColors = ((_Color * ((shadow * i.lighting.x) + i.ambient)) + (_SpecularColor * i.lighting.y)) + (_RimColor * pow(1 - dot(i.worldNormal, i.viewDir), _RimPower));
				UNITY_APPLY_FOG(i.fogCoord, col);
				return allColors;
			}
			ENDCG
			
		}
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
	
}
