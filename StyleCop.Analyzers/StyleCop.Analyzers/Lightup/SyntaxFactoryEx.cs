// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable disable

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class SyntaxFactoryEx
    {
        private static readonly Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode> PositionalPatternClauseAccessor1;
        private static readonly Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode> PositionalPatternClauseAccessor2;
        private static readonly Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode> PropertyPatternClauseAccessor1;
        private static readonly Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode> PropertyPatternClauseAccessor2;
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode> ParenthesizedPatternAccessor1;
        private static readonly Func<SyntaxToken, CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode> ParenthesizedPatternAccessor3;
        private static readonly Func<TypeSyntax, CSharpSyntaxNode> TupleElementAccessor1;
        private static readonly Func<TypeSyntax, SyntaxToken, CSharpSyntaxNode> TupleElementAccessor2;
        private static readonly Func<SeparatedSyntaxList<ArgumentSyntax>, ExpressionSyntax> TupleExpressionAccessor1;
        private static readonly Func<SyntaxToken, SeparatedSyntaxList<ArgumentSyntax>, SyntaxToken, ExpressionSyntax> TupleExpressionAccessor2;

        static SyntaxFactoryEx()
        {
            var positionalPatternClauseMethods = typeof(SyntaxFactory).GetTypeInfo().GetDeclaredMethods(nameof(PositionalPatternClause));
            var positionalPatternClauseMethod = positionalPatternClauseMethods.FirstOrDefault(method => method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(SeparatedSyntaxList<>).MakeGenericType(SyntaxWrapperHelper.GetWrappedType(typeof(SubpatternSyntaxWrapper))));
            if (positionalPatternClauseMethod is object)
            {
                var subpatternsParameter = Expression.Parameter(typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>), "subpatterns");
                var underlyingListProperty = typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>).GetTypeInfo().GetDeclaredProperty(nameof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>.UnderlyingList));
                Expression<Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>>(
                        Expression.Call(
                            positionalPatternClauseMethod,
                            Expression.Convert(
                                Expression.Call(subpatternsParameter, underlyingListProperty.GetMethod),
                                positionalPatternClauseMethod.GetParameters()[0].ParameterType)),
                        subpatternsParameter);
                PositionalPatternClauseAccessor1 = expression.Compile();
            }
            else
            {
                PositionalPatternClauseAccessor1 = ThrowNotSupportedOnFallback<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>(nameof(SyntaxFactory), nameof(PositionalPatternClause));
            }

            positionalPatternClauseMethod = positionalPatternClauseMethods.FirstOrDefault(method => method.GetParameters().Length == 3
                && method.GetParameters()[0].ParameterType == typeof(SyntaxToken)
                && method.GetParameters()[1].ParameterType == typeof(SeparatedSyntaxList<>).MakeGenericType(SyntaxWrapperHelper.GetWrappedType(typeof(SubpatternSyntaxWrapper)))
                && method.GetParameters()[2].ParameterType == typeof(SyntaxToken));
            if (positionalPatternClauseMethod is object)
            {
                var openParenTokenParameter = Expression.Parameter(typeof(SyntaxToken), "openParenToken");
                var subpatternsParameter = Expression.Parameter(typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>), "subpatterns");
                var closeParenTokenParameter = Expression.Parameter(typeof(SyntaxToken), "closeParenToken");

                var underlyingListProperty = typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>).GetTypeInfo().GetDeclaredProperty(nameof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>.UnderlyingList));

                Expression<Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode>>(
                        Expression.Call(
                            positionalPatternClauseMethod,
                            openParenTokenParameter,
                            Expression.Convert(
                                Expression.Call(subpatternsParameter, underlyingListProperty.GetMethod),
                                positionalPatternClauseMethod.GetParameters()[1].ParameterType),
                            closeParenTokenParameter),
                        openParenTokenParameter,
                        subpatternsParameter,
                        closeParenTokenParameter);
                PositionalPatternClauseAccessor2 = expression.Compile();
            }
            else
            {
                PositionalPatternClauseAccessor2 = ThrowNotSupportedOnFallback<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, TypeSyntax>(nameof(SyntaxFactory), nameof(PositionalPatternClause));
            }

            var propertyPatternClauseMethods = typeof(SyntaxFactory).GetTypeInfo().GetDeclaredMethods(nameof(PropertyPatternClause));
            var propertyPatternClauseMethod = propertyPatternClauseMethods.FirstOrDefault(method => method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(SeparatedSyntaxList<>).MakeGenericType(SyntaxWrapperHelper.GetWrappedType(typeof(SubpatternSyntaxWrapper))));
            if (propertyPatternClauseMethod is object)
            {
                var subpatternsParameter = Expression.Parameter(typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>), "subpatterns");
                var underlyingListProperty = typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>).GetTypeInfo().GetDeclaredProperty(nameof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>.UnderlyingList));
                Expression<Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>>(
                        Expression.Call(
                            propertyPatternClauseMethod,
                            Expression.Convert(
                                Expression.Call(subpatternsParameter, underlyingListProperty.GetMethod),
                                propertyPatternClauseMethod.GetParameters()[0].ParameterType)),
                        subpatternsParameter);
                PropertyPatternClauseAccessor1 = expression.Compile();
            }
            else
            {
                PropertyPatternClauseAccessor1 = ThrowNotSupportedOnFallback<SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, CSharpSyntaxNode>(nameof(SyntaxFactory), nameof(PropertyPatternClause));
            }

            propertyPatternClauseMethod = propertyPatternClauseMethods.FirstOrDefault(method => method.GetParameters().Length == 3
                && method.GetParameters()[0].ParameterType == typeof(SyntaxToken)
                && method.GetParameters()[1].ParameterType == typeof(SeparatedSyntaxList<>).MakeGenericType(SyntaxWrapperHelper.GetWrappedType(typeof(SubpatternSyntaxWrapper)))
                && method.GetParameters()[2].ParameterType == typeof(SyntaxToken));
            if (propertyPatternClauseMethod is object)
            {
                var openBraceTokenParameter = Expression.Parameter(typeof(SyntaxToken), "openBraceToken");
                var subpatternsParameter = Expression.Parameter(typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>), "subpatterns");
                var closeBraceTokenParameter = Expression.Parameter(typeof(SyntaxToken), "closeBraceToken");

                var underlyingListProperty = typeof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>).GetTypeInfo().GetDeclaredProperty(nameof(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>.UnderlyingList));

                Expression<Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, CSharpSyntaxNode>>(
                        Expression.Call(
                            propertyPatternClauseMethod,
                            openBraceTokenParameter,
                            Expression.Convert(
                                Expression.Call(subpatternsParameter, underlyingListProperty.GetMethod),
                                propertyPatternClauseMethod.GetParameters()[1].ParameterType),
                            closeBraceTokenParameter),
                        openBraceTokenParameter,
                        subpatternsParameter,
                        closeBraceTokenParameter);
                PropertyPatternClauseAccessor2 = expression.Compile();
            }
            else
            {
                PropertyPatternClauseAccessor2 = ThrowNotSupportedOnFallback<SyntaxToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper>, SyntaxToken, TypeSyntax>(nameof(SyntaxFactory), nameof(PropertyPatternClause));
            }

            var parenthesizedPatternMethods = typeof(SyntaxFactory).GetTypeInfo().GetDeclaredMethods(nameof(ParenthesizedPattern));
            var parenthesizedPatternMethod = parenthesizedPatternMethods.FirstOrDefault(method => method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(PatternSyntax));
            if (parenthesizedPatternMethod is object)
            {
                var patternParameter = Expression.Parameter(typeof(CSharpSyntaxNode), "pattern");
                Expression<Func<CSharpSyntaxNode, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<CSharpSyntaxNode, CSharpSyntaxNode>>(
                        Expression.Call(
                            parenthesizedPatternMethod,
                            Expression.Convert(
                                patternParameter,
                                parenthesizedPatternMethod.GetParameters()[0].ParameterType)),
                        patternParameter);
                ParenthesizedPatternAccessor1 = expression.Compile();
            }
            else
            {
                ParenthesizedPatternAccessor1 = ThrowNotSupportedOnFallback<CSharpSyntaxNode, CSharpSyntaxNode>(nameof(SyntaxFactory), nameof(ParenthesizedPattern));
            }

            parenthesizedPatternMethod = parenthesizedPatternMethods.FirstOrDefault(method => method.GetParameters().Length == 3
                && method.GetParameters()[0].ParameterType == typeof(SyntaxToken)
                && method.GetParameters()[1].ParameterType == typeof(SeparatedSyntaxList<>).MakeGenericType(SyntaxWrapperHelper.GetWrappedType(typeof(SubpatternSyntaxWrapper)))
                && method.GetParameters()[2].ParameterType == typeof(SyntaxToken));
            if (parenthesizedPatternMethod is object)
            {
                var openParenTokenParameter = Expression.Parameter(typeof(SyntaxToken), "openParenToken");
                var patternParameter = Expression.Parameter(typeof(CSharpSyntaxNode), "pattern");
                var closeParenTokenParameter = Expression.Parameter(typeof(SyntaxToken), "closeParenToken");

                Expression<Func<SyntaxToken, CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode>> expression =
                    Expression.Lambda<Func<SyntaxToken, CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode>>(
                        Expression.Call(
                            parenthesizedPatternMethod,
                            openParenTokenParameter,
                            Expression.Convert(
                                patternParameter,
                                parenthesizedPatternMethod.GetParameters()[1].ParameterType),
                            closeParenTokenParameter),
                        openParenTokenParameter,
                        patternParameter,
                        closeParenTokenParameter);
                ParenthesizedPatternAccessor3 = expression.Compile();
            }
            else
            {
                ParenthesizedPatternAccessor3 = ThrowNotSupportedOnFallback<SyntaxToken, CSharpSyntaxNode, SyntaxToken, TypeSyntax>(nameof(SyntaxFactory), nameof(ParenthesizedPattern));
            }
        }

        public static PositionalPatternClauseSyntaxWrapper PositionalPatternClause(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper> subpatterns = default)
        {
            return (PositionalPatternClauseSyntaxWrapper)PositionalPatternClauseAccessor1(subpatterns);
        }

        public static PositionalPatternClauseSyntaxWrapper PositionalPatternClause(SyntaxToken openParenToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper> subpatterns, SyntaxToken closeParenToken)
        {
            return (PositionalPatternClauseSyntaxWrapper)PositionalPatternClauseAccessor2(openParenToken, subpatterns, closeParenToken);
        }

        public static PropertyPatternClauseSyntaxWrapper PropertyPatternClause(SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper> subpatterns = default)
        {
            return (PropertyPatternClauseSyntaxWrapper)PropertyPatternClauseAccessor1(subpatterns);
        }

        public static PropertyPatternClauseSyntaxWrapper PropertyPatternClause(SyntaxToken openBraceToken, SeparatedSyntaxListWrapper<SubpatternSyntaxWrapper> subpatterns, SyntaxToken closeBraceToken)
        {
            return (PropertyPatternClauseSyntaxWrapper)PropertyPatternClauseAccessor2(openBraceToken, subpatterns, closeBraceToken);
        }

        public static ParenthesizedPatternSyntaxWrapper ParenthesizedPattern(PatternSyntax pattern)
        {
            return (ParenthesizedPatternSyntaxWrapper)ParenthesizedPatternAccessor1(pattern);
        }

        public static ParenthesizedPatternSyntaxWrapper ParenthesizedPattern(SyntaxToken openParenToken, PatternSyntax pattern, SyntaxToken closeParenToken)
        {
            return (ParenthesizedPatternSyntaxWrapper)ParenthesizedPatternAccessor3(openParenToken, pattern, closeParenToken);
        }

        private static Func<T, TResult> ThrowNotSupportedOnFallback<T, TResult>(string typeName, string methodName)
        {
            return _ => throw new NotSupportedException($"{typeName}.{methodName} is not supported in this version");
        }

        private static Func<T1, T2, TResult> ThrowNotSupportedOnFallback<T1, T2, TResult>(string typeName, string methodName)
        {
            return (_, __) => throw new NotSupportedException($"{typeName}.{methodName} is not supported in this version");
        }

        private static Func<T1, T2, T3, TResult> ThrowNotSupportedOnFallback<T1, T2, T3, TResult>(string typeName, string methodName)
        {
            return (arg1, arg2, arg3) => throw new NotSupportedException($"{typeName}.{methodName} is not supported in this version");
        }
    }
}
