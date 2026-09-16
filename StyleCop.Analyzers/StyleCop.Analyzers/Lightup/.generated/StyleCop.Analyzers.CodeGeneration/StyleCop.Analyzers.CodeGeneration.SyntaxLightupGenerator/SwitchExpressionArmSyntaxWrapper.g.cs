// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct SwitchExpressionArmSyntaxWrapper : ISyntaxWrapper<CSharpSyntaxNode>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionArmSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<CSharpSyntaxNode, PatternSyntax> PatternAccessor;
        private static readonly Func<CSharpSyntaxNode, WhenClauseSyntax> WhenClauseAccessor;
        private static readonly Func<CSharpSyntaxNode, SyntaxToken> EqualsGreaterThanTokenAccessor;
        private static readonly Func<CSharpSyntaxNode, ExpressionSyntax> ExpressionAccessor;
        private static readonly Func<CSharpSyntaxNode, PatternSyntax, CSharpSyntaxNode> WithPatternAccessor;
        private static readonly Func<CSharpSyntaxNode, WhenClauseSyntax, CSharpSyntaxNode> WithWhenClauseAccessor;
        private static readonly Func<CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode> WithEqualsGreaterThanTokenAccessor;
        private static readonly Func<CSharpSyntaxNode, ExpressionSyntax, CSharpSyntaxNode> WithExpressionAccessor;

        private readonly CSharpSyntaxNode node;

        static SwitchExpressionArmSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(SwitchExpressionArmSyntaxWrapper));
            PatternAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, PatternSyntax>(WrappedType, nameof(Pattern));
            WhenClauseAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, WhenClauseSyntax>(WrappedType, nameof(WhenClause));
            EqualsGreaterThanTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(EqualsGreaterThanToken));
            ExpressionAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, ExpressionSyntax>(WrappedType, nameof(Expression));
            WithPatternAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, PatternSyntax>(WrappedType, nameof(Pattern));
            WithWhenClauseAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, WhenClauseSyntax>(WrappedType, nameof(WhenClause));
            WithEqualsGreaterThanTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(EqualsGreaterThanToken));
            WithExpressionAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, ExpressionSyntax>(WrappedType, nameof(Expression));
        }

        private SwitchExpressionArmSyntaxWrapper(CSharpSyntaxNode node)
        {
            this.node = node;
        }

        public CSharpSyntaxNode SyntaxNode => this.node;


        public PatternSyntax Pattern
        {
            get
            {
                return PatternAccessor(this.SyntaxNode);
            }
        }

        public WhenClauseSyntax WhenClause
        {
            get
            {
                return WhenClauseAccessor(this.SyntaxNode);
            }
        }

        public SyntaxToken EqualsGreaterThanToken
        {
            get
            {
                return EqualsGreaterThanTokenAccessor(this.SyntaxNode);
            }
        }

        public ExpressionSyntax Expression
        {
            get
            {
                return ExpressionAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator SwitchExpressionArmSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new SwitchExpressionArmSyntaxWrapper((CSharpSyntaxNode)node);
        }

        public static implicit operator CSharpSyntaxNode(SwitchExpressionArmSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public SwitchExpressionArmSyntaxWrapper WithPattern(PatternSyntax pattern)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithPatternAccessor(this.SyntaxNode, pattern));
        }

        public SwitchExpressionArmSyntaxWrapper WithWhenClause(WhenClauseSyntax whenClause)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithWhenClauseAccessor(this.SyntaxNode, whenClause));
        }

        public SwitchExpressionArmSyntaxWrapper WithEqualsGreaterThanToken(SyntaxToken equalsGreaterThanToken)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithEqualsGreaterThanTokenAccessor(this.SyntaxNode, equalsGreaterThanToken));
        }

        public SwitchExpressionArmSyntaxWrapper WithExpression(ExpressionSyntax expression)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithExpressionAccessor(this.SyntaxNode, expression));
        }
    }
}
