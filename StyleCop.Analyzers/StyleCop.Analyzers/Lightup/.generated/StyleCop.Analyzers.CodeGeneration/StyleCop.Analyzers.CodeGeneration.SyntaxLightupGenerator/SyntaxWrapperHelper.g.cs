// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    internal static class SyntaxWrapperHelper
    {
        private static readonly ImmutableDictionary<Type, Type> WrappedTypes;

        static SyntaxWrapperHelper()
        {
            var csharpCodeAnalysisAssembly = typeof(CSharpSyntaxNode).GetTypeInfo().Assembly;
            var builder = ImmutableDictionary.CreateBuilder<Type, Type>();
            builder.Add(typeof(BaseExpressionColonSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(BaseExpressionColonSyntaxWrapper.WrappedTypeName));

            var baseNamespaceDeclarationSyntaxType = csharpCodeAnalysisAssembly.GetType(BaseNamespaceDeclarationSyntaxWrapper.WrappedTypeName) ?? csharpCodeAnalysisAssembly.GetType(BaseNamespaceDeclarationSyntaxWrapper.FallbackWrappedTypeName);
            builder.Add(typeof(BaseNamespaceDeclarationSyntaxWrapper), baseNamespaceDeclarationSyntaxType);

            var objectCreationExpressionSyntaxType = csharpCodeAnalysisAssembly.GetType(BaseObjectCreationExpressionSyntaxWrapper.WrappedTypeName) ?? csharpCodeAnalysisAssembly.GetType(BaseObjectCreationExpressionSyntaxWrapper.FallbackWrappedTypeName);
            builder.Add(typeof(BaseObjectCreationExpressionSyntaxWrapper), objectCreationExpressionSyntaxType);
            builder.Add(typeof(BaseParameterSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(BaseParameterSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(BinaryPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(BinaryPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(DefaultConstraintSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(DefaultConstraintSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(DiscardPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(DiscardPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(ExpressionColonSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(ExpressionColonSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(ExpressionOrPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(ExpressionOrPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FileScopedNamespaceDeclarationSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FileScopedNamespaceDeclarationSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerCallingConventionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerCallingConventionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerParameterListSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerParameterListSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerParameterSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerParameterSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerTypeSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerTypeSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerUnmanagedCallingConventionListSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(FunctionPointerUnmanagedCallingConventionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(FunctionPointerUnmanagedCallingConventionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(ImplicitObjectCreationExpressionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(ImplicitObjectCreationExpressionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(ImplicitStackAllocArrayCreationExpressionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(ImplicitStackAllocArrayCreationExpressionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(LineDirectivePositionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(LineDirectivePositionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(LineOrSpanDirectiveTriviaSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(LineOrSpanDirectiveTriviaSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(LineSpanDirectiveTriviaSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(LineSpanDirectiveTriviaSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(NullableDirectiveTriviaSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(NullableDirectiveTriviaSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(ParenthesizedPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(ParenthesizedPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(PositionalPatternClauseSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(PositionalPatternClauseSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(PrimaryConstructorBaseTypeSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(PrimaryConstructorBaseTypeSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(PropertyPatternClauseSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(PropertyPatternClauseSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(RangeExpressionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(RangeExpressionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(RecordDeclarationSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(RecordDeclarationSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(RecursivePatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(RecursivePatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(RelationalPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(RelationalPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(SubpatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(SubpatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(SwitchExpressionArmSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(SwitchExpressionArmSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(SwitchExpressionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(SwitchExpressionSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(TypePatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(TypePatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(UnaryPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(UnaryPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(VarPatternSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(VarPatternSyntaxWrapper.WrappedTypeName));
            builder.Add(typeof(WithExpressionSyntaxWrapper), csharpCodeAnalysisAssembly.GetType(WithExpressionSyntaxWrapper.WrappedTypeName));

            WrappedTypes = builder.ToImmutable();
        }

        /// <summary>
        /// Gets the type that is wrapped by the given wrapper.
        /// </summary>
        /// <param name = "wrapperType">Type of the wrapper for which the wrapped type should be retrieved.</param>
        /// <returns>The wrapped type, or null if there is no info.</returns>
        internal static Type GetWrappedType(Type wrapperType)
        {
            if (WrappedTypes.TryGetValue(wrapperType, out Type wrappedType))
            {
                return wrappedType;
            }

            return null;
        }
    }
}
