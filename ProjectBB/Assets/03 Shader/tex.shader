Shader "Custom/tex"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Red ("Red", Range(0,1)) = 0
        _Green ("Green", Range(0,1)) = 0
        _Blue ("Blue", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _Red;
        float _Green;
        float _Blue;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = (c.r + c.g + c.b) / 3;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
