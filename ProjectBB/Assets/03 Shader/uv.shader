Shader "Custom/uv"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Test ("Test", Range(0,10)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _Test;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex + _Time.y);
            fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Time.y , IN.uv_MainTex.y));
            o.Albedo = c.rgb;
            //o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);
             //o.Emission = 1 - IN.uv_MainTex.x;
            //o.Emission = IN.uv_MainTex.y;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse" 
}
