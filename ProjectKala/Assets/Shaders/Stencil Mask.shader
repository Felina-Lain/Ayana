Shader "Custom/Stencil Mask" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
			//IN THE TAGS WE MAKE THIS IS THE FIRST OBJECT RENDERER, OTHERWISE THE MASK WONT APPLYY
			//THIS IS DONE SAYING GEOMETRY-100
			//Tags{ "RenderType" = "Opaque" "Queue" = "Geometry-100 }

			Tags{ "RenderType" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "Queue" = "Geometry-1" }
			//WE PUT THIS TO NOT RENDER THIS MESH INTO THE SCENE
			//stop the shader writing to the depth buffer. otherwise the objects behind wont render. !!!

			//ColorMask 0
			ZWrite off

			//we start the stencil thing
			Stencil{

			//specify that the stencil value is 1, we have to use the same one to the object shader. 
			Ref 1
			Comp always
			//we replace everything to this stencil . ??
			Pass replace
		}
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
			UsePass "Transparent/Diffuse/FORWARD"
	}
			Fallback "Transparent/VertexLit"
}
