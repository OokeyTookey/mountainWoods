Shader "ColorSlerp/Sad" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed _Shift;
		fixed4 _Color;
		fixed4 _PlayerPosition;
		fixed _FadeRange;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {

			fixed lum = Luminance(_Color);
			fixed shiftRange = max(min(_FadeRange - length(_PlayerPosition.xyz - IN.worldPos), 1), 0);
			o.Albedo = lum;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
