// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/OceanShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Normal ("Normal", 2D) = "white"{}
		_Adjust ("Ajuste", Range(0, 2)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		sampler2D _Normal;
		fixed _Adjust;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void vert (inout appdata_full v){
			v.vertex.xyz += v.normal * (sin((_Time.y+v.vertex.x))*sin((_Time.y+v.vertex.z)))*_Adjust;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float2 uvnew = float2(IN.uv_MainTex.x+_Time.x,IN.uv_MainTex.y)*0.3;
			fixed4 n = tex2D(_Normal, uvnew);
			float2 uvnew2 = float2(IN.uv_MainTex.x,IN.uv_MainTex.y-_Time.x)*0.3;
			fixed4 n2 = tex2D(_Normal, uvnew2);

			o.Albedo = c.rgb;
			o.Normal = UnpackNormal((n+n2)/2);
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = (c.a+50);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
