Shader "Custom/SpriteShadow" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		[PerRendererData]_MainTex ("Sprite Texture", 2D) = "white" {}
		_Cutoff("Shadow alpha cutoff", Range(0,1)) = 0.5
	}
	SubShader {
		Tags 
		{ 
			"Queue"="Geometry"
			"RenderType"="TransparentCutout"
		}
		LOD 200

		Cull Off

		CGPROGRAM
		// �����o�[�g���C�e�B���O���f���A����т��ׂẴ��C�g�^�C�v�ŃV���h�E��L���ɂ���B
		#pragma surface surf Lambert addshadow fullforwardshadows

		// �V�F�[�_�[���f��3.0�^�[�Q�b�g���g�p���āA���h���̗ǂ��Ɩ��𓾂�B
		#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		fixed _Cutoff;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			clip(o.Alpha - _Cutoff);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
