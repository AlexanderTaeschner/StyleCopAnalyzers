// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct RecursivePatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.RecursivePatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, TypeSyntax> TypeAccessor;
        private static readonly Func<PatternSyntax, CSharpSyntaxNode> PositionalPatternClauseAccessor;
        private static readonly Func<PatternSyntax, CSharpSyntaxNode> PropertyPatternClauseAccessor;
        private static readonly Func<PatternSyntax, VariableDesignationSyntax> DesignationAccessor;
        private static readonly Func<PatternSyntax, TypeSyntax, PatternSyntax> WithTypeAccessor;
        private static readonly Func<PatternSyntax, CSharpSyntaxNode, PatternSyntax> WithPositionalPatternClauseAccessor;
        private static readonly Func<PatternSyntax, CSharpSyntaxNode, PatternSyntax> WithPropertyPatternClauseAccessor;
        private static readonly Func<PatternSyntax, VariableDesignationSyntax, PatternSyntax> WithDesignationAccessor;

        private readonly PatternSyntax node;

        static RecursivePatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(RecursivePatternSyntaxWrapper));
            TypeAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, TypeSyntax>(WrappedType, nameof(Type));
            PositionalPatternClauseAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, CSharpSyntaxNode>(WrappedType, nameof(PositionalPatternClause));
            PropertyPatternClauseAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, CSharpSyntaxNode>(WrappedType, nameof(PropertyPatternClause));
            DesignationAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, VariableDesignationSyntax>(WrappedType, nameof(Designation));
            WithTypeAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, TypeSyntax>(WrappedType, nameof(Type));
            WithPositionalPatternClauseAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, CSharpSyntaxNode>(WrappedType, nameof(PositionalPatternClause));
            WithPropertyPatternClauseAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, CSharpSyntaxNode>(WrappedType, nameof(PropertyPatternClause));
            WithDesignationAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, VariableDesignationSyntax>(WrappedType, nameof(Designation));
        }

        private RecursivePatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public TypeSyntax Type
        {
            get
            {
                return TypeAccessor(this.SyntaxNode);
            }
        }

        public PositionalPatternClauseSyntaxWrapper PositionalPatternClause
        {
            get
            {
                return (PositionalPatternClauseSyntaxWrapper)PositionalPatternClauseAccessor(this.SyntaxNode);
            }
        }

        public PropertyPatternClauseSyntaxWrapper PropertyPatternClause
        {
            get
            {
                return (PropertyPatternClauseSyntaxWrapper)PropertyPatternClauseAccessor(this.SyntaxNode);
            }
        }

        public VariableDesignationSyntax Designation
        {
            get
            {
                return DesignationAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator RecursivePatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new RecursivePatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(RecursivePatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public RecursivePatternSyntaxWrapper WithType(TypeSyntax type)
        {
            return new RecursivePatternSyntaxWrapper(WithTypeAccessor(this.SyntaxNode, type));
        }

        public RecursivePatternSyntaxWrapper WithPositionalPatternClause(PositionalPatternClauseSyntaxWrapper positionalPatternClause)
        {
            return new RecursivePatternSyntaxWrapper(WithPositionalPatternClauseAccessor(this.SyntaxNode, positionalPatternClause));
        }

        public RecursivePatternSyntaxWrapper WithPropertyPatternClause(PropertyPatternClauseSyntaxWrapper propertyPatternClause)
        {
            return new RecursivePatternSyntaxWrapper(WithPropertyPatternClauseAccessor(this.SyntaxNode, propertyPatternClause));
        }

        public RecursivePatternSyntaxWrapper WithDesignation(VariableDesignationSyntax designation)
        {
            return new RecursivePatternSyntaxWrapper(WithDesignationAccessor(this.SyntaxNode, designation));
        }
    }
}
