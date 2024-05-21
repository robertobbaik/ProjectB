Shader "Custom/VCMask"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}
        _MainTex3 ("Albedo (RGB)", 2D) = "white" {}
        _MainTex4 ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("Normalmap", 2D) = "bump"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard noambient

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MainTex4;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
            float2 uv_MainTex4;
            float2 uv_BumpMap;
            float4 color:COLOR;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D (_MainTex2, IN.uv_MainTex);
            fixed4 e = tex2D (_MainTex3, IN.uv_MainTex);
            fixed4 f = tex2D (_MainTex4, IN.uv_MainTex);
            //o.Albedo = c.rgb;

            //o.Albedo = IN.color.rgb;
            o.Albedo = lerp(c.rgb, d.rgb, IN.color.r);
            o.Albedo = lerp(o.Albedo, e.rgb, IN.color.g);
            o.Albedo = lerp(o.Albedo, f.rgb, IN.color.b);
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            o.Metallic = 0;
            o.Smoothness = IN.color.b + IN.color.g + IN.color.r;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
