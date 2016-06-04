Shader "Custom/Stencil Mask With Alpha" {
	Properties
	{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_MainTex("Base (RGB) Transparency (A)", 2D) = "" { }
	_Mask("Culling Mask", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest GEqual[_Cutoff]

	//	Stencil{

	//	Ref 1
	//	Comp always
	//	Pass replace
	//}

		Pass
	{

		SetTexture[_Mask]{ combine texture }

		SetTexture[_MainTex]{ combine texture, previous }

		SetTexture[_MainTex]{
		constantColor[_Color]
		combine previous * constant
	}
	}
	}
}