//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:\Projects\.Net\StellarisTechTree\src\StellarisTechTree.Infrastructure\Antlr\StellarisLocale\StellarisLocale.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class StellarisLocaleParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		LOCALEIDENTIFIER=1, BAREWORD=2, STRING=3, NUMBER=4, WS=5, LINE_COMMENT=6;
	public const int
		RULE_localeFile = 0, RULE_localeValue = 1;
	public static readonly string[] ruleNames = {
		"localeFile", "localeValue"
	};

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "LOCALEIDENTIFIER", "BAREWORD", "STRING", "NUMBER", "WS", "LINE_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "StellarisLocale.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static StellarisLocaleParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public StellarisLocaleParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public StellarisLocaleParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class LocaleFileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LOCALEIDENTIFIER() { return GetTokens(StellarisLocaleParser.LOCALEIDENTIFIER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LOCALEIDENTIFIER(int i) {
			return GetToken(StellarisLocaleParser.LOCALEIDENTIFIER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public LocaleValueContext[] localeValue() {
			return GetRuleContexts<LocaleValueContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public LocaleValueContext localeValue(int i) {
			return GetRuleContext<LocaleValueContext>(i);
		}
		public LocaleFileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_localeFile; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisLocaleVisitor<TResult> typedVisitor = visitor as IStellarisLocaleVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLocaleFile(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LocaleFileContext localeFile() {
		LocaleFileContext _localctx = new LocaleFileContext(Context, State);
		EnterRule(_localctx, 0, RULE_localeFile);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 8;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==LOCALEIDENTIFIER || _la==BAREWORD) {
				{
				State = 6;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case LOCALEIDENTIFIER:
					{
					State = 4;
					Match(LOCALEIDENTIFIER);
					}
					break;
				case BAREWORD:
					{
					State = 5;
					localeValue();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 10;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LocaleValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BAREWORD() { return GetToken(StellarisLocaleParser.BAREWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(StellarisLocaleParser.STRING, 0); }
		public LocaleValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_localeValue; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisLocaleVisitor<TResult> typedVisitor = visitor as IStellarisLocaleVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLocaleValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LocaleValueContext localeValue() {
		LocaleValueContext _localctx = new LocaleValueContext(Context, State);
		EnterRule(_localctx, 2, RULE_localeValue);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 11;
			Match(BAREWORD);
			State = 12;
			Match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\b', '\x11', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x3', '\x2', '\a', '\x2', '\t', '\n', '\x2', 
		'\f', '\x2', '\xE', '\x2', '\f', '\v', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x2', '\x2', '\x4', '\x2', '\x4', '\x2', 
		'\x2', '\x2', '\x10', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', '\x4', 
		'\r', '\x3', '\x2', '\x2', '\x2', '\x6', '\t', '\a', '\x3', '\x2', '\x2', 
		'\a', '\t', '\x5', '\x4', '\x3', '\x2', '\b', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '\b', '\a', '\x3', '\x2', '\x2', '\x2', '\t', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\n', '\b', '\x3', '\x2', '\x2', '\x2', '\n', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\v', '\x3', '\x3', '\x2', '\x2', '\x2', '\f', '\n', 
		'\x3', '\x2', '\x2', '\x2', '\r', '\xE', '\a', '\x4', '\x2', '\x2', '\xE', 
		'\xF', '\a', '\x5', '\x2', '\x2', '\xF', '\x5', '\x3', '\x2', '\x2', '\x2', 
		'\x4', '\b', '\n',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
