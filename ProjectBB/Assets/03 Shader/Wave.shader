Shader "Custom/Wave"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _FlowSpeed ("Flow Speed", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows


        sampler2D _MainTex;
        float _FlowSpeed;
        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x, IN.uv_MainTex.y + _Time.y * _FlowSpeed));
            //o.Albedo = c.rgb;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
