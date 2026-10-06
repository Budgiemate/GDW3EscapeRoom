Shader "Custom/ShroomText"
{
    Properties
    {
        [MainTexture] _BaseMap ("Base Map", 2D) = "white" {}
        [MainColor] _BaseColor ("Base Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        Pass
        {
            Name "ForwardLit"

            Tags
            {
                "LightMode" = "UniversalForward"
            }

            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float4 _BaseColor;
            CBUFFER_END

            // takes in values from manager script
            #define MAX_LIGHTS 16
            float4 _GlobalRevealPositions[MAX_LIGHTS]; 
            int _GlobalRevealCount;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs positionInputs =
                    GetVertexPositionInputs(input.positionOS.xyz);

                output.positionHCS = positionInputs.positionCS;
                output.positionWS = positionInputs.positionWS;

                output.uv = TRANSFORM_TEX(
                    input.uv,
                    _BaseMap
                );

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float finalClipValue = 1.0; 

                for (int i = 0; i < _GlobalRevealCount; i++)
                {
                    float3 lightPos = _GlobalRevealPositions[i].xyz;
                    float lightRadius = _GlobalRevealPositions[i].w;

                    float distanceFromReveal = distance(input.positionWS, lightPos);
                    
                    float currentClip = distanceFromReveal - lightRadius;

                    finalClipValue = min(finalClipValue, currentClip);
                }
                
                clip(finalClipValue);

                half4 color =
                    SAMPLE_TEXTURE2D(
                        _BaseMap,
                        sampler_BaseMap,
                        input.uv
                    ) * _BaseColor;

                return color;
            }

            ENDHLSL
        }
    }
}
