// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal readonly partial struct VarPatternSyntaxWrapper : ISyntaxWrapper<PatternSyntax>
    {
        internal const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.VarPatternSyntax";
        private static readonly Type WrappedType;

        private static readonly Func<PatternSyntax, SyntaxToken> VarKeywordAccessor;
        private static readonly Func<PatternSyntax, VariableDesignationSyntax> DesignationAccessor;
        private static readonly Func<PatternSyntax, SyntaxToken, PatternSyntax> WithVarKeywordAccessor;
        private static readonly Func<PatternSyntax, VariableDesignationSyntax, PatternSyntax> WithDesignationAccessor;

        private readonly PatternSyntax node;

        static VarPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(VarPatternSyntaxWrapper));
            VarKeywordAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(VarKeyword));
            DesignationAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<PatternSyntax, VariableDesignationSyntax>(WrappedType, nameof(Designation));
            WithVarKeywordAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, SyntaxToken>(WrappedType, nameof(VarKeyword));
            WithDesignationAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<PatternSyntax, VariableDesignationSyntax>(WrappedType, nameof(Designation));
        }

        private VarPatternSyntaxWrapper(PatternSyntax node)
        {
            this.node = node;
        }

        public PatternSyntax SyntaxNode => this.node;


        public SyntaxToken VarKeyword
        {
            get
            {
                return VarKeywordAccessor(this.SyntaxNode);
            }
        }

        public VariableDesignationSyntax Designation
        {
            get
            {
                return DesignationAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator VarPatternSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new VarPatternSyntaxWrapper((PatternSyntax)node);
        }

        public static implicit operator PatternSyntax(VarPatternSyntaxWrapper wrapper)
        {
            return wrapper.node;
        }

        public static bool IsInstance(SyntaxNode node)
        {
            return node != null && LightupHelpers.CanWrapNode(node, WrappedType);
        }

        public VarPatternSyntaxWrapper WithVarKeyword(SyntaxToken varKeyword)
        {
            return new VarPatternSyntaxWrapper(WithVarKeywordAccessor(this.SyntaxNode, varKeyword));
        }

        public VarPatternSyntaxWrapper WithDesignation(VariableDesignationSyntax designation)
        {
            return new VarPatternSyntaxWrapper(WithDesignationAccessor(this.SyntaxNode, designation));
        }
    }
}
