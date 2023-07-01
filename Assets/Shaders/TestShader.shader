Shader "Unlit/TestShader"
{
    Properties
    {
        __myText("TestTexture", 2D) = "while" {}
        __color("SphereColor", Color) = (0,0,0,0)
    }
    
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        

            struct vertexInput
            {
                float4 vertex:POSITION;
                float2 uv:TEXCOORD0;
                float3 norm:NORMAL;
            };

            struct vertexOutput
            {
                float4 position:SV_POSITION;
                float2 uv:TEXTCOORD0;
                float3 worldNormal:TEXTCOORD1;
            };

            vertexOutput vert(vertexInput v)
            {
                vertexOutput o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldNormal = mul(unity_WorldToObject, v.norm);
                return o;
            }

            uniform sampler2D __myText;
            uniform fixed4 __color;

            fixed4 frag(vertexOutput v):SV_Target
            {
                fixed4 col = tex2D(__myText, v.uv);
                float3 l = normalize(_WorldSpaceLightPos0);
                float n = normalize(v.worldNormal);
                float dif = max(0.0,dot(n,l));
                return ((1-col) * __color)*dif;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
