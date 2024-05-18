Shader "Custom/NewFire"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}

        _Brigtness ("Brightness", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard alpha:fade


        sampler2D _MainTex;
        sampler2D _MainTex2;
        float _Brigtness;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 d = tex2D (_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y) * _Brigtness);
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + d.r);

            o.Emission = c.rgb;// * d.rgb;
            o.Alpha = c.a;// * d.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
